
# Clean the entire build and output directories
Remove-Item -Force -Recurse -Path .\bin -ErrorAction Ignore
Remove-Item -Force -Recurse -Path .\obj -ErrorAction Ignore
Remove-Item -Force -Recurse -Path .\out -ErrorAction Ignore

# Publish to single exe
dotnet publish -r win10-x64 -p:PublishTrimmed=true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:DebugType=None -p:OutputType=WinExe --self-contained true -c Release -o out
mv out\SteamLinkEpicLauncher.exe out\SteamLinkEpicLauncher-NoTerminal.exe
dotnet publish -r win10-x64 -p:PublishTrimmed=true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:DebugType=None --self-contained true -c Release -o out
editbin /subsystem:windows out\SteamLinkEpicLauncher-NoTerminal.exe
