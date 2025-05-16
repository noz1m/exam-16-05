using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Domain.Entities;
namespace Webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikeController
{
    ILikeService likeService = new LikeService();

    [HttpGet]
    public async Task<List<Like>> GetAllLike()
    {
        return await likeService.GetAllLike();
    }

    [HttpPost]
    public async Task<string> CreateLike(Like like)
    {
        return await likeService.CreateLike(like);
    }
    [HttpPut]
    public async Task<string> UpdateLike(Like like)
    {
        return await likeService.UpdateLike(like);
    }
    [HttpDelete]
    public async Task<string> DeleteLike(int id)
    {
        return await likeService.DeleteLike(id);
    }
}
