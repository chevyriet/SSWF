﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB_EF
{
    public interface ISeedData
    {
        Task EnsurePopulated(bool dropExisting = false);
    }
}
