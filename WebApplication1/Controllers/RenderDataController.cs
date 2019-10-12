using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class RenderDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		//Viewへのデータの渡し方三種類
		//https://qiita.com/dongsu-iis/items/5f830381aa8796421f67
		//ViewModelを使う方法が推奨されている。

		//ViewData
		public IActionResult ViewDataDemo()
		{
			ViewData["title"] = "ViewData Demo";
			ViewData["name"] = "dongsu";
			ViewData["birthday"] = new DateTime(2000, 3, 10);
			ViewData["hobby"] = new string[] { "筋トレ", "映画鑑賞", "Coding" };
			return View();
		}
		//ViewBag
		public IActionResult ViewBagDemo()
		{
			ViewBag.title = "ViewBag Demo";
			ViewBag.name = "dongsu";
			ViewBag.birthday = new DateTime(2000, 3, 10);
			ViewBag.hobby = new string[] { "筋トレ", "映画鑑賞", "Coding" };
			return View();
		}
		//ViewModel
		public IActionResult ViewModelDemo()
		{
			ViewBag.title = "ViewModel Demo";
			var person = new Models.Person
			{
				Name = "dongsu",
				Birthday = new DateTime(2000, 3, 10),
				Hobby = new string[] { "筋トレ", "映画鑑賞", "Coding" }

			};
			return View(person);
		}
	}


}