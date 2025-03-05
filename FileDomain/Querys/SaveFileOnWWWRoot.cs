using ProductDomain.Querys.Objects;
using Service;
namespace ProductDomain.Querys
{
    public class SaveFileOnWWWRoot : IQueryService<SaveFiles, List<string>>
    {
        public List<string> Execute(SaveFiles obj)
        {
            List<string> result = new List<string>();
            foreach (var file in obj.Files)
            {
                string name = $"{Guid.NewGuid()}.jpg";
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", name);

                using(FileStream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                result.Add(name);
            }
            return result;
        }
    }
}
