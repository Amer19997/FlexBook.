using System.ComponentModel.DataAnnotations;
using WebUI.Models.Provider;

namespace WebUI.Models.TopGivers;

public class TopGiversSearch
{
    public string? Name { get; set; }
    public string? phone { get; set; }
   public ProviderProductsDTO providerProducts { get; set; }
}
