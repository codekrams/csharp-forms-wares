using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateieinlesen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitt den Dateinamen angeben:");
            string eingabe = Console.ReadLine();

            FileStream fs = new FileStream(eingabe, FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(fs);


            while (sr.Peek() != -1)
            {
                Console.WriteLine(sr.ReadLine());
            }

            sr.Close();
            fs.Close();

            Console.ReadKey();
        }
    }
}
