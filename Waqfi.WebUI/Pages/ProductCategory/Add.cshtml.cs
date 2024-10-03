using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.Lookups;

namespace WebUI.Pages.ProductCategory
{
    public class AddModel : PageModel
    {
        private readonly ILookUpClient _lookupClient;

        [BindProperty]
        public ProductCategoryModel ProductCategoryModel { get; set; }
        public AddModel(ILookUpClient lookupClient)
        {
            _lookupClient = lookupClient;
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookupClient.AddProductCategoryAsync(new AddProductCategoryCommand()
            {
                NameAr = ProductCategoryModel.NameAr,
                NameEn = ProductCategoryModel.NameEn
            });
            return new JsonResult(result);
        }
    }
}
