namespace StarterApi.Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public int AuthorId { get; set; }

    public User Author { get; set; } = null!;

    public ICollection<User> Users { get; set; } = new HashSet<User>();

    public ICollection<TaskItem> TaskItems { get; set; } = new HashSet<TaskItem>();
}