using System;
using System.Collections.Generic;
using System.Text;

namespace iTaxApp
{
    public class User
    {
        public string function { get; set; }
        public string ID { get; set; }
        public string password { get; set; }
        public string sessionKey { get; set; }
        public User(string uname, string pass)
        {
            ID = uname;
            password = pass;
        }
    }
}
