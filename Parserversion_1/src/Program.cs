using System;
using System.IO;
using System.Text;
using System.IO.Pipes;
using System.Linq;
using System.Collections.Generic;
using Sprache;

namespace MyParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            Console.WriteLine("Main Role für 10 Helden");
            obj.loadfile();

        }
        public void loadfile()
        {

            List<string> list = new List<string>();
            using (StreamReader Reader = new StreamReader(@".\test.csv"))
            {
                string line;
                while ((line = Reader.ReadLine()) != null)
                {
                    list.Add(Parse(line));
                }
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();
            }
        }
        static string Parse(string input)
        {
            var hero = Grammar.Hero.Parse(input);
            return $"The Hero {hero.Name} plays mostly as {hero.Role}";

        }
    }
}

