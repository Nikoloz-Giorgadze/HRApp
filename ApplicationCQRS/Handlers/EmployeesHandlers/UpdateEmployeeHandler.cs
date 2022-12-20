using ApplicationCQRS.Commands.EmployeeC;
using ApplicationDatabaseModels.Models;
using ApplicationDomainCore.Abstractions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApplicationCQRS.Handlers.EmployeesHandlers
{

    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<Employee> _repository = default;

        public UpdateEmployeeHandler(IRepository<Employee> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.ReadByIdAsync(request.Id);
            var NewEmployee = _mapper.Map<Employee>(request.Employee);
            var dataEmail = (await _repository.ReadAsync()).FirstOrDefault(d => d.Mail == request.Employee.Mail);
            var dataIdNumber = (await _repository.ReadAsync()).FirstOrDefault(d => d.IdentityNumber == request.Employee.IdentityNumber);
            if (dataEmail != default && employee.Mail != dataEmail.Mail)
            {
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "This Email already exist" });
            }
            if (dataIdNumber != default && employee.IdentityNumber != dataIdNumber.IdentityNumber)
            {
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "This Identity number already exist" });
            }
            return await _repository.UpdateAsync(request.Id, NewEmployee);

        }
    }

}
