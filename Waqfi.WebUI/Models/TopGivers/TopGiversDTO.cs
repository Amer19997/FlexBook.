using WebUI.Client;

namespace WebUI.Models.TopGivers;

public class TopGiversDTO
{
    public int? PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<GetTopGiversListResult> TopGiversList { get; set; }

}
