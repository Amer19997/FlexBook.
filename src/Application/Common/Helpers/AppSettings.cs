using Microsoft.Extensions.Configuration;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Common.Helpers;
public class AppSettings
{
    public CacheSettings CacheSettings { get; set; }
    public JwtSettings JwtSettings { get; set; }
    public FileSettings FileSettings { get; set; }
    public Smtp Smtp { get; set; }
    public string AllowedHostsTest { get; set; }
    public bool HostValidation { get; set; }

}
