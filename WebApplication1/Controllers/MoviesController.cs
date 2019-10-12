using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;


namespace WebApplication1.Controllers
{
	[AutoValidateAntiforgeryToken]  //ワンタイムCSRFトークンを自動で生成してくれる。cshtmlに記載の必要なし。//http://mrgchr.hatenablog.com/entry/2016/11/16/000000
	public class MoviesController : Controller
	{
		private readonly MvcMovieContext _context;

		public MoviesController(MvcMovieContext context)
		{
			_context = context;
		}

		//ルート-------------------------
		//movieデータを返す
		[Route("/Movies")]
		// GET: Movies
		public async Task<ViewResult> Index()
		{
			return View(await _context.Movie.ToListAsync());
		}

		//Detail-------------------------
		//Detailページを表示する
		//指定したidのmovieデータをDetailViewへ渡す
		//引数1：movieのid
		[Route("/Movies/Details/{*id}")]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var movie = await _context.Movie
				.FirstOrDefaultAsync(m => m.Id == id);
			if (movie == null)
			{
				return NotFound();
			}

			return View(movie);
		}

		//Create-------------------------
		//Createページを表示する
		[Route("/Movies/Create")]
		public IActionResult Create()
		{
			return View("/Views/Movies/Create.cshtml");
		}
		
		//DBにデータを追加する
		[HttpPost]  //Postメソッド
		[Route("/Movies/Create")]
		//[IgnoreAntiforgeryToken]	//CSRFトークンを無視する
		public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
		{
			if (ModelState.IsValid)
			{
				_context.Add(movie);	//DBへ登録
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));	//リダイレクト
			}
			//無効のとき
			return View(movie);	//Createページを表示する
		}

		//Edit--------------------------
		//Editページを表示する
		//指定したidのmovieをEditViewへ渡す
		//引数1：movieのid
		[Route("/Movies/Edit/{*id}")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var movie = await _context.Movie.FindAsync(id);
			if (movie == null)
			{
				return NotFound();
			}
			return View(movie);
		}

		//DBのデータを変更する
		[HttpPost]
		[Route("/Movies/Edit/{*id}")]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
		{
			if (id != movie.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(movie);	//データの更新
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)	//DBエラー処理
				{
					if (!MovieExists(movie.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));	//リダイレクト
			}
			//無効のとき
			return View(movie);	//Editページの表示
		}

		//Delete-----------------------
		[Route("/Movies/Delete/{*id}")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var movie = await _context.Movie
				.FirstOrDefaultAsync(m => m.Id == id);
			if (movie == null)
			{
				return NotFound();
			}

			return View(movie);
		}
		[HttpPost, ActionName("Delete")]
		[Route("/Movies/Delete/{*id}")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var movie = await _context.Movie.FindAsync(id);
			_context.Movie.Remove(movie);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		private bool MovieExists(int id)
		{
			return _context.Movie.Any(e => e.Id == id);
		}
	}
}