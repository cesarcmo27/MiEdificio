using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Receipt
    {
        public Guid PeriodId { get; set; }
        public Period Period { get; set; }

        public Guid ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public double Amount { get; set; }
        public double AmountClient { get; set; }
        public string Observation { get; set; }
    }
}