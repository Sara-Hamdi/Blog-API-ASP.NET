using Blog.Data;
using Blog.Models;
using Blog.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts =await  _context.Posts.Include(p=>p.Comments).ToListAsync();
           

            return  Ok(posts);
        }
        [HttpGet]
        [Route("{id=guid}")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            var post = await _context.Posts.Include(x => x.Comments).Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (post!=null)
            {
                return Ok(post);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
    
        public async Task<IActionResult>AddPost(PostDTO postDTO)
        {
            var post = new Post()
            {
                Title = postDTO.Title,
                Content = postDTO.Content,
                Author = postDTO.Author,
                PublishedDate = postDTO.PublishedDate,
                UpdatedDate =postDTO.UpdatedDate

            };
            post.Id = Guid.NewGuid();
           await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPostById), new {id=post.Id},post );
        }
        [HttpPut]
        [Route("{id=guid}")]
        public async Task<IActionResult> EditPost([FromRoute] Guid id,[FromBody]PostDTO postDTO)
        {
            
            var post =await _context.Posts.FindAsync(id);
            if(post!=null)
            {
                post.Author = postDTO.Author;
                post.PublishedDate = postDTO.PublishedDate;
                post.UpdatedDate = postDTO.UpdatedDate;
                post.Content = postDTO.Content;
                post.Title = postDTO.Title;
               await _context.SaveChangesAsync();
                return Ok(post);
                    
            }
            else
            {
                return NotFound();
            }
                


        }
        [HttpDelete]
        [Route("{id=guid}")]
        public async Task<IActionResult> DeletePost([FromRoute]Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if(post!=null)
            {
                 _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return Ok(post);
            }
            else
            {
                return NotFound();
            }

        }
        
    }
}
