using System.ComponentModel.DataAnnotations;

namespace GanttChartApp.Models
{
    public class TaskData
    {
        public int TaskId { get; set; }
        
        [Required]
        public string TaskName { get; set; } = string.Empty;
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public string Duration { get; set; } = string.Empty;
        
        public int Progress { get; set; }
        
        public int? ParentId { get; set; }
    }

    public class GanttChartData
    {
        public string Id { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public List<TaskData> Tasks { get; set; } = new();
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime ProjectStart { get; set; }
        
        public DateTime ProjectEnd { get; set; }
    }
}
