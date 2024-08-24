using System.Text.Json;

namespace StoreApp.Infrastructe.Extensions
{
    public static class SessionExtension
    {
        //Bu objeye bağlı çalışıyor
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        //bu da generic hali TypeSafe
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}
