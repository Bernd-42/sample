using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isbn_Pruefer
{
    class Program
    {
        static int GetNumber(char c)
        {
            switch (c)
            {
                case ' ':
                    return -42;
                case '-':
                    return -42;
                // Leerzeichen und Bindestriche werden für Prüfung ignoriert
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
                case 'x':
                    return 10;
                default:
                    Console.WriteLine("Ungültig! Eine Isbn10 darf nur die Ziffern 0 bis 9, Leerzeichen, Bindestriche und den Buchstaben xan letzter Stelle enthalten");
                    return -1; ;
            }
        }

       

        static bool CheckIsbn10(string eing)
        {
            eing = eing.ToLower();
            int summe = 0;
            int hilf;
            int faktor = 0;
            int pruefZiffer = -1;
            bool check = true;

            for (int i = 0; i < eing.Length - 1; i++)
            {
                hilf = GetNumber(eing[i]);

                Console.WriteLine($"hilf: {hilf}");

                if (hilf == -42) // Leerzeichen oder Bindestrich
                {
                    continue;
                }
                else if (hilf == -1 || hilf == 10) //ungültig
                {
                    Console.WriteLine("Ungültig! Eine Isbn10 darf nur die Ziffern 0 bis 9, Leerzeichen, Bindestriche und den Buchstaben x an letzter Stelle enthalten");
                    break;
                }
                else
                {
                    summe += hilf * (faktor + 1);
                    faktor++;
                }

               
                Console.WriteLine(summe);
                
            }

            Console.WriteLine();
            pruefZiffer = GetNumber(eing[eing.Length - 1]);

            Console.WriteLine($"Prüfziffer: {pruefZiffer}");

            if (pruefZiffer == -1)
            {
                return false;
            }
            else if (summe % 11 == pruefZiffer)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        static bool CheckIsbn13(string eing)
        {
            eing = eing.ToLower();
            bool check = true;
            int count = 1;
            int pruefZiffer = -1;
            int summe = 0;

            //count startet bei 1
            for (int i = 0; i < eing.Length - 1; i++)
            {
                int ziffer = GetNumber(eing[i]);
                if (ziffer == -42) // Leerzeichen oder Bindestrich
                    continue;
                if (ziffer == -1)
                {
                    Console.WriteLine("ungütiges Zeichen bei der Eingabe");
                    return false;
                }

                if (count % 2 != 0) // 1., 3. Ziffer usw
                {
                    summe += ziffer;
                    count++;
                }
                else // 2., 4., ...
                {
                    summe += ziffer * 3;
                    count++;
                }

                Console.WriteLine();
                Console.WriteLine($"count: {count -1}");
                Console.WriteLine($"Summe: {summe}");
            }

            // Soll-Prüfziffer berechnen
            int hilf = (10 - (summe % 10)) % 10;

            //Prüfziffer auslesen
            pruefZiffer = GetNumber(eing[eing.Length - 1]);

            //      flasches Zeichen    Leer oder Bindestrich    x(bei isbn10 zulässig)
            if (pruefZiffer == -1 || pruefZiffer == -42 || pruefZiffer == 10)
            {
                return false;
            }

            if (pruefZiffer == hilf)
            {
                return true;
            }
            else
            {
                return false;
            }


            //return check;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Bitte geben Sie die Isbn-Nummer ohne Bindestriche ein:  ");

            string eingabe = Console.ReadLine();
            List<int> hilf = new List<int>();
            int laenge = 0;
            int count = 0;
            bool ergebnis = true;

            //Länge ohne Leerzeichen und Bindestriche
            for (int i = 0; i < eingabe.Length; i++)
            {
                if (eingabe[i] != ' ' && eingabe[i] != '-')
                {
                    laenge++;
                }
            }

            Console.WriteLine(eingabe.Length);
            Console.WriteLine($"Anzahl relevanter zeichen: {laenge}");

            if (laenge == 10)
            {
                ergebnis = CheckIsbn10(eingabe);
                //Console.WriteLine("Länge ist 10");
            }
            else if (laenge == 13)
            {
                //Console.WriteLine("Länge ist 13");
                ergebnis = CheckIsbn13(eingabe);
            }
            else
            {
                // ungültige Eingabe
                Console.WriteLine("Ungültige Eingabe...");
                ergebnis = false;
            }

            if (ergebnis)
            {
                Console.WriteLine("_______________________________________________");
                Console.WriteLine($"Die von Ihnen eingegebene Isbn-Nummer {eingabe} ist gültig.");
            }
            else
            {
                Console.WriteLine("_______________________________________________");
                Console.WriteLine($"Die von Ihnen eingegebene Isbn-Nummer {eingabe} ist leider ungültig.");
            }


            Console.ReadKey();
        }


    }
}
