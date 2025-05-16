using Domain.Entities;

namespace Infrastructure.Interface;

public interface ILikeService
{
    public Task<List<Like>> GetAllLike();
    public Task<string> CreateLike(Like like);
    public Task<string> UpdateLike(Like like);
    public Task<string> DeleteLike(int id);
}
