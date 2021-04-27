using Newtonsoft.Json;
using SurveyCapstone.Areas.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyCapstone.Models
{
    public class Survey
    {
        public Survey()
        {
            Questions = new List<Question>();
            Responses = new List<Response>();
        }


        [Key]
        public int Id { get; set; }
        public string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Question> Questions { get; set; }

        public List<Response> Responses { get; set; }

    }
}