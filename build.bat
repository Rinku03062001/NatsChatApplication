@echo off
REM build.bat - Script to build and publish the ChatApp

REM Go to project folder
cd /d "D:\C# Project\NatsChatProject\ChatAppNats"

REM Clean old build
dotnet clean

REM Build in Release mode
dotnet build --configuration Release

REM Publish as single EXE (self-contained)
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o publish

echo.
echo Build and Publish Completed!
pause
