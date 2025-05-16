namespace Domain.Entities;

public class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Context { get; set; }
    public DateTime CreationDate { get; set; }
    public int LikesCount { get; set; }
}
