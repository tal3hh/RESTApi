using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Customer;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CustomerListDto>> GetAllAsync()
        {
            var model = await _repo.GetAllAsync();

            return _mapper.Map<List<CustomerListDto>>(model);
        }

        public async Task InsertAsync(CustomerCreateDto dto)
        {
            await _repo.CreateAsync(_mapper.Map<Customer>(dto));
        }
    }
}
