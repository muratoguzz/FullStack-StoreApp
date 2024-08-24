using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Store.Entities.Models;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.CategoryService.GetAllCategories(false);
            return View(model);
        }
    }
}