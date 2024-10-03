using System.Runtime.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace WebUI.IntegrationServices;

public class CacheService 
{
    private readonly IDistributedCache _cache;
    private readonly IConfiguration _configuration;
    private readonly int _chacheExpirationTimeInMinutes;

    public CacheService(IDistributedCache cache, IConfiguration configuration)
    {
        _cache = cache;
        _configuration = configuration;
        _chacheExpirationTimeInMinutes = _configuration.GetSection("AppSettings").GetValue<int>("ChacheExpirationTimeInMinutes");
    }

    public async Task AddAsync<T>(string prefix, string key, double? expirationTimeInMinutes, T value) where T : class
    {
        var options = new DistributedCacheEntryOptions();
        options.SlidingExpiration = TimeSpan.FromMinutes(expirationTimeInMinutes ?? _chacheExpirationTimeInMinutes);
        var jsonData = JsonSerializer.Serialize(value);
        await _cache.SetStringAsync(prefix + key, jsonData, options);

    }
    public async Task<T> GetAsync<T>(string prefix, string key) where T : class
    {
        var jsonData = await _cache.GetStringAsync(prefix + key);

        if (jsonData is null)
            return default(T);
        try
        {
            return JsonSerializer.Deserialize<T>(jsonData);
        }
        catch
        {
            throw new SerializationException("deserialize-exception");
        }
    }




    public async Task RefreshAsync(string prefix, string key)
    {
        await _cache.RefreshAsync(prefix + key);
    }
    public async Task DeleteAsync(string prefix, string key)
    {
        await _cache.RemoveAsync(prefix + key);
    }

    public T TryToGet<T>(string prefix, string key, out bool isExist) where T : class
    {
        isExist = false;
        var jsonData = _cache.GetStringAsync(prefix + key).Result;

        if (jsonData is null)
            return default(T);
        try
        {
            isExist = true;
            return JsonSerializer.Deserialize<T>(jsonData);
        }
        catch
        {
            throw new SerializationException("deserialize-exception");
        }
    }
}
