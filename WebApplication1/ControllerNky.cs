using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1
{
	public class ControllerNky : Controller
	{
		//// GET: /<controller>/
		//public IActionResult Index()
		//{
		//	return View();
		//}

		// /ControllerNky/hello
		public string hello()
		{
			return "This is my default action HelloWorld!!";
			// コントローラでreturnした値がレスポンスされる
			// コントローラでは値のみを扱い、レンダリングなど装飾はViewで行う。
		}

		//
		// /ControllerNky/disp?a=ame&b=bin
		public string disp(string a, string b)
		{
			return a + b;
		}

		// /ControllerNky/welcome?name=nnnn&loop=5
		public IActionResult welcome(string name, int loop = 1)
		{
			ViewData["Message"] = "Hello " + name;
			ViewData["loop"] = loop;
			// ViewDataは連想配列、動的オブジェクト、ただの代入で動的にデータを格納できる。

			return View();
			//
		}
	}
}
