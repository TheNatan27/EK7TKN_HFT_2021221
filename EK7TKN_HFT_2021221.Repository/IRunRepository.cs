﻿using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public interface IRunRepository 
    {

        public void Create(string filename);
        public IQueryable<RunInformation> ReadAll();
    }
}
