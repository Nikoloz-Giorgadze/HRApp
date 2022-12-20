using Amazon.Runtime.Internal;
using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCQRS.Queries
{
    public class ReadEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }
}
