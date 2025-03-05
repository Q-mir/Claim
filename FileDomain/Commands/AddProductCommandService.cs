
using ProductDomain.Commands.Object;
using Service;

namespace ProductDomain.Commands;

public class AddProductCommandService : ICommandService<AddProductDTO>
{
    private readonly IProductRepository _repository;

    public AddProductCommandService(IProductRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        _repository = repository;
    }

    public void Execute(AddProductDTO obj)
    {
        if (obj.IsValid())
        {
            _repository.Add(obj);
        }
    }
}
