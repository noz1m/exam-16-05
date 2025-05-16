using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Domain.Entities;

namespace Webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController
{
    IUserService userService = new UserService();

    [HttpGet]
    public async Task<List<User>> GetAllUserAsync()
    {
        return await userService.GetAllUserAsync();
    }
    [HttpGet("{id:int}")]
    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await userService.GetUserByIdAsync(id);
    }
    [HttpPost]
    public async Task<string> CreateUserAsync(User user)
    {
        return await userService.CreateUserAsync(user);
    }
    [HttpPut]
    public async Task<string> UpdateUserAsync(User user)
    {
        return await userService.UpdateUserAsync(user);
    }
    [HttpDelete("{id:int}")]
    public async Task<string> DeleteUserAsync(int id)
    {
        return await userService.DeleteUserAsync(id);
    }
}
