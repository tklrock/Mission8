using Microsoft.AspNetCore.Mvc;
using Mission8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        public IMission7Repository repo { get; set; }
        public CategoriesViewComponent (IMission7Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
