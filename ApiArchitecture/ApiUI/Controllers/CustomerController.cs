using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Customer;
using ServiceLayer.Services.Interfaces;

namespace ApiUI.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CustomerCreateDto dto)
        {
            await _service.InsertAsync(dto);

            return Ok();
        }
    }
}
