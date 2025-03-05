using Microsoft.AspNetCore.Http;
using Service;

namespace ProductDomain.Querys.Objects;

public class SaveFiles : IQuery
{
    public IEnumerable<IFormFile> Files { get; set; }

}
