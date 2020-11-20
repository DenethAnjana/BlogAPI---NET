using BlogAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.DatabaseContext
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> option):base(option)
        {
                
        }

        public DbSet<Post> Posts { get; set; }
    }
}
