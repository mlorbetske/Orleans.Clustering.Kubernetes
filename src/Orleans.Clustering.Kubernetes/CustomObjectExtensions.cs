using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace Orleans.Clustering.Kubernetes
{
    internal static class CustomObjectExtensions
    {
        public static T[] ConvertCustomObjectItems<T>(this object source)
            where T : class
        {
            if (source is JObject o)
            {
                return o?["items"]?.ToObject<T[]>();
            }
            else if (source is JsonElement e && e.TryGetProperty("items", out var items))
            {
                return items.Deserialize<T[]>();
            }

            return null;
        }

        public static T ConvertCustomObject<T>(this object source)
            where T : class
        {
            if (source is JObject o)
            {
                return o?.ToObject<T>();
            }
            else if (source is JsonElement e)
            {
                return e.Deserialize<T>();
            }

            return null;
        }
    }
}
