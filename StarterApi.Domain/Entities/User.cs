namespace StarterApi.Domain.Entities;

public class User : BaseEntity
{

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;
    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;

    public ICollection<Project> Projects { get; set; } = new HashSet<Project>();

    public ICollection<TaskItem> AssignedTasks { get; set; } = new HashSet<TaskItem>();

    public ICollection<Project> AuthoredProjects { get; set; } = new HashSet<Project>();
}