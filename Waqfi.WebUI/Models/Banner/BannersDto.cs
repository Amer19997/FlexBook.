using WebUI.Client;

namespace WebUI.Models.Banner;

public class BannersDto
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<BannerDto> BanneritemsDto { get; set; }
}

