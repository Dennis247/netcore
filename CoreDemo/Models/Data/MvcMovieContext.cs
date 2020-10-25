using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models.Data
{
    using Microsoft.EntityFrameworkCore;
  
    namespace MvcMovie.Data
    {
        public class MvcMovieContext : DbContext
        {
            public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
                : base(options)
            {
            }

            public DbSet<Movie> Movie { get; set; }
        }
    }
}
