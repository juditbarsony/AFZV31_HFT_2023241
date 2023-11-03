using Codefrist.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codefrist.Data
{
    internal class AnnualDbContext : DbContext
    {

        public DbSet<Annual> Annuals { get; set; }
        public DbSet<Area> Areas { get; set; }
        public AnnualDbContext(DbSet<Annual> annuals, DbSet<Area> areas)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
                AttachDbFilename=|DataDirectory|\movies.mdf;Integrated Security=True;MultipleActiveResultSets=true";

                builder
                   .UseSqlServer(conn);
                   //.UseInMemoryDatabase("marvel")
                   //.UseLazyLoadingProxies();
            }
        }


    }
}
