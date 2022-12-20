using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCQRS.Commands.EmployeeC
{
    public  class DeleteEmployeeCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
