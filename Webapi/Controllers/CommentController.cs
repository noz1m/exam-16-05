using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Domain.Entities;
namespace Webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController
{
    ICommentService commentService = new CommentService();

    [HttpGet]
    public async Task<List<Comment>> GetAllComment()
    {
        return await commentService.GetAllComment();
    }
    [HttpPost]
    public async Task<string> CreateComment(Comment comment)
    {
        return await commentService.CreateComment(comment);
    }
    [HttpPut]
    public async Task<string> UpdateComment(Comment comment)
    {
        return await commentService.UpdateComment(comment);
    }
    [HttpDelete("{id:int}")]
    public async Task<string> DeleteComment(int id)
    {
        return await commentService.DeleteComment(id);
    }
}
