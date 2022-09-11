using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk.Domain.Interfaces;
using Wk.Infrastructure.Context;

namespace Wk.Infrastructure.Repository
{
    public class UOW : IUOW
    {
        private readonly WkDbContext _context;

        public UOW(WkDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
