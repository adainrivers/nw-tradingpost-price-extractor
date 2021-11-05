# New World Trading Post Price Extractor
(Relatively) Easy to use New World trading post price extraction tool.

![image](https://user-images.githubusercontent.com/93623214/140588520-248ccecf-febf-4642-8006-48ca471f57f3.png)

## How to build
- Install .NET 5.0 SDK (Windows x64) from https://dotnet.microsoft.com/download/dotnet/5.0
- Run TradingPostDataExtractor\publish.cmd, which will create TradingPostDataExtractor.exe in Publish folder.

If you don't wanna deal with that, just download the binary release from: https://github.com/adainrivers/nw-tradingpost-price-extractor/releases/tag/0.1.0

## How it works

It simply takes screenshots of New World, then runs them through OCR, nothing magical about it. It doesn't in any way interfere with the game. Just screenshots. 

## Use with caution

New World TOS is very restrictive, even with extracting information from screenshots, so, use it on your own risk.

## How to use
- Launch the TradingPostDataExtractor and New World (it doesn't matter which one you launch first.)
- Make sure New World is running in FullScreen mode (sorry, it doesn't support windowed mode yet)
- Optionally, increase the New World Gamma setting to maximum for better detection rate.
- Visit the Trading Post, search for something and hit F11 (or the big button on app)
- Scan as many pages / orders you want (you might have problems when you scroll down, try to aim it right, whatever that means)
- Hit the Export Prices button and save the json file.
- After this, you can use the extracted prices at https://gaming.tools/newworld or wherever you like :)

## Credits
- https://github.com/CptWesley, author of https://github.com/CptWesley/NewWorldMinimap for inspiration and for the beautiful https://github.com/CptWesley/TesserNet library.

![image](https://user-images.githubusercontent.com/93623214/139960936-45d6200a-6c9d-4d2a-965c-4727b9937d64.png)
