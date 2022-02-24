using Microsoft.AspNetCore.Mvc;
using Mission8.Models;
using Mission8.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mission8.Controllers
{
    public class HomeController : Controller
    {
        private IMission7Repository repo { get; set; }
        public HomeController(IMission7Repository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            // Setting title and header for index page through layout page
            ViewBag.Title = "Bookstore";
            ViewBag.Header = "The Hilton Book Collection";

            // Preference for 10 books per page
            int pageSize = 10;

            //Setting both books queryable object and page navigation info objects to be passed to view
            var all_info = new BooksViewModel
            {
                Books = repo.Books
                    .Where(b => b.Category == bookCategory || bookCategory == null)
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategory == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(all_info);
        }
    }
}
