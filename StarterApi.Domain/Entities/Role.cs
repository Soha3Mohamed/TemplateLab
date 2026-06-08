namespace StarterApi.Domain.Entities;

public class Role : BaseEntity
{

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ICollection<User> Users { get; set; } = new HashSet<User>();
}