using Data;
using Microsoft.AspNetCore.Mvc;

namespace Post_MVC.Controllers.ControllersAPI
{
    [Route("api/tags")]
    [ApiController]
    public class TagApi : ControllerBase
    {
        private readonly AppDbContext _context;
        public TagApi(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult GetAllTags()
        {
            var tags = _context.Tags.Select(o => new { id = o.TagId, TagTitle = o.TagTitle }).ToList();
            return Ok(tags);
        }
    }
}
