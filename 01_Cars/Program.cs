using System.Reflection;
using Helpers;

namespace _01_Cars;

public class Program
{
    public enum enCarColor
    {
        Brown, Red, Green, Burgundy
    }
    public enum enCarBrand
    {
        Boxcar, Ford, Jaguar, Honda
    }
    public enum enCarModel
    {
        Boxmodel, Mustang_GT, Golf, V70, XF, Civic
    }
    public class csCar
    {
        public enCarColor Color { get; set; }
        public enCarBrand Brand { get; init; }
        public enCarModel Model { get; init; }

        public string WhoAmI()
        {
            string _s = $"I am a {Color} {Brand} {Model}";
            return _s;
        }
        public override string ToString()
        {
            string _s = $"I am a {Color} {Brand} {Model}";
            return _s;
        }

        public csCar() { }
        public csCar(enCarColor _color, enCarBrand _brand, enCarModel _model)
        {
            Color = _color;
            Brand = _brand;
            Model = _model;
        }
        public csCar(csCar org)
        {
            Color = org.Color;
            Brand = org.Brand;
            Model = org.Model;
        }
        public csCar(csSeedGenerator _seeder)
        {

            //alternative to SeedGenerator
            var rnd1 = new Random();
            Model =  (enCarModel) rnd1.Next((int)enCarModel.Boxmodel, (int)enCarModel.Civic + 1);


            Color = _seeder.FromEnum<enCarColor>();
            Brand = _seeder.FromEnum<enCarBrand>();
            Model = _seeder.FromEnum<enCarModel>();
        }
    }


    static void Main(string[] args)
    {
        var rnd = new csSeedGenerator();
        Console.WriteLine("Class exploration with Cars!");

        Console.WriteLine("\nDefault constructor");
        csCar car0 = new csCar();
        Console.WriteLine(car0);

        Console.WriteLine("Copy constructor");
        csCar car0_copy = new csCar(car0);
        Console.WriteLine(car0_copy);

        Console.WriteLine("\nRandom constructor"); csCar car1 = new csCar(rnd);
        Console.WriteLine(car1);

        Console.WriteLine("Copy constructor");
        csCar car1_copy = new csCar(car1);
        Console.WriteLine(car1_copy);

        Console.WriteLine("\nConstructor to set properties");
        csCar car1a = new csCar(enCarColor.Red, enCarBrand.Jaguar, enCarModel.XF);
        Console.WriteLine(car1a);

        Console.WriteLine("Copy constructor");
        csCar car1a_copy = new csCar(car1a);
        Console.WriteLine(car1a_copy);


        //Create 10 cars
        Console.WriteLine("\nLista 10 bilar");
        csCar[] cars = new csCar[10];
        for (int i = 0; i < 10; i++)
        {
            cars[i] = new csCar(rnd) { Color = enCarColor.Burgundy };
        }

        foreach (var item in cars)
        {
            //Console.WriteLine(item.WhoAmI());
            Console.WriteLine(item);
        }

        //Copy 10 cars
        Console.WriteLine("\nKopia av listan 10 bilar");
        csCar[] cars_copy = new csCar[10];
        for (int i = 0; i < cars_copy.Length; i++)
        {
            cars_copy[i] = new csCar(cars[i]);
        }

        foreach (var item in cars_copy)
        {
            //Console.WriteLine(item.WhoAmI());
            Console.WriteLine(item);
        }

        /*
        #region how To use the seed generator
        var rnd = new csSeedGenerator();

        //A random enCarColor
        enCarColor rndColor = rnd.FromEnum<enCarColor>();
        Console.WriteLine(rndColor.ToString());

        //A random enCarBrand
        Console.WriteLine(rnd.FromEnum<enCarBrand>());

        //A random enCarModel
        Console.WriteLine(rnd.FromEnum<enCarModel>());
        #endregion
        */

        Console.ReadKey();

    }

    //Exercises:
    //1. Make class csCar public field Color a public property with getters and setters

    //2. Create two new public properties in class csCar, Brand, Model
    //   (of types enCarBrand and enCarModel)

    //3. Create an empty class constructor to csCar that sets Color, Brand and Model to
    //   Random values

    //4. Create a method public method WhoAmI() that presents for example
    //   "I am a Red Ford Mustang_GT";

    //5. In Main(), create two variables, car1, car2 and instantiate from csCar
    //   - printout WhoAmI of car1 and car2

    //Advanced:
    //6. Modify the properties Color, Brand and Model so that only Color can change
    //   once an instance of Car has been created

    //7. Modify the properties of Brand and Model so they can also be set during
    //   Object initialization, i.e.  new Car(){ Model = ..., Brand = ...}

    //8. Create an array of 10 cars, all of Color Burgundy.

    //9. Change class Car to struct Car and run the program again.


    // --- Gör tills 4 Oktober
    // 10. Gör om construtor csCar() så att den tar en parameter (csSeedGenerator _seeder).
    //    Instantiera csSeedGeneratorn i Main() och modifiera koden så att den fungerar som innan.
    //
    // 11. Deklarera en construktor som tillåter dig att själv bestämma alla csCar public properties
    //
    // 12. Deklarera en Copy constructor.
    //
    // 13. Använd copy constructorn för att skapa en array av 10 bilar som är en kopia av ursprunget
}

