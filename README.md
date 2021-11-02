# New World Trading Post Data Extractor
(Relatively) Easy to use New World trading post price extraction tool.

## How to build
- Install .NET 5.0 SDK (Windows x64) from https://dotnet.microsoft.com/download/dotnet/5.0
- Run TradingPostDataExtractor\publish.cmd, which will create TradingPostDataExtractor.exe in Publish folder.

## How it works

It simply takes screenshots of New World, then runs them through OCR, nothing magical about it. It doesn't in any way interfere with the game. Just screenshots. 

## How to use
- Launch the TradingPostDataExtractor and New World (it doesn't matter which one you launch first.)
- Make sure New World is running in 1920x1080 FullScreen mode.
- Optionally, increase the New World Gamma setting to maximum.
- Visit the Trading Post, search for something and hit CTRL-H (or the big button on app)
- Scan as many pages / orders you want.
- Hit the Export Prices button and save the json file.
- Wait for me to implement the Import Prices functionality for https://gaming.tools.

## Credits
- https://github.com/CptWesley, author of https://github.com/CptWesley/NewWorldMinimap for inspiration and for the beautiful https://github.com/CptWesley/TesserNet library.
