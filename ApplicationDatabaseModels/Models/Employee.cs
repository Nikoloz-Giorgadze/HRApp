using ApplicationDatabaseModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDatabaseModels.Models
{
    public class Employee : Base
    {
        [StringLength(11)]
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        [Required]
        public string Position { get; set; }
        public DateTime? FiredDate { get; set; }
        public string Mobile { get; set; }
    }
}
