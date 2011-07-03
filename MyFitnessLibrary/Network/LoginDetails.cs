using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using MyFitnessLibrary.XML;

namespace MyFitnessLibrary.Network
{
    public class LoginDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginDetails()
        {
        }

        public LoginDetails(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }


    }
}
