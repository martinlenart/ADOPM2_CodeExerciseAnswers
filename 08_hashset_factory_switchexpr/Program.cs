using Helpers;

namespace _08_hashset_factory_switchexpr;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("08_hashset_factory_switchexpr");

        Console.WriteLine("List of unique pearls");
        var rnd = new csSeedGenerator();
        HashSet<csPearl> unique_pearls = new HashSet<csPearl>();

        while(unique_pearls.Count<10)
        {
            unique_pearls.Add(new csPearl(rnd) { Size=5 });
        }
        Console.WriteLine();
        foreach (var item in unique_pearls)
        {
            Console.WriteLine(item);
        }

        
        Console.WriteLine("\nNecklace of unique SaltWater pearls");
        csNecklace n1 = csNecklace.Factory.CreateSaltWaterUnique();

        n1.ListOfPearls.Sort();
        Console.WriteLine(n1);
        
        Console.WriteLine("\nNecklace of XL Pearls");
        Console.WriteLine(csNecklace.Factory.CreateXL(10));
        
    }
}

//Exercise:
//HashSet<T>
//1. i Main() skapa en lista av 10 olika pärlor slumpmässigt, dock ska alla ha storlek 5mm

//Class factory
//2. i csNecklace skapa en statisk metod, CreateSaltWaterUnique, som skapar ett
//   halsband som har 10 unika saltvatten pärlor
//3. i csNecklace skapa en statisk metod, CreateXL, som tar en parameter, NrPearls, och skapar ett
//   halsband med NrOfPearls pärlor av storlek 15 - 20mm

//Switch expressions
//4. Modifera ToString() i csPearl så att det läggs till en rad när pärlan presenteras avseende storleken
// <= 10mm ska ”a small pearl” skrivas ut
// >10 och <= 15 ska ”a midsized pearl” skrivas ut
// > 15 ska ”a large pearl” skrivas ut

