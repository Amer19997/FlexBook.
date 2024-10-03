using WebUI.Client;

namespace WebUI.Models.News;

public class NewsViewModal
{
    public Guid NewsId { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? SummaryAr { get; set; }
    public string? SummaryEn { get; set; }
    public string? DetailsAr { get; set; }
    public string? DetailsEn { get; set; }
    public string? StatusNameAr { get; set; }
    public string? StatusNameEn { get; set; }
    public string? PublishDate { get; set; }

}

public class NewsList
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<NewsViewModal> NewsViewModals { get; set; } = new();
}
public class filterNewsDto
{
    public string? Title { get; set; }
    public NewsStatus? Status { get; set; }
}
