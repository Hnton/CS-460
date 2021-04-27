using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyCapstone.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public List<Answer> Answers { get; set; }




      
    }
}