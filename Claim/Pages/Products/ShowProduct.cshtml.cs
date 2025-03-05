using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductDomain.Querys.Objects;
using Service;

namespace Claim.Pages.Products;

public class ShowProductModel : PageModel
{
    private readonly IQueryService<SearchCardProduct, List<CardProductDTO>> _getProductQueryService;

    public ShowProductModel(IQueryService<SearchCardProduct, List<CardProductDTO>> getProductQueryService)
    {
        ArgumentNullException.ThrowIfNull(getProductQueryService);
        _getProductQueryService = getProductQueryService;
    }

    public List<CardProductDTO> Elements { get; set; }

    public void OnGet(int start = 1, int count = 3)
    {
        Elements = _getProductQueryService.Execute(new SearchCardProduct() { Start = start - 1, Count = count });

    }
}
