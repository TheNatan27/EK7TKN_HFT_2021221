using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Models
{
    [Table("Users")]
    public class UserInformation
    {
        [Key]
        public int UserID { get; set; }
        //public string First_Name { get; set; }
        //public string Last_Name { get; set; }
        //public int Age { get; set; }
        public double Weight { get; set; }
        //public double Height { get; set; }


    }

    
}
