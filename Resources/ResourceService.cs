using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Interfaces;

namespace Resources;
public class ResourceService : IResourceService
{
    public string GetError(string key)
    {
        var resourceManger = new ResourceManager(typeof(Error));
        return resourceManger.GetString(key);
    }

    public string GetInfo(string key)
    {
        var resourceManger = new ResourceManager(typeof(Info));
        return resourceManger.GetString(key);
    }

    public string GetMessage(string key)
    {
        var resourceManger = new ResourceManager(typeof(Message));
        return resourceManger.GetString(key);
    }

    public string GetError(string key, string culture = "ar-SA")
    {
        var resourceManger = new ResourceManager(typeof(Error));
        return resourceManger.GetString(key, new System.Globalization.CultureInfo(culture));
    }

    public string GetInfo(string key, string culture = "ar-SA")
    {
        var resourceManger = new ResourceManager(typeof(Info));
        return resourceManger.GetString(key, new System.Globalization.CultureInfo(culture));
    }

    public string GetMessage(string key, string culture = "ar-SA")
    {
        var resourceManger = new ResourceManager(typeof(Message));
        return resourceManger.GetString(key, new System.Globalization.CultureInfo(culture));
    }
}
