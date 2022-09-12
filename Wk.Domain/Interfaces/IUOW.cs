﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk.Domain.Interfaces
{
    public interface IUOW
    {
        void Dispose();
        int Commit();
        Task<int> CommitAsync();

    }
}
