using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.Lookups;
using WebUI.Models.ProductUnit;

namespace WebUI.Pages.ProductCategory
{
    public class EditModel : PageModel
    {
        private readonly ILookUpClient _lookupClient;
        private readonly IMapper _mapper;

        [BindProperty]
        public ProductCategoryModel ProductCategoryModel { get; set; }
        public EditModel(ILookUpClient lookupClient, IMapper mapper)
        {
            _lookupClient = lookupClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
        {
            var result = await _lookupClient.GetProductCategoryAsync(id);
            if (result.Success)
                ProductCategoryModel = _mapper.Map<ProductCategoryModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _lookupClient.EditProductCategoryAsync(new EditProductCategoryCommand()
            {
                Id = ProductCategoryModel.Id,
                NameAr = ProductCategoryModel.NameAr,
                NameEn = ProductCategoryModel.NameEn
            });
            return new JsonResult(result);
        }

    }
}
