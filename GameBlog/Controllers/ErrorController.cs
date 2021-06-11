using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GameBlog.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(IEnumerable<string> errors = null)
        {
            Response.StatusCode = 404;

            return errors != null ? View(errors) : View();
        }
    }
}