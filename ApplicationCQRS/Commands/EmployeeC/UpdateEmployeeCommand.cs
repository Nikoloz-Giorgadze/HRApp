using ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ApplicationCQRS.Commands.EmployeeC
{
    public class UpdateEmployeeCommand:IRequest<bool>
    {
        public EmployeeDto Employee { get; set; }
        public int Id { get; set; }
    }
}
