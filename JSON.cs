using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.IO.Compression;


    public class JSON
    {
        public static string ToJSON(object obj)
        {
            var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = jsonSerializer.Serialize(obj);
            return json;
        }

        public static object FromJSON(string json, Type type)
        {
            var jsondeserializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return jsondeserializer.Deserialize(json, type);
        }
        public static string ToJSONWebEncoded(object obj) 
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(ToJSON(obj)));
        }

        public static object FromJSONWebDecoded(string webEncodedJson, Type type)
        {
            return FromJSON(Encoding.ASCII.GetString(Convert.FromBase64String(webEncodedJson)), type);
        }


    }
