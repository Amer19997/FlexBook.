using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Exceptions;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
namespace FlexBook.Infrastructure.Services;
public class CacheService : ICacheService
{
    private readonly IMemoryCache _cache;
    private readonly AppSettings _appSettings;

    public CacheService(IMemoryCache cache, IOptions<AppSettings> appSettings)
    {
        _cache = cache;
        _appSettings = appSettings.Value;
    }

    public void AddAsync<T>(string prefix, string key, double? expirationTimeInMinutes, T value) where T : class
    {
        var options = new MemoryCacheEntryOptions();
        options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expirationTimeInMinutes ?? _appSettings.CacheSettings.ExpirationTimeInMinutes);
        var jsonData = JsonSerializer.Serialize(value);
        _cache.Set(prefix + key, jsonData, options);

    }
    public T GetAsync<T>(string prefix, string key, CancellationToken cancellationToken) where T : class
    {
        var cacheKey = prefix + key;
        _cache.TryGetValue(cacheKey , out object cachedValue);

        if (cachedValue is string jsonData)
        {
            try
            {
                // Deserialize the JSON data to the specified type

                return JsonSerializer.Deserialize<T>(jsonData);
            }
            catch (JsonException)
            {
                throw new SerializationException("deserialize-exception");
            }

        }

        else
        {
            return null;
        }
    }

    public void Delete(string prefix, string key)
    {
        var cacheKey = prefix + key;
        _cache.Remove(cacheKey);
    }



    //public async Task RefreshAsync(string prefix, string key)
    //{
    //    await _cache.RefreshAsync(prefix + key);
    //}
    //public async Task DeleteAsync(string prefix, string key)
    //{
    //    await _cache.RemoveAsync(prefix + key);
    //}

    //public T TryToGet<T>(string prefix, string key, out bool isExist) where T : class
    //{
    //    isExist = false;
    //    var jsonData = _cache.GetStringAsync(prefix + key).Result;

    //    if (jsonData is null)
    //        return default(T);
    //    try
    //    {
    //        isExist = true;
    //        return JsonSerializer.Deserialize<T>(jsonData);
    //    }
    //    catch
    //    {
    //        throw new SerializationException("deserialize-exception");
    //    }
    //}
}
