using Microsoft.EntityFrameworkCore;
using studentslogbookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentslogbookAPI.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Dynamicalignment> dynamic { get; set; }

        public DbSet<Entry> entry { get; set; }

   
  }
}
