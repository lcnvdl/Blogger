using Application.Blogs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BlogController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Blog>>> GetBlogs()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(Guid id)
        {
            return await Mediator.Send(new Detail.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blog blog)
        {
            return Ok(await Mediator.Send(new Create.Command { Blog = blog }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(Blog blog)
        {
            return Ok(await Mediator.Send(new Update.Command { Blog = blog }));
        }
    }
}