using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk.Domain.Models;

namespace Wk.Infrastructure.Context
{
    public class WkContext : DbContext
    {
        public WkContext(DbContextOptions<WkContext> options) : base(options)
        {
        }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
    }
}
