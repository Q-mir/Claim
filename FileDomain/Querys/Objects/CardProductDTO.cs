using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDomain.Querys.Objects;

public class CardProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}
