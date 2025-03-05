using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public ICollection<Product> Product{ get; set; }
    }
}
