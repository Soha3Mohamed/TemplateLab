using StarterApi.Domain.Enums;

namespace StarterApi.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public TaskItemStatus Status { get; set; } = TaskItemStatus.Todo;

    public int ProjectId { get; set; }

    public Project Project { get; set; } = null!;

    public int UserId { get; set; }

    public User User { get; set; } = null!;
}


