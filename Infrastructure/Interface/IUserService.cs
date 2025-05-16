using Domain.Entities;

namespace Infrastructure.Interface;

public interface IUserService
{
    public Task<List<User>> GetAllUserAsync();
    public Task<User?> GetUserByIdAsync(int id);
    public Task<string> CreateUserAsync(User user);
    public Task<string> UpdateUserAsync(User user);
    public Task<string> DeleteUserAsync(int id);
}
