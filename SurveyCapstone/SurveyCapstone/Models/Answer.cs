﻿using SurveyCapstone.Areas.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyCapstone.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }

        public int ResponseId { get; set; }

        public Response Response { get; set; }

        public int QuestionId { get; set; }

        public string Value { get; set; }

        public string Comment { get; set; }

        public Question Question { get; set; }


    }
}