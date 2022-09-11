using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Wk.Domain.Models;

namespace Wk.Infrastructure.Context
{
    public class WkDbContext : DbContext
    {
        public WkDbContext()
        {
        }

        public WkDbContext(DbContextOptions<WkDbContext> options) : base(options) { }


        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Produtos> Produtos { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile($"appsettings.json");

            var config = builder.Build();

            var str = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySql(str, ServerVersion.AutoDetect(str));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
