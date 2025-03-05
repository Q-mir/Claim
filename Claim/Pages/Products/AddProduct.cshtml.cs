using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductDomain.Commands.Object;
using ProductDomain.Querys.Objects;
using Service;

namespace Claim.Pages.Products
{
    public class AddProductModel : PageModel
    {
        private readonly IQueryService<SaveFiles, List<string>> _saveFile;
        private readonly ICommandService<AddProductDTO> _saveInDb;
        public AddProductModel(IQueryService<SaveFiles, List<string>> saveFile, ICommandService<AddProductDTO> saveInDb)
        {
            ArgumentNullException.ThrowIfNull(saveFile);
            ArgumentNullException.ThrowIfNull(saveInDb);
            _saveFile = saveFile;
            _saveInDb = saveInDb;
        }

        [BindProperty]
        public AddProductDTO Input { get; set; }

        [BindProperty]
        public IEnumerable<IFormFile> FormFiles { get; set; }
        public void OnGet()
        {
           
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<string> path = _saveFile.Execute(new SaveFiles() { Files = FormFiles});
            Input.ImagePathes = path;
            _saveInDb.Execute(Input);
            return RedirectToPage("/Index");
        }
    }
}
