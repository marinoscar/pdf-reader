using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_reader
{
    class Program
    {

        static ConsoleSwitches _args;
        static void Main(string[] a)
        {
            _args = new ConsoleSwitches(a);
            if (_args.ContainsSwitch("/toText")) ToText();
            Console.WriteLine();
            Console.WriteLine("Press any key");
            Console.Read();
        }

        private static void ToText()
        {
            var parser = GetParser();
            var result = parser.ToLocationText();
            Console.WriteLine(result);
        }


        private static Parser GetParser()
        {
            return new Parser(_args["-f"]);
        }
    }
}
