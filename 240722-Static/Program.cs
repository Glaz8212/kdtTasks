using System;

namespace _240722_Static
{
    internal class Program
    {

        // 과제1. 계산기 클래스 만들기
        class MyCalculator
        {
            public static double Add()  // 두 수를 입력 받고, 합 반환하기
            {
                Console.Write("덧셈을 진행할 첫 번째 수를 입력해주세요 - ");
                double num1;
                double.TryParse(Console.ReadLine(), out num1);
                Console.Write("덧셈을 진행할 두 번째 수를 입력해주세요 - ");
                double num2;
                double.TryParse(Console.ReadLine(), out num2);

                return (num1 + num2);
            }

            public static double Subtract()  // 두 수를 입력 받고, 차 반환하기
            {
                Console.Write("뺄셈을 진행할 첫 번째 수를 입력해주세요 - ");
                double num1;
                double.TryParse(Console.ReadLine(), out num1);
                Console.Write("뺄셈을 진행할 두 번째 수를 입력해주세요 - ");
                double num2;
                double.TryParse(Console.ReadLine(), out num2);

                return (num1 - num2);
            }

            public static double Multiply()  // 두 수를 입력 받고, 곱 반환하기
            {
                Console.Write("곱셈을 진행할 첫 번째 수를 입력해주세요 - ");
                double num1;
                double.TryParse(Console.ReadLine(), out num1);
                Console.Write("곱셈을 진행할 두 번째 수를 입력해주세요 - ");
                double num2;
                double.TryParse(Console.ReadLine(), out num2);

                return (num1 * num2);
            }

            public static double Divide()   // 두 수를 입력 받고, 몫 반환하기
            {
                Console.Write("나누어질 수를 입력해주세요 - ");
                double num1;
                double.TryParse(Console.ReadLine(), out num1);
                Console.Write("나눌 수를 입력해주세요 - ");
                double num2;
                double.TryParse(Console.ReadLine(), out num2);

                if (num2 == 0)
                {
                    while(num2 == 0)
                    {
                        Console.Write("0으로 나눌 수 없습니다. 다시 입력해주세요 - "); // 에러 발생
                        double.TryParse(Console.ReadLine(), out num2);
                    }
                }

                return (num1 / num2);
            }

            public static double Squared()
            {
                Console.Write("제곱할 수를 입력해주세요 - ");
                double num1;
                double.TryParse(Console.ReadLine(), out num1);
                Console.Write("몇번 제곱할 지 입력해 주세요 - ");
                double num2;
                double.TryParse(Console.ReadLine(), out num2);

                return (Math.Pow(num1, num2)); //Math.Pow(a,b) == a의 b제곱
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MyCalculator.Divide());
        }
    }
}
