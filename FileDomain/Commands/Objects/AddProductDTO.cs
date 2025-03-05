using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDomain.Commands.Object;

public class AddProductDTO
{
    [MinLength(4, ErrorMessage = "min 4")]
    public string Name { get; set; } = null!;

    [Range(1, double.MaxValue, ErrorMessage = "min 1 rub.")]
    public double Price { get; set; }

    [MinLength(1, ErrorMessage = "min 1")]
    public string Description { get; set; } = null!;
    public int Count { get; set; }
    public List<string> ImagePathes { get; set; } = new List<string>();

    public bool IsValid()
    {
        return Name.Length > 3 && Price > 0 && Description.Length > 0;
    }
}
