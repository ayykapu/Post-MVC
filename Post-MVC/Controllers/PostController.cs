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

        public IActionResult Index()
        {
            return View(_postService.FindAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            Post model = new Post();
            model.Organizations = _postService
                .FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(model);
                return RedirectToAction("Index");
            }

            InitializeOrganizationsList(model);
            return View(model);
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
                model.Date = DateTime.Now;
                _postService.Update(model);
                return RedirectToAction("Index");
            }

            InitializeOrganizationsList(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_postService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Post model)
        {
            _postService.Delete(model.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_postService.FindById(id));
        }
        private void InitializeOrganizationsList(Post model)
        {
            model.Organizations = _postService
                .FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
        }
    }
}