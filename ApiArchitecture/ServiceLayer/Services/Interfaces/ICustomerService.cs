using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.DTOs.Customer;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerListDto>> GetAllAsync();
    }
}
