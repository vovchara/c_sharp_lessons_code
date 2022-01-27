using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopLib.Model
{
    public class UserCredModel
    {
        public string Name { get; }
        public string Password { get; }

        public UserCredModel(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
