using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace CleanArchitecture.Application.Common;

/// <summary>
/// Contains extensions methods to work with IDistributedCache provider.
/// </summary>
public static class DistributedCacheExtensions
{
    /// <summary>
    /// Sets a value in the cache as byte[], string, or using JSON serialization depending on type of TValue
    /// </summary>
    /// <param name="cache">Cache</param>
    /// <param name="key">Key</param>
    /// <param name="value">Value</param>
    /// <param name="expiration">Expiration</param>
    public static void SetAutoJson<TValue>(this IDistributedCache cache, string key, TValue value, TimeSpan? expiration = default)
        where TValue : class
    {
        var options = new DistributedCacheEntryOptions();
        if (expiration.HasValue && expiration.Value > TimeSpan.Zero)
            options.SetAbsoluteExpiration(expiration.Value);

        if (value is string s)
            cache.Set(key, Encoding.UTF8.GetBytes(s), options);
        else if (value is byte[] b)
            cache.Set(key, b, options);
        else
            cache.SetString(key, JsonSerializer.Serialize(value), options);
    }

    public static async Task SetAutoJsonAsync<TValue>(this IDistributedCache cache, string key, TValue value, TimeSpan? expiration = default, CancellationToken cancellationToken = default)
    where TValue : class
    {
        ArgumentNullException.ThrowIfNull(cache);

        var options = new DistributedCacheEntryOptions();
        if (expiration.HasValue && expiration.Value > TimeSpan.Zero)
            options.SetAbsoluteExpiration(expiration.Value);

        if (value is string stringValue)
            await cache.SetAsync(key, Encoding.UTF8.GetBytes(stringValue), options, cancellationToken);
        else if (value is byte[] bytesValue)
            await cache.SetAsync(key, bytesValue, options, cancellationToken);
        else
            await cache.SetStringAsync(key, JsonSerializer.Serialize(value), options, cancellationToken);
    }

    /// <summary>
    /// Sets a value from the cache as byte[], string, or using JSON deserialization depending on type
    /// </summary>
    /// <param name="cache">Cache</param>
    /// <param name="key">Key</param>
    public static TValue? GetAutoJson<TValue>(this IDistributedCache cache, string key)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(cache);

        var b = cache.Get(key);
        if (b == null)
            return null;

        if (typeof(TValue) == typeof(byte[]))
            return (TValue)(object)b;

        var s = Encoding.UTF8.GetString(b);
        if (typeof(TValue) == typeof(string))
            return (TValue)(object)s;

        return JsonSerializer.Deserialize<TValue>(s);
    }
}