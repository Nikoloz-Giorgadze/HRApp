using ApplicationDatabaseModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderEnum Gender { get; set; }
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        public StatusEnum Status { get; set; }
        public string Position { get; set; }
        public DateTime? FiredDate { get; set; }
        public string Mobile { get; set; }
    }
}
