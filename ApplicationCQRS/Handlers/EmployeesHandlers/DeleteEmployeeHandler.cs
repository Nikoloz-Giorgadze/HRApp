using Amazon.Runtime.Internal;
using ApplicationCQRS.Commands.EmployeeC;
using ApplicationDatabaseModels.Models;
using ApplicationDomainCore.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.EmployeesHandlers
{
    public class DeleteEmployeeHandler :IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IRepository<Employee> _repository = default;
        public DeleteEmployeeHandler(IRepository<Employee> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellation)
        {
            return await _repository.DeleteAsync(request.Id);    
        }
    }
}
