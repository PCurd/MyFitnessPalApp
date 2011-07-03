using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace MyFitnessLibrary.Network
{
    public class Login
    {
        HttpWebRequest request;
        HttpWebResponse response;
        CookieContainer cookies;

        public Login(LoginDetails Details)
        {
            RunLogin(Details.Username, Details.Password);
        }

        public Login(string Username, string Password)
        {
            RunLogin(Username,Password);
        }

        public void RunLogin(string Username, string Password)
        {
            string url = string.Format("http://www.myfitnesspal.com/account/login");
            request = (HttpWebRequest)WebRequest.Create(url);

            request.AllowAutoRedirect = false;
            request.CookieContainer = new CookieContainer();
 
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string NewValue = string.Format("username={0}&password={1}&remember_me=1",Username,Password);
            request.ContentLength = NewValue.Length;
            // Write the request
            StreamWriter stOut = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(NewValue);
            stOut.Close();
            // Do the request to get the response
            response = (HttpWebResponse)request.GetResponse();
            StreamReader stIn = new StreamReader(response.GetResponseStream());

            string strResponse = stIn.ReadToEnd();
            stIn.Close();


            cookies = request.CookieContainer;
            response.Close();
        }

        public string ReadPage(string URL)
        {
            request = (HttpWebRequest)WebRequest.Create(URL);
            request.AllowAutoRedirect = false;
            request.CookieContainer = cookies;
            response = (HttpWebResponse)request.GetResponse();

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