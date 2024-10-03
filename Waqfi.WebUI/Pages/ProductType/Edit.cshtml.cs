using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Models.City;
using WebUI.Models.FirstSubclass;
using WebUI.Models.Gender;
using WebUI.Models.GovernanceClassification;
using WebUI.Models.ProductType;

namespace WebUI.Pages.ProductType
{
    public class EditModel : PageModel
    {
        public ILookUpClient lookUpClient { get; set; }
        private readonly IMapper _mapper;

        [BindProperty]
        public ProductTypeModel ProductType { get; set; }

        public EditModel(ILookUpClient lookUpClient, IMapper mapper)
        {
            this.lookUpClient = lookUpClient;
            _mapper = mapper;
        }
        public async Task OnGetAsync(int id)
        {
            var result = await lookUpClient.GetProductTypeByIdCmsAsync(id);

            if (result.Success)
                ProductType = _mapper.Map<ProductTypeModel>(result.Result);
        }
        public async Task<JsonResult> OnPostAsync()
        {
            var result = await lookUpClient.EditProductTypeCmsAsync(new EditProductTypeCommand()
            {
                Id = ProductType.Id,
                NameAr = ProductType.NameAr,
                NameEn = ProductType.NameEn,
            });
            return new JsonResult(result);
        }
    }
}
