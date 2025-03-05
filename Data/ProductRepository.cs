using Data.Tables;
using Microsoft.EntityFrameworkCore;
using ProductDomain;
using ProductDomain.Commands.Object;
using ProductDomain.Querys.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly Connection _connection;

        public ProductRepository(Connection connection)
        {
            ArgumentNullException.ThrowIfNull(connection);
            _connection = connection;
        }

        public void Add(AddProductDTO obj)
        {
            Product row = new Product()
            {
                Name = obj.Name,
                Count = obj.Count,
                Description = obj.Description,
                Price = obj.Price,
                ProductImage = obj.ImagePathes
                                  .Select(x => new ProductImage() { Path = x })
                                  .ToList()
            };
            _connection.Add(row);
            _connection.SaveChanges();

        }

        public List<CardProductDTO> GetCards(int start, int count)
        {
            var list = _connection.Products
                       .AsNoTracking()
                       .Include(row => row.ProductImage)
                       .Skip(start)
                       .Take(count);
            List<CardProductDTO> result = new List<CardProductDTO>();
            foreach (var row in list) 
            {
                CardProductDTO item = new CardProductDTO()
                {
                    Name = row.Name,
                    Id = row.Id
                };
                if(row.ProductImage != null && row.ProductImage.Count >= 1)
                {
                    item.ImagePath = row.ProductImage.First().Path;
                }
                result.Add(item);
            }
            return result;
        }
    }
}
