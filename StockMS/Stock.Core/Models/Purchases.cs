using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Models
{
    public class Purchases
    {
        public int Id { get; set; }
        public int SuplierId { get; set; }
        public string Invoice { get; set; }

    }
}
