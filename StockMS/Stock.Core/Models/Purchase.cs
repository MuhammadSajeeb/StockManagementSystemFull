using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ManufacturedDate { get; set; }
        public string ExpireDate { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Mrp { get; set; }
        public string Invoice { get; set; }
    }
}
