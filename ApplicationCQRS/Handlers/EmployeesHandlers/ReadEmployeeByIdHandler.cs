using ApplicationCQRS.Queries;
using ApplicationDatabaseModels.Models;
using ApplicationDomainCore.Abstractions;
using ApplicationDtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCQRS.Handlers.EmployeesHandlers.EmployeeDTo;

namespace ApplicationCQRS.Handlers.EmployeesHandlers
{
    public class ReadEmployeeByIdHandler : IRequestHandler<ReadEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<Employee> _repository = default;

        public ReadEmployeeByIdHandler(IRepository<Employee> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<EmployeeDto> Handle(ReadEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.ReadByIdAsync(request.Id);

            return _mapper.Map<EmployeeDto>(data);
        }
    }
}
