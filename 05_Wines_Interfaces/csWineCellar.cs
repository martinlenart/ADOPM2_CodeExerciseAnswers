using System;
namespace _05_Wines_Interfaces
{
    public class WineCellar
    {
        public string Name { get; set; }
        private List<IWine> Wines = new List<IWine>();


        public void Add(IWine wine) => Wines.Add(wine);
        public int Count => Wines.Count;
        public IWine this[int idx] => Wines[idx];
 
        public decimal Value
        {
            get
            {
                decimal _sum = 0M;
                foreach (var wine in Wines)
                {
                    _sum += wine.Price;
                }
                return _sum;
            }
        }

        public override string ToString()
        {
            var sRet = "";
            foreach (var wine in Wines)
            {
                sRet += $"{wine}\n   - {wine.GetType().Name}\n";
            }
            return sRet;
        }

        public WineCellar() { }
        public WineCellar(string name)
        {
            Name = name;
        }

        public (IWine hicost, IWine locost) WineHiLoCost()
        {
            if (Wines.Count == 0) return (null,null);

            decimal _hiPrice = decimal.MinValue;
            IWine _hiWine = null;
            decimal _loPrice = decimal.MaxValue;
            IWine _loWine = null;
            foreach (var wine in Wines)
            {
                if (wine.Price > _hiPrice)
                {
                    _hiWine = wine;
                    _hiPrice = wine.Price;
                }
                if (wine.Price < _loPrice)
                {
                    _loWine = wine;
                    _loPrice = wine.Price;
                }
            }
            return (_hiWine, _loWine);
        }
    }
}

