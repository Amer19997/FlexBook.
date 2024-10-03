using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Application.Common.Interfaces;
public interface IResourceService
{
    string GetError(string key);
    string GetInfo(string key);
    string GetMessage(string key);
    string GetError(string key, string culture);
    string GetInfo(string key, string culture);
    string GetMessage(string key, string culture);
}
