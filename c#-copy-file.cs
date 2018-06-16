using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateikopieren
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte den Dateinamen der zu kopierenden Datei angeben: ");
            string original = Console.ReadLine();
            Console.WriteLine("Bitte den Dateinamen der Kopie angeben:");
            string kopie = Console.ReadLine();

            File.Copy(original, kopie);

            if (File.Exists(kopie))
            {
                Console.WriteLine("Kopieren erfolgreich");
            }
            else {
                Console.WriteLine("Kopieren fehlgeschlagen");
            }

            Console.ReadKey();
        }
    }
}
