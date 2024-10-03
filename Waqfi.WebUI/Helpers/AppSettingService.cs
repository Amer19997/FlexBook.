namespace WebUI.Helpers;

public class AppSettingService : IAppSettingService
{
    private readonly IConfiguration _configuration;

    public AppSettingService(IConfiguration configuration)
    {
        _configuration = configuration;
        var settings = _configuration.GetSection("AppSettings");

        _pagerPageSize = settings.GetValue<int>("PageSize");
        _pagerMaxPages = settings.GetValue<int>("MaxPages");
        _last_MaxPages = settings.GetValue<int>("LastMaxPages");
    }

    private readonly int _pagerPageSize;

    public new int Pager_PageSize
    {
        get { return _pagerPageSize; }
    }

    private readonly int _pagerMaxPages;

    public new int Pager_MaxPages
    {
        get { return _pagerMaxPages; }
    }
    private readonly int _last_MaxPages;
    public new int Last_MaxPages
    {
        get { return _last_MaxPages; }
    }
}
