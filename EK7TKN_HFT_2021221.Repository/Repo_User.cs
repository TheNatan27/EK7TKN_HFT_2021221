﻿using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class Repo_User : AbRepo<UserInformation>
    {
        public Repo_User(xDbContext Context) : base(Context)
        {
        }
    }
}