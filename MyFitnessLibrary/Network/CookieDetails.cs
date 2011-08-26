using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using MyFitnessLibrary.XML;
using System.Xml.Serialization;

namespace MyFitnessLibrary.Network
{
    [Serializable]
    public class CookieDetails
    {
        [SoapElement]
        public CookieContainer Cookies { get; set; }
        [SoapElement]
        public CookieCollection cookieCollection { get { return Cookies.GetCookies(new Uri("http://www.myfitnesspal.com/account/login")); } set { Cookies.Add(value); } }

    }
}
