using Dapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interface;
namespace Infrastructure.Service;

public class CommentService : ICommentService
{
    private readonly DataContext context = new DataContext();

    public async Task<List<Comment>> GetAllComment()
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from comments";
        var result = await connection.QueryAsync<Comment>(sql);
        return result.ToList();
    }
    public async Task<string> CreateComment(Comment comment)
    {
        using var connection = await context.GetConnection();
        var sql = @"insert into comments (userId,postId,context,creationDate)
                        values (@userId,postId,context,@creationDate)";
        var result = await connection.ExecuteAsync(sql, comment);
        return result > 0 ? "Successfully created" : "Failed";
    }
    public async Task<string> UpdateComment(Comment comment)
    {
        using var connection = await context.GetConnection();
        var sql = @"update comments set (userId=@userId,postId=@postId,context=@context,creationDate=@creationDate)
                    where id = @id";
        var result = await connection.ExecuteAsync(sql, comment);
        return result > 0 ? "Successfully update" : "Failed";
    }
    public async Task<string> DeleteComment(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"delete from comments where id = @id";
        var result = await connection.ExecuteAsync(sql, new { id });
        return result > 0 ? "Successfully delete" : "Failed";
    }
}
