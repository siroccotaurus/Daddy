using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragonsWeb.Models.Database
{
    public class User
    {
        string email;
        string password;

        public User() { }
        public User(string email, string password):this()
        {
            this.email = email;
            this.password = password;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
