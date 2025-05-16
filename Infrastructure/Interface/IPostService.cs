using Domain.Entities;

namespace Infrastructure.Interface;

public interface IPostService
{
    public Task<List<Post>> GetAllPost();
    public Task<Post?> GetPostById(int id);
    public Task<string> CreatePost(Post post);
    public Task<string> UpdatePost(Post post);
    public Task<string> DeletePost(int id);
}
