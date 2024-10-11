using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Domain.Entities.Catalog.Dtos;
public class AuthResponseDto
{
    public string Token { get; set; }
    public UserProfileDto UserProfile { get; set; }

}
