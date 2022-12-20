using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCQRS.Queries
{
    public class ReadAllEmployeeQuery:IRequest<IEnumerable<EmployeeDto>>
    {
        public string Username { get; set; }
    }
}
