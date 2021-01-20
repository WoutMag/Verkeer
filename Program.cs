using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Verkeer
{
    class Program
    {
        static List<Voertuig> verkeer = new List<Voertuig>();
        static Random rnd = new Random();
        static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            StelSamen();
            TelDeuken("Na opstellen");
            Console.WriteLine();
            Console.WriteLine($"Tijd {sw.ElapsedMilliseconds} miliseconden.");
            Beweging();
            TelDeuken("Na beweging");

            sw.Stop();
            Console.WriteLine($"Tijd {sw.ElapsedMilliseconds} miliseconden.");

            Console.WriteLine("Toets op een druk");
            Console.ReadKey();

        }
        static void StelSamen()
        { 
            double x;
            double y;
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Auto("Opel", 4, x, y, 4, 1600));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Auto( "Voorloop", 4, x, y, 2, 1500));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Fiets("Kronan", 2, x, y, 1));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Bromfiets("Scopy", 2, x, y, 2, 49));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Auto("Polo", 4, x, y, 4, 1800));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Auto("Jazz", 4, x, y, 5, 1900));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Auto("Cordoba", 4, x, y, 4, 1700));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Auto("Civic", 4, x, y, 54, 1700));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Auto("Cactus", 4, x, y, 4, 1900));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Auto("Jetta", 4, x, y, 4, 1500));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Fiets("Tandem", 2, x, y, 2));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Fiets("Bakfiets", 3, x, y, 1));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Fiets("Brithon", 2, x, y, 1));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Vrachtwagen("Scania", 6, x, y, 2, 4000, 5000));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Vrachtwagen("Volvo", 6, x, y, 4, 6000, 10000));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Vrachtwagen("Mercedes", 8, x, y, 2, 10000, 25000));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Bus("Stadsbus", 6, x, y, 2, 4000, 48));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Bus("Touringcar", 6, x, y, 2, 5000, 52));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Bus("Bestelbus", 4, x, y, 3, 1900, 3));
            x = Randint(400, 10); y = Randint(400, 10);
            verkeer.Add(new Bromfiets("Zundapp", 2, x, y, 1, 49));



        }
        static private double Randint(double basis, int afstand)
        {
            double r = basis + rnd.Next(afstand);
            return r;
        }


        static void Beweging()
        {
            foreach (var item in verkeer)
            {
                item.Hoek = (90 * Randint(-1, 2));
                item.Beurt((float) Randint(0, 50));
            }
        }

        static void TelDeuken(string wanneer)
        {
            int deuken = 0;
            foreach (var item in verkeer)
            {
                string[] botsingInfo = item.Botsing(verkeer, false).Split(':');
                Console.WriteLine(botsingInfo[0]);
                deuken += int.Parse(botsingInfo[1]);

            }
            Console.WriteLine($"{wanneer}: {deuken} deuken");
        }
    }
}
