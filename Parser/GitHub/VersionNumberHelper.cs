namespace Parser.GitHub
{
    public class VersionNumberHelper
    {
        public static int GetNumericVersionNumber(string version)
        {
            var versionString = version.Replace(".", string.Empty);
            if (int.TryParse(versionString, out var result))
            {
                return result;
            }

            return 0;
        }
    }
}
