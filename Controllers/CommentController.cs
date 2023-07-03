using Blog.Data;
using Blog.Models;
using Blog.Models.DTO;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult>AddComment(CommentDTO commentDTO)
        {
            var isValidPostID = await _context.Posts.AnyAsync(p => p.Id == commentDTO.PostId);
            if(!isValidPostID)
            {
                return BadRequest(error: "this post doesn't exist");
            }

            var comment = new Comment()
            {
                Author=commentDTO.Author,
                Content=commentDTO.Content,
                PostId=commentDTO.PostId,
                PublishedDate=commentDTO.PublishedDate,
            };
           
            await  _context.Commments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return Ok(comment);

        }
        
       
        [HttpDelete]
        [Route("{id=guid}")]
        public async Task<IActionResult>DeleteComment([FromRoute]Guid id)
        {
            var comment = await _context.Commments.FindAsync(id);
            if(comment!=null)
            {
                _context.Commments.Remove(comment);
                await _context.SaveChangesAsync();
                return Ok(comment);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
