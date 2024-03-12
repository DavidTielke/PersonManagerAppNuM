using System.Reflection.Metadata;

namespace Abhängigkeiten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IB b = new BTest();
            var a = new A(b);

            Console.WriteLine(a.DoA());
        }
    }

    class A
    {
        private IB _b;

        // Dependency Injection
        public A(IB ib)
        {
            _b = ib;
        }

        public string DoA()
        {
            var input = _b.DoB();
            var result = input.ToUpper();
            return result;
        }
    }

    interface IB
    {
        string DoB();
    }

    class BTest : IB
    {
        public string DoB()
        {
            return "Test";
        }
    }

    class B : IB
    {
        public string DoB()
        {
            return "David";
        }
    }
}
