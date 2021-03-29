using mhcapstone.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mhcapstone.Areas.Data
{
    [Table("Users", Schema = "User")]
    public class User : IdentityUser
    {
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        public System.DateTime BirthDate { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [InverseProperty(nameof(Surveys.User))]
        public List<Surveys> Survey { get; set; }
    }
}
