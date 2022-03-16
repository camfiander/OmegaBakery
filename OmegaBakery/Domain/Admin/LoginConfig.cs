using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Admin
{
    internal class LoginConfig
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginConfig(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public LoginConfig()
        {
            Username = String.Empty;
            Password = String.Empty;
        }
    }
}
