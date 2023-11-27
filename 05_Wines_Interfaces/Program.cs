using System.Xml.Linq;
using Helpers;
namespace _05_Wines_Interfaces;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Wines with Interface!");

        var rnd = new csSeedGenerator();
        WineCellar wineCellar = new WineCellar("Martin's cellar");

        #region Add wines to the winecellar
        wineCellar.Add(new csWine().Seed(rnd));
        wineCellar.Add(new stWine().Seed(rnd));
        #endregion

        Console.WriteLine($"\nWinecellar: {wineCellar.Name}");
        //wineCellar.Wines = null;
        //wineCellar.Wines[0] = new csWine();
        Console.WriteLine(wineCellar);

        Console.WriteLine($"Nr of bottles: {wineCellar.Count}");
        Console.WriteLine($"Value of winecellar: {wineCellar.Value:N2} Sek");

        var hilo = wineCellar.WineHiLoCost();
        Console.WriteLine($"\nMost expensive wine:\n{hilo.hicost}");
        Console.WriteLine($"Least expensive wine:\n{hilo.locost}");

        Console.WriteLine("\nIndexers");
        for (int i = 0; i < wineCellar.Count; i++)
        {
            Console.WriteLine(wineCellar[i]);
        }
    }
}

/* Exercises
1. Implement csWine and stWine
2. Add some wines to the cellar of both csWine and stWine, notice you can mix
*/

