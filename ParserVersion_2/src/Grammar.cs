using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Sprache;

namespace MyParser
{
    static class Grammar
    {
        static readonly Parser<char> splitHere = Parse.Char(';');
        static readonly Parser<char> separator = Parse.Char('|');
        static readonly Parser<char> ws = Parse.Char(' ');
        static readonly char[] searchfor = {' ','|',' '};

        public static readonly Parser<string> input =
            (from content in Parse.AnyChar.Except(splitHere).Many().Text().Named("Heroname") //Heldenname
             select content).Token();

       
        public static readonly Parser<List<string>> input2 = //Rolle des Helden in Liste
           (from content in Parse.AnyChar.Except(splitHere).Many().Text()
            //from Role in Cell
            from Lane in Cell
            select new List<string>(Lane));

        static readonly Parser<List<string>> separat =
            from first in Parse.AnyChar.Except(ws).Many().Text()
            from sep in Parse.Chars(searchfor).Many().Text()
            from second in Parse.AnyChar.Except(ws).Except(separator).Many().Text()
            from sep2 in Parse.Chars(searchfor).Many().Text()
            from third in Parse.AnyChar.Except(splitHere).Many().Text()
            select (new List<string> { first, second, third }).Where(d => !String.IsNullOrWhiteSpace(d)).ToList();

        public static readonly Parser<List<string>> Cell =
            from open in splitHere
            from content in Parse.AnyChar.Except(splitHere).Many().Text()
            select separat.Parse(content);


        public static readonly Parser<List<string>> input3 =
            (from content in Parse.AnyChar.Except(splitHere).Many().Text()
             from Role in Cell
             select new List<string>(Role));

        public static readonly Parser<Hero> Hero =
            from Name in input
            from Role in input3
            from Lane in input2
            select new Hero(Name, Lane, Role);
    }


}
