# Gantt Chart Blazor Application

A modern Gantt chart application built with Blazor Server and Syncfusion components that allows users to create, edit, and manage project timelines with local storage persistence.

## Features

- **Interactive Gantt Chart**: Full-featured Gantt chart with drag-and-drop functionality
- **Task Management**: Create, edit, and delete tasks with hierarchical structure
- **Local Storage**: Save and load charts with unique IDs for persistence
- **Real-time Editing**: Live updates as you modify tasks and timelines
- **Responsive Design**: Modern UI with Bootstrap styling
- **Project Timeline**: Visual representation of project start and end dates

## Prerequisites

- .NET 9.0 SDK or later
- A modern web browser (Chrome, Firefox, Safari, Edge)

## Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd giantt
```

### 2. Navigate to the Application Directory

```bash
cd GanttChartApp
```

### 3. Restore Dependencies

```bash
dotnet restore
```

### 4. Run the Application

```bash
dotnet run
```

The application will start and be available at `http://localhost:5053` (or the port shown in the console output).

## Usage

### Creating a New Gantt Chart

1. Navigate to the **Gantt Chart** page from the navigation menu
2. Click **"Create New Chart"** to start with a blank chart
3. Use **"Add Task"** to create new tasks
4. Edit task details directly in the grid or by dragging taskbars

### Editing Tasks

- **In-Grid Editing**: Click on any cell to edit task properties
- **Taskbar Editing**: Drag taskbars to change start dates, end dates, and duration
- **Hierarchical Tasks**: Set Parent ID to create task dependencies
- **Progress Tracking**: Update progress percentage for visual completion tracking

### Saving and Loading Charts

1. **Save Chart**: 
   - Enter a chart name in the "Chart Name" field
   - Click **"Save Chart"** to store in browser local storage
   - A unique ID will be generated for the chart

2. **Load Chart**:
   - Click **"Load Chart"** to restore the most recently saved chart
   - Chart data persists across browser sessions

### Task Properties

- **Task ID**: Unique identifier for each task
- **Task Name**: Descriptive name for the task
- **Start Date**: When the task begins
- **End Date**: When the task is scheduled to complete
- **Duration**: Length of time for task completion
- **Progress**: Completion percentage (0-100%)
- **Parent ID**: For creating task hierarchies and dependencies

## Technical Details

### Built With

- **Blazor Server**: Microsoft's web framework for building interactive web UIs
- **Syncfusion Blazor Gantt**: Professional Gantt chart component
- **Bootstrap**: CSS framework for responsive design
- **Local Storage API**: Browser storage for chart persistence

### Project Structure

```
GanttChartApp/
├── Components/
│   ├── Layout/          # Application layout components
│   ├── Pages/           # Razor pages including GanttChart.razor
│   └── _Imports.razor   # Global using statements
├── Models/              # Data models (TaskData, GanttChartData)
├── wwwroot/            # Static files and assets
├── Program.cs          # Application startup and configuration
└── appsettings.json    # Application settings
```

### Key Components

- **GanttChart.razor**: Main Gantt chart page with full functionality
- **TaskData.cs**: Data model for individual tasks
- **GanttChartData.cs**: Container model for complete chart data

## Customization

### Adding New Features

The application is designed to be extensible. You can:

- Add new task properties by extending the `TaskData` model
- Implement additional storage options (database, cloud storage)
- Add export functionality (PDF, Excel, etc.)
- Integrate with external project management APIs

### Styling

The application uses Bootstrap for styling. You can customize the appearance by:

- Modifying CSS classes in the Razor components
- Adding custom CSS files to the `wwwroot` directory
- Configuring Syncfusion theme options

## Troubleshooting

### Common Issues

1. **Port Already in Use**: If port 5053 is busy, the application will automatically use another port
2. **Syncfusion License**: For production use, you may need a Syncfusion license
3. **Browser Compatibility**: Ensure you're using a modern browser with JavaScript enabled

### Development Tips

- Use browser developer tools to inspect local storage data
- Check the browser console for any JavaScript errors
- The application supports hot reload during development

## License

This project is open source and available under the MIT License.

## Support

For issues and questions:
1. Check the browser console for error messages
2. Verify all dependencies are properly installed
3. Ensure the application is running on the correct port

## Version History

- **v1.0.0**: Initial release with core Gantt chart functionality
  - Task creation and editing
  - Local storage persistence
  - Hierarchical task structure
  - Interactive timeline management
