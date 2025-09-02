using Microsoft.EntityFrameworkCore;
using TwitterClone.Data;
using TwitterClone.Models;

namespace TwitterClone.Services;

public class UserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        this._context = context;
    }
    
    public IEnumerable<User> GetAll()
    {
        return _context.Users
            .Include(u => u.Tweets)
            .ToList();
    }
    
    public async Task<User?> GetUserWithTweets(int id)
    {
        return await _context.Users
            .Include(u => u.Tweets)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
    
    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}