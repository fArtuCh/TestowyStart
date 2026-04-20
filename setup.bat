@echo off
REM Quick Setup Script for MyTestApp
echo.
echo ================================
echo MyTestApp - Initial Setup
echo ================================
echo.

REM Check if Node.js is installed
where node >nul 2>nul
if %ERRORLEVEL% EQU 0 (
    echo ✓ Node.js is installed
    node --version
) else (
    echo ✗ Node.js not found. Install from https://nodejs.org/
    exit /b 1
)

echo.
echo Installing npm dependencies...
call npm install

echo.
echo Compiling SCSS to CSS...
call npm run scss:build

echo.
echo ✓ Setup complete!
echo.
echo Next steps:
echo 1. Open this folder in VS Code
echo 2. Press F5 to run the app
echo 3. For live SCSS editing, run: npm run scss:watch
echo.
pause
