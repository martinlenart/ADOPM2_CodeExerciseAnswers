using System;
using System.Drawing;
using Helpers;

namespace _07_IEquatable_IComparable
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
    }
}

