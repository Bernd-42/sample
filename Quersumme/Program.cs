using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quersumme
{
    class Program
    {
        static bool IstZiffer(char c)
        {
            //bool erg = false;

            if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' ||
                c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
            {
                return true;
            }
            return false;
        }

        static int GetNumber(char c)
        {
            switch (c)
            {
               
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                default:
                    Console.WriteLine("Fehler");
                    return -1; ;
            }
        }
        static void Main(string[] args)
        {
            int querSumme = 0;
            Console.WriteLine();
            Console.WriteLine("Bitte geben Sie eine Ganzzahl zur Berechnung der Quersumme ein:  ");
            string eingabe = Console.ReadLine();

            bool istZahl = Int32.TryParse(eingabe, out int result);

            if (istZahl)
            {
                int start;
                if (result < 0) // bei negativer Zahl das Minus ignorieren
                {
                    start = 1;
                }
                else
                {
                    start = 0;
                }

                for (int i = start; i < eingabe.Length; i++)
                {
                    querSumme += GetNumber(eingabe[i]);
                }
            }

            Console.WriteLine($"Die Quersumme von {result} ist {querSumme}");


            Console.ReadKey();
        }
    }
}
