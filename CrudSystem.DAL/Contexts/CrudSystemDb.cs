using CrudSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSystem.DAL.Contexts
{
    public class CrudSystemDb:DbContext
    {
        public CrudSystemDb(DbContextOptions<CrudSystemDb> Options):base(Options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
