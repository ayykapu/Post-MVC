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

        [AllowAnonymous]
        public IActionResult Index(int tagId = 0)
        {
            ViewBag.TagId = tagId;
            if (tagId == 0)
                return View(_postService.FindAll());
            else
                return View(_postService.FindByTag(tagId));
        }

        [AllowAnonymous]

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

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(model);
                return RedirectToAction("PagedIndex");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_postService.FindById(id));

        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Delete(Post model)
        {
            _postService.Delete(model.PostId);
            return RedirectToAction("PagedIndex");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_postService.FindById(id));
        }

        [Authorize(Roles = "admin")]
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

        [Authorize]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _postService.FindById(id);
            return model is null ? NotFound() : View(model);
        }

        
    }


}
