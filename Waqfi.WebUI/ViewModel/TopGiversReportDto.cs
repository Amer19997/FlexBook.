using WebUI.Client;

namespace WebUI.ViewModel;

public class TopGiversReportDto
{
    public int? PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<TopGiversItemItem> TopGiversList { get; set; }

}
