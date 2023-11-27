using System;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Helpers;

namespace _08_hashset_factory_switchexpr
{
    public enum enPearlColor { Black, White, Pink }
    public enum enPearlShape { Round, DropShaped }
    public enum enPearlType { FreshWater, SaltWater }

    #region Pearl as a class
    public class csPearl : IEquatable<csPearl>, IComparable<csPearl>
    {
        public int Size { get; init; }
        public enPearlColor Color { get; init; }
        public enPearlShape Shape { get; init; }
        public enPearlType Type { get; init; }

        public override string ToString()
        {
            var sRet = $"{Size}mm {Color} {Shape} {Type} pearl.";
            string s = this.Size switch
            {
                <= 10 => " A small pearl.",
                > 10 and <= 15 => " A midsized pearl.",
                > 15 => " A large pearl."
            };

            return sRet + s;
        }


        #region Implementation of IEquatable<T> interface
        public bool Equals(csPearl other) => (this.Size, this.Color, this.Shape, this.Type) ==
           (other.Size, other.Color, other.Shape, other.Type);

        //Needed to implement as part of IEquatable
        public override bool Equals(object obj) => Equals(obj as csPearl);
        public override int GetHashCode() => (this.Size, this.Color, this.Shape, this.Type).GetHashCode();
        #endregion

        #region operator overloading
        public static bool operator ==(csPearl o1, csPearl o2) => o1.Equals(o2);
        public static bool operator !=(csPearl o1, csPearl o2) => !o1.Equals(o2);
        #endregion

        #region Implementation IComparable<T> interface
        public int CompareTo(csPearl other)
        {
            //Sort on Make -> Model -> Year
            if (this.Size != other.Size)
                return this.Size.CompareTo(other.Size);

            return this.Type.CompareTo(other.Type);
        }
        #endregion

        public csPearl() { }
        public csPearl(csSeedGenerator _seeder)
        {
            Size = _seeder.Next(5, 25);
            Color = _seeder.FromEnum<enPearlColor>();
            Shape = _seeder.FromEnum<enPearlShape>();
            Type = _seeder.FromEnum<enPearlType>();
        }
        public csPearl(int _size, enPearlColor _color, enPearlShape _shape, enPearlType _type)
        {
            Size = _size;
            Color = _color;
            Shape = _shape;
            Type = _type;
        }
        public csPearl(csPearl org)
        {
            Size = org.Size;
            Color = org.Color;
            Shape = org.Shape;
            Type = org.Type;
        }
    }
    #endregion
}

