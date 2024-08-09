namespace parameter_exchange
{
    internal class Program
    {
        public static void Swap<T>(ref T x, ref T y)
        {
            T storage = x;
            x = y;
            y = storage;
        }
        static void Main(string[] args)
        {
            int iLeft = 10;
            int iRight = 20;
            Swap(ref iLeft, ref iRight);
            Console.WriteLine("int 자료형을 사용한 Swap 함수");
            Console.WriteLine($"{iLeft}, {iRight}");

            Console.WriteLine();

            double dLeft = 5.5;
            double dRight = 8.4;
            Swap(ref dLeft, ref dRight);
            Console.WriteLine("double 자료형을 사용한 Swap 함수");
            Console.WriteLine($"{dLeft}, {dRight}");
        }
    }
}
