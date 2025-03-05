using ProductDomain.Querys.Objects;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDomain.Querys
{
    public class SearchCardProductQueryService : IQueryService<SearchCardProduct, List<CardProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public SearchCardProductQueryService(IProductRepository productRepository)
        {
            ArgumentNullException.ThrowIfNull(productRepository);
            _productRepository = productRepository;
        }

        List<CardProductDTO> IQueryService<SearchCardProduct, List<CardProductDTO>>.Execute(SearchCardProduct obj)
        {
            if (obj.Count > 10) obj.Count = 3;
            if (obj.Start < 0) obj.Start = 0;
            return _productRepository.GetCards(obj.Start, obj.Count);
        }
    }
}
