using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Apartment
{
    public class ApartmentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Floor { get; set; }
    }
}