using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ServiceLayer.DTOs.Customer
{
    public class CustomerCreateDto
    {
        public string Fullname { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
    }


    public class CustomerCreateValidation : AbstractValidator<CustomerCreateDto>
    {
        public CustomerCreateValidation()
        {
            RuleFor(x => x.Fullname).NotEmpty().WithMessage("Ad ve soyad daxil edin.").MaximumLength(30);
        }
    }
}
