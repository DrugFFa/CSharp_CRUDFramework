using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPP_SIBKMNET.Models;

namespace WebAPP_SIBKMNET.Context
{

    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<Region> Regions { get; set; }
    }

}
