using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.IntegrationServices;
using WebUI.Models.ProductUnit;
using WebUI.Models.Provider;
using WebUI.Models.Question;

namespace WebUI.Pages.ProductUnits
{
    [Authorize(Roles = SystemRoles.ViewProductUnitList + " , " + SystemRoles.SuperAdmin)]
    public class AddModel : PageModel
    {
        private readonly IProductUnitClient _productUnitClient;

        [BindProperty]
        public ProductUnitModel ProductUnitModel { get; set; }
        public AddModel(IProductUnitClient productUnitClient)
        {
            _productUnitClient = productUnitClient;
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await _productUnitClient.AddAsync(new AddProductUnitCommand()
            {
                NameAr= ProductUnitModel.NameAr,
                NameEn= ProductUnitModel.NameEn
            });
            return new JsonResult(result);
        }
    }
}
