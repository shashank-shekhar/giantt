using System.ComponentModel.DataAnnotations;
using GanttChartApp.Models;

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
        Assert.AreEqual(default, task.StartDate);
        Assert.AreEqual(default, task.EndDate);
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
        var task = new TaskData
        {
            // Act & Assert - Test boundary values
            Progress = 0
        };

        Assert.AreEqual(0, task.Progress);

        task.Progress = 100;
        Assert.AreEqual(100, task.Progress);

        task.Progress = 50;
        Assert.AreEqual(50, task.Progress);
    }
}