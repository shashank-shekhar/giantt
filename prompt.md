# Project overview
A gantt chart blazor app

Update the prompt.md file after each step.
Keep track of all changes made to the application in this file. 

## TODO 
- [x] Initialize a git repo and commit after each step
- [x] Create a new blazor client app
- [x] Include Syncfusion Gantt chart component
- [x] Configure Syncfusion Blazor theme
- [x] Allow users to create and edit gantt chart
- [x] Create a unique id for each gantt chart and save it in local storage that the user can load later
- [x] Add a readme.md file with instructions on how to run the app
- [x] Make the Gantt page the default and only page in the application
- [x] Set up user secrets for secure configuration
- [x] Configure Syncfusion license key in user secrets
- [x] Update application to read configuration from user secrets
- [x] Remove bin and obj directories from git tracking
- [x] Add proper .gitignore rules for .NET development
- [x] Create unit test project using Visual Studio testing framework (MSTest)
- [x] Add comprehensive unit tests for TaskData and GanttChartData models

## Changes Made
- Added Syncfusion Blazor theme configuration in App.razor
- Updated Program.cs to properly configure Syncfusion Blazor services
- Added Bootstrap 5 theme for Syncfusion components
- Configured CDN for Syncfusion scripts and styles
- Set up user secrets for secure storage of the Syncfusion license key
- Added error handling for missing configuration in development
- Added proper .gitignore rules to exclude build artifacts and user secrets
- Created GanttChartApp.Tests project using MSTest framework
- Added comprehensive unit tests for TaskData model (5 test methods)
- Added comprehensive unit tests for GanttChartData model (5 test methods)
- All 10 unit tests pass successfully
- Test project properly references the main GanttChartApp project