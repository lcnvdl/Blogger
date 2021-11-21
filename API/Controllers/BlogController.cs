using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class BlogController : BaseController
    {
        private readonly DataContext _dataContext;
        public BlogController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Blog>>> GetBlogs()
        {
            return await _dataContext.Blogs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(Guid id)
        {
            return await _dataContext.Blogs.FindAsync(id);
        }
    }
}