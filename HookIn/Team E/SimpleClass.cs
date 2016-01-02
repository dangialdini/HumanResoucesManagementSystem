using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_E
{
    public class SimpleClass
    {

        public void Callout()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Rosie checks in 1");
            Console.WriteLine("Harold is here too!");

            Console.WriteLine("----------------------");

            Console.WriteLine("Hello World!");
            Console.WriteLine("Ismael checks in 2");

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");

            Console.WriteLine("----------------------");

            Console.ReadKey();
        }
    }
}
