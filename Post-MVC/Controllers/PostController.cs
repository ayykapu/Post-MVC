using Microsoft.AspNetCore.Mvc;
using Post.Models;

namespace Post.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View(_postService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PostClass model)
        {
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Now;
                _postService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_postService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(PostClass model)
        {
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Now;
                _postService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_postService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(PostClass model)
        {
            _postService.Delete(model.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_postService.FindById(id));
        }
    }
}