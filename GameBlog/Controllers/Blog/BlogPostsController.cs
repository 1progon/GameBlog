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
    [Route("blog")]
    public class BlogPostsController : Controller
    {
        private readonly IGenericRepository<Post> _repoPosts;

        public BlogPostsController(IGenericRepository<Post> repoPosts)
        {
            _repoPosts = repoPosts;
        }

        [Route("all-posts")]
        public async Task<IActionResult> Index([FromQuery] int pageN = 1)
        {
            var count = _repoPosts.Count();
            if (count <= 0)
            {
                return RedirectToAction("Index", "Error",
                    new {errors = "No posts"});
            }

            var pagination = new Pagination(count, pageN, ControllerContext.ActionDescriptor.ControllerName);

            var includes = new List<Expression<Func<Post, object>>>
            {
                p => p.Author,
                p => p.Category
            };
            var posts = await _repoPosts.GetAllAsync(includes);
            posts = posts.Skip((pageN - 1) * pagination.PageSize).Take(pagination.PageSize).OrderByDescending(p => p.CreatedAt);

            var viewModel = new BlogPostIndexViewModel
            {
                BlogPosts = posts,
                Pagination = pagination
            };

            return View(viewModel);
        }

        // Get Show page with slug
        [Route("{postSlug}")]
        public async Task<IActionResult> Show([FromRoute] string postSlug)
        {
            var includes = new List<Expression<Func<Post, object>>>
            {
                p => p.Author,
                p => p.Category,
                p => p.BlogPostImages
            };
            var post = await _repoPosts.GetBySlugAsync(postSlug, includes);
            if (post == null)
                return RedirectToAction("Index", "Error",
                    new {errors = "No post"});


            var viewModel = new BlogPostShowViewModel
            {
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                MetaDescription = post.MetaDescription,
                MetaKeywords = post.MetaKeywords,
                Name = post.Name,
                Slug = post.Slug,
                Description = post.Description,
                Article = post.Article,
                BlogPostImages = post.BlogPostImages,
                Category = post.Category,
                Author = post.Author,
                Views = post.Views,
                Image = post.Image
            };
            return View(viewModel);
        }
    }
}