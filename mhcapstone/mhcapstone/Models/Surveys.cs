using mhcapstone.Areas.Data;
using mhcapstone.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mhcapstone.Models
{
    [Table("Surveys", Schema = "User")]
    public class Surveys : EntityBase
    {
        public string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }

        // How many users have taken the survey
        public int UserCount { get; set; }

        public String Title { get; set; }

        // Later Feature
        // public List<Category> { get; set;} 

        
    }
}
