using ProductDomain.Commands.Object;
using ProductDomain.Querys.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDomain;

public interface IProductRepository
{
    void Add(AddProductDTO obj);

    List<CardProductDTO> GetCards(int start, int count); 
}
