using Domain.Entities;
using Infrastructure.Interface;
using Infrastructure.Data;
using Dapper;

namespace Infrastructure.Service;

public class PostService : IPostService
{
    private readonly DataContext context = new DataContext();
    public async Task<List<Post>> GetAllPost()
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from posts";
        var result = await connection.QueryAsync<Post>(sql);
        return result.ToList();
    }
    public async Task<string> CreatePost(Post post)
    {
        using var connection = await context.GetConnection();
        var sql = @"insert into users(userId,context,creationDate,likesCount)
                    values (@userId,@context,@creationDate,@likesCount)";
        var result = await connection.ExecuteAsync(sql, post);
        return result > 0 ? "Successfully created" : "Failed";
    }
    public async Task<Post?> GetPostById(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from posts where id = @id";
        var result = await connection.QueryFirstOrDefaultAsync(sql, new {id});
        return result == null ? null : result;
    }
    public async Task<string> UpdatePost(Post post)
    {
        using var connection = await context.GetConnection();
        var sql = @"update users set (userId=@userId,context=@context,creationDate=@creationDate,likesCount=@likesCount)
                    where id = @id";
        var result = await connection.ExecuteAsync(sql, post);
        return result > 0 ? "Successfully update" : "Failed";
    }
    public async Task<string> DeletePost(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"delete from posts where id = @id";
        var result = await connection.ExecuteAsync(sql, new { id });
        return result > 0 ? "Successfully delete" : "Failed";
    }
}
