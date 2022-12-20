using ApplicationCQRS.Queries;
using ApplicationDatabaseModels.Models;
using ApplicationDomainCore.Abstractions;
using ApplicationDtos;
using AutoMapper;
using MediatR;

namespace ApplicationCQRS.Handlers.EmployeesHandlers
{
    public class EmployeeDTo
    {
        public class ReadAllEmployeeHandler : IRequestHandler<ReadAllEmployeeQuery, IEnumerable<EmployeeDto>>
        {
            private readonly IMapper _mapper = default;
            private readonly IRepository<Employee> _repository = default;
           

            public ReadAllEmployeeHandler(IRepository<Employee> repository, IMapper mapper)
            {
                _mapper = mapper;
                _repository = repository;
                
            }

            public async Task<IEnumerable<EmployeeDto>> Handle(ReadAllEmployeeQuery request, CancellationToken cancellationToken)
            {
               
                var data = await _repository.ReadAsync();
                
                return _mapper.Map<List<EmployeeDto>>(data);
            }
        }
    }
}