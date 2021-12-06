using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TesserNet;

namespace Parser
{
    public static class TesseractFactory
    {
        private const string LanguagesFolder = "languages";

        private static readonly HttpClient HttpClient = new();

        private static readonly Dictionary<string, ITesseract> Cache = new();

        public static ITesseract Create(string language, bool numbersOnly)
        {
            language ??= "eng";

            var cacheKey = $"{language}-{numbersOnly}";
            if (Cache.TryGetValue(cacheKey, out var tesseract))
            {
                return tesseract;
            }

            CheckLanguage(language);

            if (language == "eng")
            {
                if (numbersOnly)
                {
                    Cache[cacheKey] = new TesseractPool(new TesseractOptions
                    {
                        PageSegmentation = PageSegmentation.Line,
                        Numeric = true,
                        Whitelist = "0123456789"
                    });
                }
                else
                {
                    Cache[cacheKey] = new TesseractPool(new TesseractOptions
                    {
                        PageSegmentation = PageSegmentation.SegmentationOsd,
                        Numeric = false
                    });
                }
            }
            if (numbersOnly)
            {
                Cache[cacheKey] = new TesseractPool(new TesseractOptions
                {
                    PageSegmentation = PageSegmentation.Line,
                    Numeric = true,
                    Whitelist = "0123456789",
                    DataPath = "languages",
                    Language = language
                });
            }
            else
            {
                Cache[cacheKey] = new TesseractPool(new TesseractOptions
                {
                    PageSegmentation = PageSegmentation.SegmentationOsd,
                    Numeric = false,
                    DataPath = "languages",
                    Language = language
                });
            }

            return Cache[cacheKey];
        }

        private static void CheckLanguage(string language)
        {
            if (!Directory.Exists(LanguagesFolder))
            {
                Directory.CreateDirectory(LanguagesFolder);
            }
            var languageFileName = $"{language}.traineddata";
            var languageFilePath = Path.Combine(LanguagesFolder, languageFileName);
            if (File.Exists(languageFilePath))
            {
                return;
            }

            var languageUrl = $"https://github.com/tesseract-ocr/tessdata/raw/main/{language}.traineddata";

            var languageData = Task.Run(async () => await HttpClient.GetByteArrayAsync(languageUrl)).Result;
            File.WriteAllBytes(languageFilePath, languageData);

        }
    }
}
