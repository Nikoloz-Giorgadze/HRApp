using ApplicationCQRS.Commands.EmployeeC;
using ApplicationDatabaseModels;
using ApplicationDatabaseModels.Models;
using ApplicationDomainCore.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApplicationCQRS.Handlers.EmployeesHandlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, bool>
    {
        private readonly IMapper _mapper = default;
        private readonly ApplicationDomainCore.Abstractions.IRepository<Employee> _repository = default;
        public AddEmployeeHandler(ApplicationDomainCore.Abstractions.IRepository<Employee> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }
        public async Task<bool> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var dataEmail = (await _repository.ReadAsync()).FirstOrDefault(d => d.Mail == request.EmployeeDto.Mail);
            var dataIdNumber = (await _repository.ReadAsync()).FirstOrDefault(d => d.IdentityNumber == request.EmployeeDto.IdentityNumber);
            if (dataEmail != default)
            {
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "This Email already exist" });
            }
            if(dataIdNumber != default)
            {
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "This Identity Number already exist" });
            }
            var employee = _mapper.Map<Employee>(request.EmployeeDto);
            return await _repository.CreateAsync(employee);
        }
    }
}
