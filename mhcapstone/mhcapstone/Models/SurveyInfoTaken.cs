using mhcapstone.Areas.Data;
using mhcapstone.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mhcapstone.Models
{
    [Table("SurveyInfoTaken", Schema = "User")]
    public class SurveyInfoTaken : EntityBase
    {
        public string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
        public String Questions { get; set; }

        public String Answers { get; set; }
        
        public int SurveysId { get; set; }

    }
}