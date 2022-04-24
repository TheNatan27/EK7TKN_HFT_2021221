using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public interface IPassLogic 
    {
       
        public PasswordSecurity Read(int userId);

       
    }
}
