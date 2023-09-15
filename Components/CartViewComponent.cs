using System;
using Microsoft.AspNetCore.Mvc;

namespace WEB_153504_Gaikevich
{
	public class CartViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

