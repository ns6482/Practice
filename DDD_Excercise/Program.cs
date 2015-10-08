using colors.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colors.main
{

    enum ColorTypes
    {

        Red = 1,
        Blue = 2,
        Yellow = 4,
        Orange = 5,
        Purple = 3,
        Green = 6
    }

    interface IColor<T>
    {

        bool Equals(IColor<T> other);

        String ToString();

        IColor<T> add(IColor<T> color);

        T GetColorType();
    }

    abstract class baseColor<T> : IColor<T>
    {

        private readonly T _colorType;
        
        public T GetColorType()
        {
            return _colorType;
        }
         public baseColor(T type)
        {
            _colorType = type;
        }


        public override string ToString()
        {
            return _colorType.ToString();
        }


        public bool Equals(IColor<T> other)
        {
            var a = this.GetColorType();
            var b = other.GetColorType();

            return a.Equals(b);
        }

        public virtual  IColor<T> add(IColor<T> color)
        {
            throw new NotImplementedException();
        }

     
    }

    class Color : baseColor<ColorTypes>
    {


        public Color(ColorTypes t) : base(t)
        {

        }

        public override IColor<ColorTypes> add(IColor<ColorTypes> a)
        {

            if (this.Equals(a))
                return new Color(a.GetColorType());

            var a1 = a.GetColorType();
            var b1 = this.GetColorType();

            var result = a1 & b1;

            return new Color(result);
        }


    }
 
   
}

namespace DDD_Excercise
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
