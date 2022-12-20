using ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace ApplicationCQRS.Commands.EmployeeC
{
    public class AddEmployeeCommand:IRequest<bool>
    {
        public EmployeeDto EmployeeDto { get; set; }
        public string UserName { get; set; }
    }
}
