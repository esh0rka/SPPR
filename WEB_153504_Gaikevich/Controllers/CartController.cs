using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_153504_Gaikevich.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Add(int id, string returnUrl)
        {
            return Redirect(returnUrl);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

