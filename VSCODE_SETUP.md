# MyTestApp - VS Code Setup Guide

## Overview
This project includes:
- ✅ VS Code launch configuration for debugging
- ✅ Build tasks for .NET and SCSS compilation
- ✅ SCSS styling with automatic compilation
- ✅ Recommended extensions for development

## Getting Started

### 1. Install Node.js and npm
SCSS compilation requires npm. Download from [nodejs.org](https://nodejs.org/)

### 2. Install Sass Compiler
```bash
npm install
```

This installs the Sass compiler defined in `package.json`.

### 3. Compile SCSS to CSS

#### One-time compilation:
```bash
npm run scss:build
```

#### Watch mode (auto-compile on save):
```bash
npm run scss:watch
```

#### Production (minified):
```bash
npm run scss:build-min
```

### 4. Running the Application

#### Option A: Using VS Code Debug (F5)
1. Press `F5` or select "Run and Debug"
2. Choose "AppHost" configuration
3. The app will build and open in your browser

#### Option B: Using dotnet CLI
```bash
dotnet run --project MyTestApp.AppHost
```

## File Structure

```
MyTestApp/
├── .vscode/
│   ├── launch.json       # Debug configuration
│   ├── tasks.json        # Build tasks
│   ├── settings.json     # Editor settings
│   └── extensions.json   # Recommended extensions
├── MyTestApp.Web/
│   └── wwwroot/
│       ├── styles.scss   # Main SCSS file (edit this!)
│       ├── styles.css    # Compiled output (auto-generated)
│       └── app.css       # Legacy CSS
├── package.json          # npm scripts for SCSS
└── MyTestApp.sln         # Solution file
```

## Development Workflow

1. **Edit SCSS**: Modify `MyTestApp.Web/wwwroot/styles.scss`
2. **Auto-compile**: Run `npm run scss:watch` in terminal
3. **View changes**: Refresh browser (Blazor hot reload may work)
4. **Build project**: F5 or `dotnet run`

## SCSS Features Included

- 🎨 Color variables and mixins
- 📱 Responsive design breakpoints
- 🎯 Pre-built component styles (buttons, forms, counter)
- 🔄 Smooth transitions and animations
- ♿ Accessibility-friendly styling

## Recommended VS Code Extensions

All recommended extensions are listed in `.vscode/extensions.json`:
- **C#** - C# language support
- **Sass IntelliSense** - SCSS autocompletion
- **Prettier** - Code formatting
- **Live Server** - Live preview (optional)

Install recommendations: Open Extensions, search "Show Recommended Extensions"

## Troubleshooting

### SCSS not compiling?
- Ensure Node.js is installed: `node --version`
- Run `npm install` to install Sass
- Check terminal for error messages

### Styles not showing?
- Ensure `styles.css` exists in `wwwroot/`
- Clear browser cache (Ctrl+Shift+Del)
- Hard refresh: Ctrl+Shift+R (or Cmd+Shift+R on Mac)

### Debug not working?
- Ensure .NET SDK 10.0+ is installed
- Check `launch.json` paths are correct
- Rebuild solution: `dotnet clean && dotnet build`

## Additional Resources

- [SCSS Documentation](https://sass-lang.com/documentation)
- [Blazor CSS & JS Documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/css-isolation)
- [ASP.NET Aspire Documentation](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
