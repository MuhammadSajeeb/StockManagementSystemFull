using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Models
{
    public class SaleDetails
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal Qty { get; set; }
        public decimal Mrp { get; set; }
        public decimal TotalMrp { get; set; }
        public string Invoice { get; set; }
    }
}
