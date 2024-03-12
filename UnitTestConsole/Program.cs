using System.Runtime.CompilerServices;

namespace UnitTestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AssertDreieck(1,2,3, DreieckTyp.Normal);
            AssertDreieck(1,1,1, DreieckTyp.Gleichseitig);
            AssertDreieck(1,2,2, DreieckTyp.Gleichschenklig);
            //AssertDreieck(-11,2,2, DreieckTyp.Error);
            //AssertDreieck(0,2,2, DreieckTyp.Error);
            //AssertDreieck(2,0,2, DreieckTyp.Error);
            //AssertDreieck(2,2,0, DreieckTyp.Error);
        }

        static void AssertDreieck(int a, int b, int c, DreieckTyp extected)
        {
            var dreieck = new DreieckTypChecker();

            var actual = dreieck.GetTyp(a, b, c);

            var oldColor = Console.ForegroundColor;
            if (actual != extected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{a},{b},{c} sollte {extected}, aber ist {actual}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{a},{b},{c} ist {extected}");
            }
            Console.ForegroundColor = oldColor;
        }
    }

    public class DreieckTypChecker
    {
        public DreieckTyp GetTyp(int a, int b, int c)
        {
            var sidesOrderedDesc = new long[] { a, b, c }.Order().ToArray();
            var minSide1 = sidesOrderedDesc[0];
            var minSide2 = sidesOrderedDesc[1];
            var maxSide = sidesOrderedDesc[2];
            var isNotConstructable = minSide1 + minSide2 <= maxSide;
            var atLeastOneSideZeroOrNegative = a <= 0 || b <= 0 || c <= 0;
            if (isNotConstructable || atLeastOneSideZeroOrNegative)
            {
                throw new ArgumentException($"{a},{b},{c} is not a constructable triangle");
            }

            var allSidedEqual = a == b && b == c && c == a;
            if (allSidedEqual)
            {
                return DreieckTyp.Gleichseitig;
            }

            var twoSidesEqual = a == b || a == c || b == c;
            if (twoSidesEqual)
            {
                return DreieckTyp.Gleichschenklig;
            }
            return DreieckTyp.Normal;
        }
    }

    public enum DreieckTyp
    {
        Normal,
        Gleichseitig,
        Gleichschenklig
    }
}
