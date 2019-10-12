using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    //DBコンテキストクラスの作成
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}