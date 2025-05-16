namespace Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string Context { get; set; }
    public DateTime CreationDate { get; set; }
}
