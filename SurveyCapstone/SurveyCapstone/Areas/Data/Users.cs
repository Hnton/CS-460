using Microsoft.AspNetCore.Identity;
using SurveyCapstone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyCapstone.Areas.Data
{
    public class Users : IdentityUser 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [InverseProperty(nameof(Survey.User))]
        public List<Survey> Surveys { get; set; }
    }
}
