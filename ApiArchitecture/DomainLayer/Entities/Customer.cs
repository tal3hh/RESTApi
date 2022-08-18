using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Common;

namespace DomainLayer.Entities
{
    public class Customer : BaseEntity
    {
        public string Fullname { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
    }
}
