﻿using EK7TKN_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public abstract class AbRepo<T>
    {
        protected xDbContext context;
        public AbRepo(xDbContext Context)
        {
            context = Context;
        }
    }
}
