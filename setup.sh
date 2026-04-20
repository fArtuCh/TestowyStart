#!/bin/bash
# Quick Setup Script for MyTestApp

echo ""
echo "================================"
echo "MyTestApp - Initial Setup"
echo "================================"
echo ""

# Check if Node.js is installed
if ! command -v node &> /dev/null
then
    echo "✗ Node.js not found. Install from https://nodejs.org/"
    exit 1
fi

echo "✓ Node.js is installed"
node --version

echo ""
echo "Installing npm dependencies..."
npm install

echo ""
echo "Compiling SCSS to CSS..."
npm run scss:build

echo ""
echo "✓ Setup complete!"
echo ""
echo "Next steps:"
echo "1. Open this folder in VS Code"
echo "2. Press F5 to run the app"
echo "3. For live SCSS editing, run: npm run scss:watch"
echo ""
