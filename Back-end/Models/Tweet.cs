namespace TwitterClone.Models;

public class Tweet
{
    public int Id { get; set; }

    public string Content { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User? User { get; set; }
}