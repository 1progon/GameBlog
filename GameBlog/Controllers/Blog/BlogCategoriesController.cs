using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameBlog.Models;
using GameBlog.Models.Blog;
using GameBlog.Repositories;
using GameBlog.ViewModel.Blog;

namespace GameBlog.Controllers.Blog
{
    [Route("blog/categories")]
    public class BlogCategoriesController : Controller
    {
        private readonly IGenericRepository<Category> _repoCats;
        private readonly IGenericRepository<Post> _repoPosts;

        public BlogCategoriesController(
            IGenericRepository<Category> repoCats,
            IGenericRepository<Post> repoPosts
        )
        {
            _repoCats = repoCats;
            _repoPosts = repoPosts;
        }

        [Route("")]
        public async Task<IActionResult> Index([FromQuery] int pageN = 1)
        {
            var includes = new List<Expression<Func<Category, object>>>
            {
                c => c.Author,
                c => c.Posts
            };
            var count = _repoCats.Count();
            if (count <= 0)
                return RedirectToAction("Index", "Error",
                    new {errors = "Нет записей"});

            var pagination = new Pagination(count, pageN, ControllerContext.ActionDescriptor.ControllerName);

            var categories = await _repoCats.GetAllAsync(includes);
            categories = categories.Skip((pageN - 1) * pagination.PageSize).Take(pagination.PageSize);

            var viewModel = new BlogCategoryIndexViewModel
            {
                BlogCategories = categories,
                Pagination = pagination
            };


            return View(viewModel);
        }

        [Route("{slug}")]
        public async Task<IActionResult> Show([FromRoute] string slug, [FromQuery] int pageN = 1)
        {
            var includes = new List<Expression<Func<Category, object>>>
            {
                c => c.Author,
                c => c.Posts
            };

            var category = await _repoCats.GetBySlugAsync(slug, includes);

            if (category == null)
                return RedirectToAction("Index", "Error",
                    new {errors = "Категория не найдена"});

            var count = category.Posts.Count();
            if (count <= 0)
                return RedirectToAction("Index", "Error",
                    new {errors = "Нет записей в категории"});

            var pagination = new Pagination(count, pageN, ControllerContext.ActionDescriptor.ControllerName,
                ControllerContext.ActionDescriptor.ActionName);

            category.Posts = category
                .Posts
                .Skip((pageN - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToList();

            var viewModel = new BlogCategoryShowViewModel
            {
                Category = category,
                BlogPosts = category.Posts,
                Pagination = pagination
            };

            return View(viewModel);
        }
    }
}