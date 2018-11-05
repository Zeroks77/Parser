using System;
using System.Collections.Generic;
using System.Text;

namespace MyParser
{
    class Hero
    {
        public Hero(string name, List<string> role, List<string> lane)
        {
            Name = name;
            Role = role;
            Lane = lane;
        }
        public string Name { get; set; }
        public List<string> Role { get; set; }
        public List<string> Lane { get; set; }
    }
}
