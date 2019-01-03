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
            int i = 0;
            List<Hero> list = new List<Hero>();
            using (StreamReader Reader = new StreamReader(@".\test.csv"))
            {
                string line;
                while ((line = Reader.ReadLine()) != null)
                {
                    list.Add(Parse(line));

                }
                foreach (var item in list)
                {

                    Console.WriteLine(item.Name);
                    foreach (var lane in item.Lane)
                    {
                        Console.WriteLine($"    Plays at {lane}");
                    }
                    foreach (var Role in item.Role)
                    {
                        Console.WriteLine($"    As {Role}");
                    }
                    Console.WriteLine("\n");
                }

                Console.ReadLine();
            }
        }
        static Hero Parse(string input)
        {
            var hero = Grammar.Hero.Parse(input);


            return hero;


        }
    }
}

