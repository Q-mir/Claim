using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Claim.Pages
{
    [Authorize(Policy = "Authorization")]
    public class Page1Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
