using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Models
{
    [Table("Users")]
    public class UserInformation : IModelClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }
        public string full_Name { get; set; }
        public int age { get; set; }
        public double weight { get; set; }
        public int height { get; set; }
        public string email { get; set; }
        public bool premium { get; set; }
        [JsonIgnore]
        public virtual ICollection<RunInformation> runInfo{ get; set; }



        public override string ToString()
        {
            return $"Id : {userID} \n Name: {full_Name.Trim()} \n Age: {age} \n Weight: {weight} \n Height: {height} \n Email: {email.Trim()}";

        }

    }

    
}
