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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public string Email { get; set; }
        public virtual ICollection<RunInformation> runInfo{ get; set; }


       
        public override string ToString()
        {
            return $"Id : {UserID} \n Name: {First_Name + Last_Name} \n Age: {Age} \n Weight: {Weight} \n Height: {Height} \n Email: {Email}";
        }

    }

    
}
