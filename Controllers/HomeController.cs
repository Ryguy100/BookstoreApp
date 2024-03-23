using BookstoreApp.Models;
using BookstoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookstoreApp.Controllers
{
    // Main controller for the application
    public class HomeController : Controller
    { 
        private IBookRepo _bookRepo;

        public HomeController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public IActionResult Index(int paginationNum)
        {
            int itemsOnPage = 10;

            // Creating variable to gather all the information
            var pagination = new BookListViewModel
            {
                Books = _bookRepo.Books
                .Skip((paginationNum - 1) * itemsOnPage)
                .Take(itemsOnPage),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = paginationNum,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = _bookRepo.Books.Count()
                }
            };

            return View(pagination);
        }
    }
}
