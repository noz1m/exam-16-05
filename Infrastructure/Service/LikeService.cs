using Dapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interface;
namespace Infrastructure.Service;

public class LikeService : ILikeService
{
    private readonly DataContext context = new DataContext();

    public async Task<List<Like>> GetAllLike()
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from likes";
        var result = await connection.QueryAsync<Like>(sql);
        return result.ToList();
    }
    public async Task<string> CreateLike(Like like)
    {
        using var connection = await context.GetConnection();
        var sql = @"insert into likes (userId,postId,likeDate)
                    values (@userId,@postId,@likeDate)";
        var result = await connection.ExecuteAsync(sql, like);
        return result > 0 ? "Successfully created" : "Failed";
    }
    public async Task<string> UpdateLike(Like like)
    {
        using var connection = await context.GetConnection();
        var sql = @"update likes set (userId=@userId,postId=@postId,likeDate=@likeDate)
                    where id = @id";
        var result = await connection.ExecuteAsync(sql, like);
        return result > 0 ? "Successfully update" : "Failed";
    }
    public async Task<string> DeleteLike(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"delete from likes where id = @id";
        var result = await connection.ExecuteAsync(sql, new { id });
        return result > 0 ? "Successfully delete" : "Failed";
    }

}
