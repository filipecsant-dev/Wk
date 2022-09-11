using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wk.Infrastructure.Context;

namespace Wk.Infrastructure.Repository
{
    public class UOW
    {
        private readonly WkContext _context;

        public UOW(WkContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
