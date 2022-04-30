using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace _0_Framework.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pid">کد پترن</param>
    /// <param name="tnum">شماره مقصد</param>
    /// <param name="p">نام متغیر</param>
    /// <param name="v">مقدار متغیر</param>
    /// <returns></returns>
    public static class SendPattern
    {
        public static string SendSms(string pid, string tnum, string p, string v)
        {
            WebRequest _request;

            string fnum = "983000505";

            _request = WebRequest.Create("http://ippanel.com:8080/?apikey=dVmGH6ywlDxRlEQj_HdStH_Ss91PQXruAqMW-DIJgSg=&pid=" + pid + "&fnum=" + fnum + "&tnum=" + tnum + "&" + p + v);

            _request.ContentType = "application/x-www-form-urlencoded";

            WebResponse response = _request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            response.Close();
            return response.ToString();

        }
    }
}
