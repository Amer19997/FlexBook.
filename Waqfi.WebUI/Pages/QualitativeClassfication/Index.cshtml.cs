using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Client;
using WebUI.Helpers;

namespace WebUI.Pages.QualitativeClassfication
{
    public class IndexModel : PageModel
    {
        private readonly ILookUpClient _lookUpClient;

        public int PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalCount { get; set; }

        public DTOResult result;
        private readonly IAppSettingService _appSettingService;

        public IndexModel(ILookUpClient lookUpClient, IAppSettingService appSettingService)
        {
            _lookUpClient = lookUpClient;
            _appSettingService = appSettingService;
        }

        public async Task OnGet(int? p )
        {
            PageNumber = (p == 0 || p == null) ? 1 : p;
            var list = await _lookUpClient.GetQualitativeClassificationListAsync(PageNumber, _appSettingService.Pager_PageSize);
            TotalCount = list.Result.TotalCount;
            
            result = new DTOResult() { items= list.Result.Items.ToList(),PageNumber=((p == 0 || p == null) ? 1 : p), TotalCount=TotalCount,PageSize= _appSettingService.Pager_PageSize };
        }
        public async Task<PartialViewResult> OnPost(int? p)
        {
            PageNumber = (p == 0 || p == null) ? 1 : p;
            var list = await _lookUpClient.GetQualitativeClassificationListAsync(PageNumber, _appSettingService.Pager_PageSize);
            TotalCount = list.Result.TotalCount;

            result = new DTOResult() { items = list.Result.Items.ToList(), PageNumber = ((p == 0 || p == null) ? 1 : p), TotalCount = TotalCount, PageSize = _appSettingService.Pager_PageSize };

            return Partial("_List", result);
        }
        public async Task<ActionResult> OnPostDelete(Guid id)
        {
            var result = await _lookUpClient.DeleteQualitativeClassificationAsync(id);
            return new JsonResult(result);
        }
        #region helper
        public class DTOResult
        {
            public int PageSize { get; set; }
            public int? PageNumber { get; set; }
            public int TotalCount { get; set; }
            public List<GetQualitativeClassficationItemResult> items { get; set; }


        }
    }
    #endregion
}
    
