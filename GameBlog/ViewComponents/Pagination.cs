using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameBlog.ViewModel;

namespace GameBlog.ViewComponents
{
    public class Pagination : ViewComponent
    {
        public IViewComponentResult Invoke(Models.Pagination pagination)
        {
            return View("Pagination", pagination);
        }
    }
}