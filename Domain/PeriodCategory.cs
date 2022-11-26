using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class PeriodCategory
    {
        public Guid PeriodId { get; set; }
        public Period Period { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public double Amount { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}