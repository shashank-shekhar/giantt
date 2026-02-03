# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run Commands

```bash
# Build
dotnet build

# Run (dev server at http://localhost:5053)
dotnet run --project GanttChartApp

# Run tests
dotnet test

# Run a single test
dotnet test --filter "FullyQualifiedName~TestMethodName"

# Publish for production
dotnet publish GanttChartApp/GanttChartApp.csproj --configuration Release --output ./publish
```

## NuGet Package Sources

`nuget.config` routes `Syncfusion.*` packages to a GitHub Packages feed (`shashank-shekhar` org) that contains licensed Syncfusion NuGets — no license key registration is needed in the application. The feed authenticates via `%NUGET_USERNAME%` / `%NUGET_PASSWORD%` env vars. All other packages come from nuget.org.

## Architecture

This is a **Blazor WebAssembly** single-page application (.NET 9.0) using **Syncfusion Blazor Gantt** as the core UI component.

**Solution structure** (`GanttChart.slnx`):
- `GanttChartApp/` — The Blazor WASM app
- `GanttChartApp.Tests/` — MSTest unit tests

**Key files:**
- `GanttChartApp/Components/Pages/GanttChart.razor` — Main (and only) page. Contains the Syncfusion `SfGantt` component, all toolbar/export logic, dialog management (save/load/share), and local storage persistence via JS interop.
- `GanttChartApp/Models/TaskData.cs` — `TaskData` (individual task) and `GanttChartData` (chart with metadata and task collection) models.
- `GanttChartApp/Program.cs` — App bootstrap. Registers Syncfusion Blazor services.
- `GanttChartApp/Components/App.razor` — Root router component.

**Data flow:** All chart data lives in-memory as a `List<TaskData>`. Persistence uses browser `localStorage` via JS interop — charts are serialized to JSON. Sharing encodes chart data as base64 in a URL.

## Deployment

GitHub Actions (`.github/workflows/deploy-to-pages.yml`) builds and deploys to GitHub Pages on push to `main`. The workflow adjusts `<base href>` for the repo subdirectory and copies `index.html` to `404.html` for SPA client-side routing.
