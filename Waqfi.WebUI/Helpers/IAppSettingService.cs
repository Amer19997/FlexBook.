namespace WebUI.Helpers;

public interface IAppSettingService
{
    int Pager_PageSize { get; }

    int Pager_MaxPages { get; }

    int Last_MaxPages { get; }

}
