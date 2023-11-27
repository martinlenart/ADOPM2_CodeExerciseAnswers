using System;
namespace _05_Wines_Interfaces
{
    public class WineCellar
    {
        public string Name { get; set; }
        private List<csWine> _wines = new List<csWine>();


        public void Add(csWine wine) => _wines.Add(wine);
        public int Count => _wines.Count;
        public csWine this[int idx] => _wines[idx];

        public void Clear() => _wines.Clear();
 
        public decimal Value
        {
            get
            {
                decimal _sum = 0M;
                foreach (var wine in _wines)
                {
                    _sum += wine.Price;
                }
                return _sum;
            }
        }

        public override string ToString()
        {
            var sRet = "";
            foreach (var wine in _wines)
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

        public (csWine hicost, csWine locost) WineHiLoCost()
        {
            if (_wines.Count == 0) return (null,null);

            decimal _hiPrice = decimal.MinValue;
            csWine _hiWine = null;
            decimal _loPrice = decimal.MaxValue;
            csWine _loWine = null;
            foreach (var wine in _wines)
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

