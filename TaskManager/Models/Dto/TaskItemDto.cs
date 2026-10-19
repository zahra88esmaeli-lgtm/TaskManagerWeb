namespace TaskManagerWeb.Models.Dto
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public bool IsDone { get; set; }
    }
}
