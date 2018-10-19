using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BetonApi.Extentions
{
    public static class StringExtetion
    {
        public static string Build(this  string urlSeg, Dictionary<string, string> dict)
        {
            var url = new StringBuilder(urlSeg);
            url.AppendFormat("?{0}", BuildRequestData(dict));

            return url.ToString();
        }

        internal static string BuildRequestData(IDictionary<string, string> dict, bool escape = true) => string.Join("&", dict.Select(kvp =>
                 string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));
    }
}
