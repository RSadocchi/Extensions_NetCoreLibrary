using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Extensions.Serialization.Json
{
    public static class Extensions
    {
        public static string SerializeToJson<T>(this T obj) where T : Type, new()
        {
            string rtn = string.Empty;
            using (var ms = new MemoryStream())
            {
                var dcs = new DataContractJsonSerializer(typeof(T));
                dcs.WriteObject(ms, obj);
                using (var sr = new StreamReader(ms))
                {
                    rtn = sr.ToString();
                }
            }
            return rtn;
        }

        public static T DeserializeFromJson<T>(this string json) where T : Type, new()
        {
            var obj = new T();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var dcs = new DataContractJsonSerializer(typeof(T));
                obj = (T)dcs.ReadObject(ms);
            }
            return obj;
        }
    }
}
