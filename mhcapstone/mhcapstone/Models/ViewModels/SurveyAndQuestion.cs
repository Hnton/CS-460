using mhcapstone.Areas.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mhcapstone.Models.ViewModels
{
    public class SurveyAndQuestion
    {
        public String Title { get; set; }

        public string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }

        public String Questions { get; set; }

        public String Answers { get; set; }

        public int SurveysId { get; set; }

    }
}
