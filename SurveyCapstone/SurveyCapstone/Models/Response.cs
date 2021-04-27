using SurveyCapstone.Areas.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyCapstone.Models
{
    public class Response
    {
        [Key]
        public int Id { get; set; }
        public int SurveyId { get; set; }

        public Survey Survey { get; set; }

        public string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Answer> Answers { get; set; }  
    }
}