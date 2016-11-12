using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Chocolate.AspNetCore.Configuration.Consul.Parsers.Json
{
    internal static class JsonFlattener
    {
        internal static IDictionary<string, string> Flatten(this JObject jObject)
        {
            var jsonPrimitiveVisitor = new JsonPrimitiveVisitor();
            IDictionary<string, string> data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (KeyValuePair<string, string> primitive in jsonPrimitiveVisitor.VisitJObject(jObject))
            {
                if (data.ContainsKey(primitive.Key))
                {
                    throw new FormatException($"Key {primitive.Key} is duplicated in json");
                }
                data.Add(primitive);
            }
            return data;
        }
    }
}