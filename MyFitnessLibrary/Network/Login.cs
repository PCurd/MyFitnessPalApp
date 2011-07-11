using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace MyFitnessLibrary.Network
{
    public class Login
    {
        //HttpWebRequest request;
        //HttpWebResponse response;
        CookieContainer cookies;
        string Authenticity_Token;

        public Login(LoginDetails Details)
        {
            Exception exc = null;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    RunLogin(Details.Username, Details.Password);
                    return;
                }
                catch (Exception ex)
                {
                    //**TODO Exception handling
                    exc = ex;
                }
            }
            if (exc != null)
                throw new OperationCanceledException(string.Format("Login Failed due to repeated 500 errors - {0}", exc.Message));
        }


        private void RunLogin(string Username, string Password)
        {
            //Load page
            //extract authenticity_token
            //make POST


            // preg_match("/input name=\"authenticity_token\" type=\"hidden\" value=\"(.*?)\"/", $page, $authenticity_token);


            string url = string.Format("http://www.myfitnesspal.com/account/login");


            var request = (HttpWebRequest)WebRequest.Create(url);

            request.AllowAutoRedirect = false;
            request.CookieContainer = new CookieContainer();


            //do GET first
            string result;

            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
                result = sr.ReadToEnd();
                sr.Close();
                //     response.Close();
            }

            Regex match = new Regex("input name=\"authenticity_token\" type=\"hidden\" value=\"(.*?)\"");
            Authenticity_Token = match.Match(result).Groups[1].Value;

            cookies = request.CookieContainer;



            request = (HttpWebRequest)WebRequest.Create(url);

            request.AllowAutoRedirect = false;


            request.CookieContainer = cookies;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string NewValue = string.Format("authenticity_token={2}&username={0}&password={1}&remember_me=1", Username, Password, Authenticity_Token);
            request.ContentLength = NewValue.Length;
            request.Referer = url;
            // Write the request
            StreamWriter stOut = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(NewValue);
            stOut.Close();
            // Do the request to get the response
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                StreamReader stIn = new StreamReader(response.GetResponseStream());

                string strResponse = stIn.ReadToEnd();
                stIn.Close();

                cookies = request.CookieContainer;
            }

        }

        public string ReadPage(string URL)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.AllowAutoRedirect = false;
            request.CookieContainer = cookies;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                string line = "";
                using (Stream s = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(s);

                    while (!sr.EndOfStream)
                    {
                        line += sr.ReadLine();
                    }
                }
                return line;
            }
        }
    }
}