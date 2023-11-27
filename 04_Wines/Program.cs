using System.Xml.Linq;
using Helpers;

namespace _04_Wines;

public enum enGrapeType {Reissling, Tempranillo, Chardonay, Shiraz, CabernetSavignoin, Syrah}
public enum enWineType { Red, White, Rose}
public enum enCountry { Germany, France, Spain }

public struct csWine
{
    public string Name { get; }

    public enCountry Country { get; }
    public enWineType WineType { get; }
    public enGrapeType GrapeType { get; }

    public decimal Price { get; set; }

    public override string ToString()
    {
        var s = $"Wine {Name} from {Country} is {WineType} and made from grapes {GrapeType}. The price is {Price:N2} Sek";
        return s;
    }

    public csWine() { }
    public csWine(csSeedGenerator _seeder)
    {
        string[] _names = "Chattaux de bueff, Chattaux de paraply, PutiPuti".Split(", ");
        Name = _names[_seeder.Next(0, _names.Length)];

        GrapeType = _seeder.FromEnum<enGrapeType>();
        WineType = _seeder.FromEnum<enWineType>();
        Country = _seeder.FromEnum<enCountry>();
        Price = _seeder.Next(50, 150);
    }
    public csWine(string _name, enCountry _country, enGrapeType _grapetype,
        enWineType _wineType, decimal _price)
    {
        Name = _name;
        GrapeType = _grapetype;
        WineType = _wineType;
        Country = _country;
        Price = _price;
    }
    public csWine(csWine org)
    {
        Name = org.Name;
        GrapeType = org.GrapeType;
        WineType = org.WineType;
        Country = org.Country;
        Price = org.Price;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var rnd = new csSeedGenerator();
        Console.WriteLine("Hello, Wine World!");

        Console.WriteLine("A Single bottle");
        var wine1 = new csWine(rnd);
        wine1.Price = 70M;
        Console.WriteLine(wine1);

        Console.WriteLine("\nA wine cellar");

        List<csWine> wines = new List<csWine>();
        
        for (int i = 0; i < 10; i++)
        {
            wines.Add(new csWine(rnd));
        }
        
        for (int i = 0; i < wines.Count; i++)
        {
            Console.WriteLine(wines[i]);
        }

        decimal maxPrice = decimal.MinValue;
        decimal minPrice = decimal.MaxValue;
        decimal totValue = 0;
        for (int i = 0; i < wines.Count; i++)
        {
            if (wines[i].Price > maxPrice )
            {
                maxPrice = wines[i].Price;
            }
            if (wines[i].Price < minPrice)
            {
                minPrice = wines[i].Price;
            }

            totValue += wines[i].Price;
        }
        Console.WriteLine();
        Console.WriteLine($"My most expensive wine cost {maxPrice}");
        Console.WriteLine($"My most cheapest wine cost {minPrice}");
        Console.WriteLine($"Total wine cellar value is {totValue}");


        Console.WriteLine("\nA copy of my winecellar");
        List<csWine> wines_copy = new List<csWine>();
        for (int i = 0; i < wines.Count; i++)
        {
            wines_copy.Add(new csWine(wines[i]));
        }
        foreach (var item in wines_copy)
        {
            Console.WriteLine(item);
        }



    }
}

//Exercise:
// 1. Modellera en flaska vin en C# class. Utmärkande för ett vin är
//    Druva: Reissling, Tempranillo, Chardonay, Shiraz, Cabernet Savignoin, Syrah
//    Typ: Rött, vitt, rose
//    Namn: namnet på vinet
//    Land: Tyskland, Frankrike, Spanien
//    Pris:
//
// 2. När vinet väl är skapad så ska man bara kunna ändra pris.
//
// 3. Skapa en ToString i din vinklass som presenterar vinet.
//
// 4. Skapa en vinkällare bestående av 10 flaskor av slumpmässig Druva,
//    Typ, Namn, Land och pris
//
// 5. Vilket är det billigaste och dyraste vinet i vinkällaren?
//
// 7. Vad är värdet av vinkällaren?
//
// --- Gör tills 4 Oktober
// 8. Gör om construtor csWine() så att den tar en parameter (csSeedGenerator _seeder).
//    Instantiera csSeedGeneratorn i Main() och modifiera koden så att den fungerar som innan.
//
// 9. Deklarera en contruktor som tillåter dig att själv bestämma alla csWine public properties
//
// 10.Deklarera en Copy constructor.
//
// 11.Använd copy constructorn för att skapa en ny lista av 10 viner med samma
//    innehåll som ursprungslistan

