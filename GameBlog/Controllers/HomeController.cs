using System.Linq;
using GameBlog.Data;
using GameBlog.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GameBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var homepagePosts = _context
                .BlogPosts
                .OrderByDescending(post => post.CreatedAt)
                .Take(4).ToList();
            var viewModel = new HomepageViewModel()
            {
                BlogPosts = homepagePosts
            };

            return View(viewModel);
        }
    }
}