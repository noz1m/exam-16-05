using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Domain.Entities;

namespace Webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController
{
    IPostService postService = new PostService();

    [HttpGet]
    public async Task<List<Post>> GetAllPost()
    {
        return await postService.GetAllPost();
    }
    [HttpPost]
    public async Task<string> CreatePost(Post post)
    {
        return await postService.CreatePost(post);
    }
    [HttpPut]
    public async Task<string> UpdatePost(Post post)
    {
        return await postService.UpdatePost(post);
    }
    [HttpDelete("{id:int}")]
    public async Task<string> DeletePost(int id)
    {
        return await postService.DeletePost(id);
    }
}
