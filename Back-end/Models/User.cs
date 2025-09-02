namespace TwitterClone.Models;

public class User
{
    public int Id { get; set; }

    public string AccountName { get; set; } = "";
    public string PhotoUrl { get; set; } = "";
    public string name { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";

    public List<Tweet> Tweets { get; set; } = new();
}