using ApplicationDatabaseModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDatabaseConnector.DB
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext() { }
        public DbSet<Employee> Employees {get;set;}
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=DESKTOP-4J81V5K\MSSQLSERVER01;Database=HRApp;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}
