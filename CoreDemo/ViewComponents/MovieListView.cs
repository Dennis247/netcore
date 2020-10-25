using CoreDemo.Models.Data.MvcMovie.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
    public class MovieListView : ViewComponent
    {
        private readonly MvcMovieContext _context;
        public MovieListView(MvcMovieContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var movieList = await _context.Movie.ToListAsync();
            return View(movieList);
        }
    }
}
