using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public int CategoriesId { get; set; }

    }
}
