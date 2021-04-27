using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyCapstone.Models
{
    public class ReportViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Survey Survey { get; set; }
        public List<QuestionViewModel> Responses { get; set; }
    }

    public class QuestionViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }
        public List<Answer> Answers { get; set; }

       
    }
}