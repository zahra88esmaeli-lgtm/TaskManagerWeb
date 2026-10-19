using System.ComponentModel.DataAnnotations;

namespace TaskManagerWeb.Models.Dto
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string? Description { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
