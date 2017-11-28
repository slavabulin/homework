using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// You need to write a function AddOrChangeUrlParameter(url, keyValueParameter) that can manipulate URL parameters. It should be able to
    /// add a parameter to an existing URL, but also to change a parameter if it already exists. Example:AddOrChangeUrlParameter("www.example.com",
    /// "key=value") => 'www.example.com?key=value'(adds a parameter).AddOrChangeUrlParameter("www.example.com?key=value", "key2=value2") => 
    /// 'www.example.com?key=value&key2=value2' (adds another parameter).AddOrChangeUrlParameter("www.example.com?key=oldValue", "key=newValue" ) => 
    /// 'www.example.com?key=newValue'(changes the parameter).
    /// /// </summary>

    class Task3
    {
        static void Main(string[] args)
        {
        }
    }

    public class URLEditor
    {
        /// <summary>
        /// Method that adds params to url if it doesnt contain it or chnges it if it does. Params assumed to be case sensetive
        /// </summary>
        /// <param name="url">incomming url with params</param>
        /// <param name="keyValParam">params to add or change</param>
        /// <returns>url with new params</returns>
        public string AddOrChangeUrlParameter(string url, string keyValParam)
        {
            if (url == null) throw new ArgumentNullException(nameof(url), "argument should not be null");
            
            if (String.IsNullOrWhiteSpace(keyValParam)) return url;

            string[] urlArr = url.Split('?');
            string[] paramArr = keyValParam.Split('&');

            string domainName = urlArr[0];

            var urlParamDict = new Dictionary<string, string>();
            string[] urlParamArr ;

            if (urlArr.Length >1)
            {
                urlParamArr = urlArr[1].Split('&');
            }
            else
            {
                urlParamArr = new string[] { };
            }

            foreach(string keyValStr in urlParamArr)
            {
                string[] tmpStrArr = keyValStr.Split('=');
                urlParamDict.Add(tmpStrArr[0], tmpStrArr.ElementAt(1));
            }
            foreach(string keyVal in paramArr)
            {
                string[] tmpStrArr = keyVal.Split('=');
                urlParamDict[tmpStrArr[0]] = tmpStrArr[1];
            }

            var sb = new StringBuilder();
            sb.Append(domainName + "?");
            foreach(KeyValuePair<string,string> keyVal in urlParamDict)
            {
                sb.Append(keyVal.Key + '=' + keyVal.Value);
                sb.Append("&");
            }
            return sb.Remove(sb.Length-1,1).ToString();
        }
    }
}
