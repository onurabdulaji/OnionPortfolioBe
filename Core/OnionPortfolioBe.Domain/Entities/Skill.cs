namespace OnionPortfolioBe.Domain.Entities;

public class Skill : BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Title { get; set; }
    public int? Value { get; set; }
    public Skill()
    {
    }
    public Skill(string title, int value)
    {
        Id = Guid.NewGuid();
        Title = title;
        Value = value;
    }
}