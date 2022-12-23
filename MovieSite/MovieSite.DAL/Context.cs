using Microsoft.EntityFrameworkCore;
using MovieSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.DAL
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> db) : base(db)
        {

        }
        public DbSet<Movie> Movie { get; set; }

       
        

    }
}
