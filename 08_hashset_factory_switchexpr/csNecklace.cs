using System;
using System.Drawing;
using Helpers;

namespace _08_hashset_factory_switchexpr
{
    public class csNecklace : IEquatable<csNecklace>
    {
        public List<csPearl> ListOfPearls { get; set; } = new List<csPearl>();
        public string Name { get; set; }

        public override string ToString()
        {
            string sRet = $"\n{Name}:";
            foreach (var item in ListOfPearls)
            {
                sRet += $"\n{item.ToString()}";
            }
            return sRet;
        }

        #region Implementation of IEquatable<T> interface
        public bool Equals(csNecklace other)
        {
            if (this.Name != other.Name)
                return false;
            if (this.ListOfPearls.Count != other.ListOfPearls.Count)
                return false;

            for (int i = 0; i < ListOfPearls.Count; i++)
            {
                if (this.ListOfPearls[i] != other.ListOfPearls[i])
                    return false;
            }
            return true;
        }


        //Needed to implement as part of IEquatable
        public override bool Equals(object obj) => Equals(obj as csNecklace);
        public override int GetHashCode() => (this.Name, this.ListOfPearls.Count, this.ListOfPearls).GetHashCode();
        #endregion

        #region operator overloading
        public static bool operator ==(csNecklace o1, csNecklace o2) => o1.Equals(o2);
        public static bool operator !=(csNecklace o1, csNecklace o2) => !o1.Equals(o2);
        #endregion

        public csNecklace(string name)
        {
            Name = name;
        }
        public csNecklace(int nrPearls, string name)
        {
            Name = name;
            var rnd = new csSeedGenerator();
            for (int i = 0; i < nrPearls; i++)
            {
                ListOfPearls.Add(new csPearl(rnd));
            }
        }
        public csNecklace(string name, csPearl _p1, csPearl _p2)
        {
            Name = name;
            ListOfPearls.Add(_p1);
            ListOfPearls.Add(_p2);
        }

        public csNecklace(csNecklace org)
        {
            Name = org.Name;
            ListOfPearls = new List<csPearl>();

            for (int i = 0; i < org.ListOfPearls.Count; i++)
            {
                ListOfPearls.Add(new csPearl(org.ListOfPearls[i]));
            }
        }

        #region class factory

        public static class Factory
        {
            public static csNecklace CreateSaltWaterUnique()
            {
                var rnd = new csSeedGenerator();
                HashSet<csPearl> unique_pearls = new HashSet<csPearl>();

                while (unique_pearls.Count < 10)
                {
                    unique_pearls.Add(new csPearl(rnd) { Type = enPearlType.SaltWater });
                }

                return new csNecklace("Unique saltwater pearls")
                {
                    ListOfPearls = unique_pearls.ToList()
                };
            }
            public static csNecklace CreateXL(int NrOfPearls)
            {
                var rnd = new csSeedGenerator();

                var pearls = new List<csPearl>();
                for (int i = 0; i < NrOfPearls; i++)
                {
                    pearls.Add(new csPearl(rnd) { Size = rnd.Next(15, 21) });
                }
                return new csNecklace("Necklace XL")
                {
                    ListOfPearls = pearls
                };
            }

        }
        #endregion
    }
}

