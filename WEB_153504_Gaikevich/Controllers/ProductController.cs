using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEB_153504_Gaikevich.Domain.Entities;
using WEB_153504_Gaikevich.Services.AutoPartService;
using WEB_153504_Gaikevich.Services.CategoryService;
using WEB_153504_Gaikevich.Domain.Models;

namespace WEB_153504_Gaikevich.Controllers
{
    public class ProductController : Controller
    {
        IAutoPartService _autoPartService;
        ICategoryService _categoryService;

        public ProductController(IAutoPartService autoPartService, ICategoryService categoryService)
        {
            _autoPartService = autoPartService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string category, int pageno = 1)
        {
            var productResponse = await _autoPartService.GetProductListAsync(category, pageno);
            var categoryResponse = await _categoryService.GetCategoryListAsync();

            if (!productResponse.Success)
            {
                return NotFound(productResponse.ErrorMessage);
            }

            ViewData["Category"] = string.IsNullOrEmpty(category) ? "Все" : categoryResponse.Data.Find(c => c.NormalizedName == category)?.Name ?? "Все";
            ViewData["Categories"] = categoryResponse.Data;

            var model = productResponse.Data;

            return View(model);
        }
    }
}

