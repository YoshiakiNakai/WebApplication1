using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class tcashController : Controller
    {
		public IActionResult Index()
		{
			return View();
		}

		public string hello()
		{
			return "hello tcash";
		}
	}
}