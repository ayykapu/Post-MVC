using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Post_MVC.Models;

namespace Post_MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int TagId = 0)
        {
            ViewBag.TagId = TagId;
            if (TagId == 0) 
            {
                return View(_postService.FindAll()); 
            }
            else 
            { 
                return View(_postService.FindByTag(TagId)); 
            }
               
        }
        public IActionResult PagedIndex(int tagId = 0, int page = 1, int size = 2)
        {
            List<Post> list = new List<Post>();
            if (tagId == 0)
                list = _postService.FindAll();
            else
                list = _postService.FindByTag(tagId);
            ViewBag.TagId = tagId;
            PagingList<Post> pagingList = _postService.FindPage(page, size, list);
            return View(pagingList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(post);
                return RedirectToAction("PagedIndex");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_postService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Update(model);
                return RedirectToAction("PagedIndex");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_postService.FindById(id));

        }

        [HttpPost]
        public IActionResult Delete(Post model)
        {
            _postService.Delete(model.PostId);
            return RedirectToAction("PagedIndex");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _postService.FindById(id);
            return model is null ? NotFound() : View(model);
        }

       
    }
}
