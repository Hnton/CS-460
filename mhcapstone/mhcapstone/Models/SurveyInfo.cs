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
    [Table("SurveyInfo", Schema = "User")]
    public class SurveyInfo : EntityBase
    {
        public String Questions { get; set; }

        public String Answers { get; set; }
        
        [Required]
        public int SurveysID { get; set; }

        [ForeignKey(nameof(SurveysID))]
        public Surveys Surveys { get; set; }

    }
}