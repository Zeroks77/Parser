using System;
using System.Collections.Generic;
using System.Text;

namespace MyParser
{
    class Hero
    {
        public Hero(string name, string role)
        {
            Name = name;
            Role = role;
        }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
