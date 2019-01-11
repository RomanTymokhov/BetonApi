using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace BetonApi.Extentions
{
    public static class StringExtetion
    {
        internal static string Build(this  string urlSeg, Dictionary<string, string> dict) =>
            new StringBuilder(urlSeg).AppendFormat("?{0}", BuildRequestData(dict)).ToString();

        internal static string BuildRequestData(IDictionary<string, string> dict, bool escape = true) => string.Join("&", dict.Select(kvp =>
            string.Format("{0}={1}", kvp.Key, escape ? System.Net.WebUtility.UrlEncode(kvp.Value) : kvp.Value)));
    }
}
