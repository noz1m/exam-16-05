using Domain.Entities;

namespace Infrastructure.Interface;

public interface ICommentService
{
    public Task<List<Comment>> GetAllComment();
    public Task<string> CreateComment(Comment comment);
    public Task<string> UpdateComment(Comment comment);
    public Task<string> DeleteComment(int id);
    
}
