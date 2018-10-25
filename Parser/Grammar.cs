using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Sprache;

namespace MyParser
{
    static class Grammar
    {
        static readonly Parser<char> splitHere = Parse.Char(';'); 

        public static readonly Parser<string> input =
            (from content in Parse.AnyChar.Except(splitHere).Many().Text()
             select content).Token();

        public static readonly Parser<string> input2 =
           (from split in splitHere
            from Role in Parse.AnyChar.Except(splitHere).Many().Text()
            select Role).Token();

        public static readonly Parser<Hero> Hero =
            from Name in input
            from Role in input2
            select new Hero(Name, Role);
    }
}
