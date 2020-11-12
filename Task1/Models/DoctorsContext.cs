using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Models
{
    //این کلاس برای اینه که کلاس هایی که ایجاد کردیم به جداول مپ بشن
    public class DoctorsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);Database=DoctorsDB;Trusted_Connection=True;");
        }
        public DbSet<Doctor> doctors { get; set; }
    }
}
