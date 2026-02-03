using GanttChartApp.Models;

namespace GanttChartApp.Tests;

[TestClass]
public class GanttChartDataTests
{
    [TestMethod]
    public void GanttChartData_DefaultConstructor_SetsDefaultValues()
    {
        // Arrange & Act
        var chartData = new GanttChartData();

        // Assert
        Assert.AreEqual(string.Empty, chartData.Id);
        Assert.AreEqual(string.Empty, chartData.Name);
        Assert.IsNotNull(chartData.Tasks);
        Assert.AreEqual(0, chartData.Tasks.Count);
        Assert.AreEqual(default, chartData.CreatedDate);
        Assert.AreEqual(default, chartData.ProjectStart);
        Assert.AreEqual(default, chartData.ProjectEnd);
    }

    [TestMethod]
    public void GanttChartData_SetProperties_ReturnsCorrectValues()
    {
        // Arrange
        var chartData = new GanttChartData();
        var createdDate = new DateTime(2024, 1, 1);
        var projectStart = new DateTime(2024, 1, 15);
        var projectEnd = new DateTime(2024, 3, 15);
        var tasks = new List<TaskData>
        {
            new TaskData { TaskId = 1, TaskName = "Task 1" },
            new TaskData { TaskId = 2, TaskName = "Task 2" }
        };

        // Act
        chartData.Id = "chart-123";
        chartData.Name = "Test Project";
        chartData.CreatedDate = createdDate;
        chartData.ProjectStart = projectStart;
        chartData.ProjectEnd = projectEnd;
        chartData.Tasks = tasks;

        // Assert
        Assert.AreEqual("chart-123", chartData.Id);
        Assert.AreEqual("Test Project", chartData.Name);
        Assert.AreEqual(createdDate, chartData.CreatedDate);
        Assert.AreEqual(projectStart, chartData.ProjectStart);
        Assert.AreEqual(projectEnd, chartData.ProjectEnd);
        Assert.AreEqual(2, chartData.Tasks.Count);
        Assert.AreEqual("Task 1", chartData.Tasks[0].TaskName);
        Assert.AreEqual("Task 2", chartData.Tasks[1].TaskName);
    }

    [TestMethod]
    public void GanttChartData_AddTask_IncreasesTaskCount()
    {
        // Arrange
        var chartData = new GanttChartData();
        var task = new TaskData { TaskId = 1, TaskName = "New Task" };

        // Act
        chartData.Tasks.Add(task);

        // Assert
        Assert.AreEqual(1, chartData.Tasks.Count);
        Assert.AreEqual("New Task", chartData.Tasks[0].TaskName);
    }

    [TestMethod]
    public void GanttChartData_RemoveTask_DecreasesTaskCount()
    {
        // Arrange
        var chartData = new GanttChartData();
        var task1 = new TaskData { TaskId = 1, TaskName = "Task 1" };
        var task2 = new TaskData { TaskId = 2, TaskName = "Task 2" };
        chartData.Tasks.Add(task1);
        chartData.Tasks.Add(task2);

        // Act
        chartData.Tasks.Remove(task1);

        // Assert
        Assert.AreEqual(1, chartData.Tasks.Count);
        Assert.AreEqual("Task 2", chartData.Tasks[0].TaskName);
    }

    [TestMethod]
    public void GanttChartData_ClearTasks_EmptiesTaskList()
    {
        // Arrange
        var chartData = new GanttChartData();
        chartData.Tasks.Add(new TaskData { TaskId = 1, TaskName = "Task 1" });
        chartData.Tasks.Add(new TaskData { TaskId = 2, TaskName = "Task 2" });

        // Act
        chartData.Tasks.Clear();

        // Assert
        Assert.AreEqual(0, chartData.Tasks.Count);
    }
}
