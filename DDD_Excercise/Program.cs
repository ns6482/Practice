using System;
using colors.main;

namespace colors.main
{
    [Flags]
    internal enum ColorTypes
    {
        Red = 1,
        Blue = 2,
        Yellow = 4,
        Orange = 5,
        Purple = 3,
        Green = 6
    }

    internal interface IColor<T>
    {
        bool Equals(IColor<T> other);
        string ToString();
        IColor<T> Add(IColor<T> color);
        T GetColorType();
    }

    internal abstract class BaseColor<T> : IColor<T>
    {
        private readonly T _colorType;

        public T GetColorType()
        {
            return _colorType;
        }

        protected BaseColor(T type)
        {
            _colorType = type;
        }

        public override string ToString()
        {
            return _colorType.ToString();
        }


        public bool Equals(IColor<T> other)
        {
            var a = GetColorType();
            var b = other.GetColorType();

            return a.Equals(b);
        }

        public virtual IColor<T> Add(IColor<T> color)
        {
            throw new NotImplementedException();
        }
    }

    internal class Color : BaseColor<ColorTypes>
    {
        public Color(ColorTypes t) : base(t)
        {
        }

        public override IColor<ColorTypes> Add(IColor<ColorTypes> a)
        {
            if (Equals(a))
                return new Color(a.GetColorType());

            var a1 = a.GetColorType();
            var b1 = GetColorType();

            var result = a1 | b1;

            return new Color(result);
        }
    }
}

namespace DDD_Excercise
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var red = new Color(ColorTypes.Red);
            var yellow = new Color(ColorTypes.Yellow);
            var blue = new Color(ColorTypes.Blue);


            Assert("Orange", red.Add(yellow).ToString());
            Assert("Orange", yellow.Add(red).ToString());
            Assert("Red", red.Add(red).ToString());
            Assert("Green", yellow.Add(blue).ToString());
            Assert("Purple", blue.Add(red).ToString());
        }

        private static void Assert(string expected, string actual)
        {
            Console.WriteLine("Test: expected {0}, actual  {1}", expected, actual);
            Console.WriteLine(expected == actual ? "PASS" : "Fail");
        }
    }
}
