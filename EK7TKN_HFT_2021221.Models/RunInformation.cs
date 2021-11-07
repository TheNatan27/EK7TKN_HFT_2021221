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
    [Table("Runs")]
    public class RunInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RunID { get; set; }
        [ForeignKey(nameof(UserInformation))]
        public int UserID { get; set; }
        public virtual UserInformation userInfo { get; set; }
        public double Distance { get; set; }
        public string Time { get; set; }

        public override string ToString()
        {
            return $"Id: {UserID}, RunId: {RunID}, Time: {Time}, Distance: {Distance}";
        }


    }

    
}
