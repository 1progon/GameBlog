using System;

namespace GameBlog.Models
{
    public class Pagination
    {
        public Pagination(int count, int pageN, string controllerName, string actionName = "Index", int pageSize = 15)
        {
            PageN = pageN;
            PageSize = pageSize;
            ActionName = actionName;
            ControllerName = controllerName;
            TotalPages = (int) Math.Ceiling((double) count / pageSize);
        }

        public int PageN { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }

        public string ActionName { get; set; }
        public string ControllerName { get; set; }


        public bool HasPreviousPage => PageN > 1;
        public bool HasNextPage => PageN < TotalPages;
    }
}