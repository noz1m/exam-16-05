using Dapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class UserService : IUserService
{

    private readonly DataContext context = new DataContext();
    public async Task<List<User>> GetAllUserAsync()
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from users";
        var result = await connection.QueryAsync<User>(sql);
        return result.ToList();
    }
    public async Task<string> CreateUserAsync(User user)
    {
        using var connection = await context.GetConnection();
        var sql = @"insert into users(userName,email,fullName,registrationDate)
                    values (@userName,@email,@fullName,@registrationDate)";
        var result = await connection.ExecuteAsync(sql, user);
        return result > 0 ? "Successfully created" : "Failed";
    }
    public async Task<User?> GetUserByIdAsync(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from users where id = @id";
        var result = await connection.QueryFirstOrDefaultAsync(sql, new {id});
        return result == null ? null : result;
    }
    public async Task<string> UpdateUserAsync(User user)
    {
        using var connection = await context.GetConnection();
        var sql = @"update users set (userName=@userName,email=@email,fullName=@fullName,RegistrationDate=@RegistrationDate)
                    where id = @id";
        var result = await connection.ExecuteAsync(sql, user);
        return result > 0 ? "Successfully update" : "Failed";
    }
    public async Task<string> DeleteUserAsync(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"delete from users where id = @id";
        var result = await connection.ExecuteAsync(sql, new { id });
        return result > 0 ? "Successfully delete" : "Failed";
    }
}
