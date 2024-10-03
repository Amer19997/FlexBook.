using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.ProductUnit;

namespace WebUI.Pages.ProductUnits
{
    [Authorize(Roles = SystemRoles.ViewProductUnitList + " , " + SystemRoles.SuperAdmin)]
    public class EditModel : PageModel
    {
        private readonly IProductUnitClient _productUnitClient;
        private readonly IMapper _mapper;

        [BindProperty]
        public ProductUnitModel ProductUnitModel { get; set; }
        public EditModel(IProductUnitClient productUnitClient , IMapper mapper)
        {
            _productUnitClient = productUnitClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(Guid id)
        {
            var result = await _productUnitClient.ProductUnitGetAsync(id);
            if (result.Success)
                ProductUnitModel = _mapper.Map<ProductUnitModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _productUnitClient.EditAsync(new EditProductUnitCommand()
            {
                Id= ProductUnitModel.Id,
                NameAr = ProductUnitModel.NameAr,
                NameEn = ProductUnitModel.NameEn
            });
            return new JsonResult(result);
        }
        
    }
}
