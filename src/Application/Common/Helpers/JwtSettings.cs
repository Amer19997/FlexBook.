using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Application.Common.Helpers;
public class JwtSettings
{
    public string JwtEncryptionKey { get; set; } 
    public string Audience { get; set; } 
    public string Issuer { get; set; } 

    public double JwtExpireAfterMinutes { get; set; }
}
