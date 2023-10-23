using Newtonsoft.Json;

namespace Rte2023Ddd.Test.Extensions;

public static class HttpResponseMessageExtensions
{
    public static async Task<T> DeserializeObject<T>(this HttpResponseMessage response)
    {
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(json);
    }
}