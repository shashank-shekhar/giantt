using GanttChartApp.Models;
using System.ComponentModel.DataAnnotations;

namespace GanttChartApp.Tests;

[TestClass]
public class TaskDataTests
{
    [TestMethod]
    public void TaskData_DefaultConstructor_SetsDefaultValues()
    {
        // Arrange & Act
        var task = new TaskData();

        // Assert
        Assert.AreEqual(0, task.TaskId);
        Assert.AreEqual(string.Empty, task.TaskName);
        Assert.AreEqual(default(DateTime), task.StartDate);
        Assert.AreEqual(default(DateTime), task.EndDate);
        Assert.AreEqual(string.Empty, task.Duration);
        Assert.AreEqual(0, task.Progress);
        Assert.IsNull(task.ParentId);
    }

    [TestMethod]
    public void TaskData_SetProperties_ReturnsCorrectValues()
    {
        // Arrange
        var task = new TaskData();
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 15);

        // Act
        task.TaskId = 1;
        task.TaskName = "Test Task";
        task.StartDate = startDate;
        task.EndDate = endDate;
        task.Duration = "14 days";
        task.Progress = 50;
        task.ParentId = 2;

        // Assert
        Assert.AreEqual(1, task.TaskId);
        Assert.AreEqual("Test Task", task.TaskName);
        Assert.AreEqual(startDate, task.StartDate);
        Assert.AreEqual(endDate, task.EndDate);
        Assert.AreEqual("14 days", task.Duration);
        Assert.AreEqual(50, task.Progress);
        Assert.AreEqual(2, task.ParentId);
    }

    [TestMethod]
    public void TaskData_TaskNameRequired_ValidationAttribute()
    {
        // Arrange
        var task = new TaskData();
        var context = new ValidationContext(task);
        var results = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(task, context, results, true);

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsTrue(results.Any(r => r.MemberNames.Contains("TaskName")));
    }

    [TestMethod]
    public void TaskData_ValidTaskName_PassesValidation()
    {
        // Arrange
        var task = new TaskData { TaskName = "Valid Task Name" };
        var context = new ValidationContext(task);
        var results = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(task, context, results, true);

        // Assert
        Assert.IsTrue(isValid);
        Assert.AreEqual(0, results.Count);
    }

    [TestMethod]
    public void TaskData_ProgressBoundaries_AcceptsValidValues()
    {
        // Arrange
        var task = new TaskData();

        // Act & Assert - Test boundary values
        task.Progress = 0;
        Assert.AreEqual(0, task.Progress);

        task.Progress = 100;
        Assert.AreEqual(100, task.Progress);

        task.Progress = 50;
        Assert.AreEqual(50, task.Progress);
    }
}

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
        Assert.AreEqual(default(DateTime), chartData.CreatedDate);
        Assert.AreEqual(default(DateTime), chartData.ProjectStart);
        Assert.AreEqual(default(DateTime), chartData.ProjectEnd);
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
