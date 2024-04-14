using DataBase.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class AppDbContext : DbContext
    {
        IConfiguration _configuration;
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_configuration.GetConnectionString("ConnectionString"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CommentDbModel>().Property(c => c.Id).UseIdentityColumn(100000);
            //modelBuilder.Entity<UserDbModel>().Property(u => u.Id).UseIdentityColumn(100000);
            base.OnModelCreating(modelBuilder);
        }
            
        public DbSet<UserDbModel> UserDbModels { get; set; }
        public DbSet<CommentDbModel> CommentDbModels { get; set; }
        public DbSet<ReportDbModel> ReportDbModels { get; set; }
    }
}
