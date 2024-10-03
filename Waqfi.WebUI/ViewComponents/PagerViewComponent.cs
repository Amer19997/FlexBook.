using Microsoft.AspNetCore.Mvc;
using WebUI.Helpers;

namespace WebUI.ViewComponents;

public class PagerViewComponent : ViewComponent
{
    private readonly IAppSettingService _appSettingService;

    public PagerViewComponent(IAppSettingService appSettingService)
    {
        _appSettingService = appSettingService;
    }

    public IViewComponentResult Invoke(int totalItemsCount, int currentPage,int size = 10)
    {
        var pagination = new Pagination(totalItemsCount, currentPage, size, _appSettingService.Pager_MaxPages,_appSettingService.Last_MaxPages);

        return View(pagination);

    }
}
