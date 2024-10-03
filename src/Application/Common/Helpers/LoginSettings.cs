using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Application.Common.Helpers;
public class LoginSettings
{
    public int Attempts { get; set; }
    public DateTime FromTime { get; set; }
    public int BlockingMinutes { get; set; }
    public int ExpirationTimeInMinutes { get; set; }
}
