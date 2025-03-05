using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class Product
    {
        [Key,Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required, Range(0,double.MaxValue)]
        public double Price { get; set; }

        [Required, Range(0,double.MaxValue)]
        public int Count { get; set; }
        public ICollection<ProductImage> ProductImage { get; set; }
    }
}
