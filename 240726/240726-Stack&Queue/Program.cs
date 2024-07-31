namespace _240726_Stack_Queue
{
    internal class Program
    {
        #region 과제1
        //과제1
        //
        //다음의 조건을 충족하는 괄호 검사기 프로그램을 구현하시오
        //괄호가 바르게 짝지어졌다는 것은 열렸으면 짝지어서 닫혀야 한다는 뜻이다
        //텍스트를 입력으로 받아서 괄호가 유효한지 판단하는 프로그램을 작성하자
        //검사할 괄호 : [], {}, ()
        //예시 : () 완성, (() 미완성, [[(){}]] 완성, [(})] 미완성

        static void CheckCorrectBracket(string input)
        {
            Stack<char> stack1 = new();
            Stack<char> stack2 = new();
            Stack<char> stack3 = new();
            Stack<char> stack4 = new();
            Stack<char> stack5 = new();
            Stack<char> stack6 = new();

            char[] inputArray = input.ToCharArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                char inputChar = inputArray[i];

                switch (inputChar)
                {
                    case '(':
                        stack1.Push(inputChar);
                        break;
                    case ')':
                        stack2.Push(inputChar);
                        break;
                    case '{':
                        stack3.Push(inputChar);
                        break;
                    case '}':
                        stack4.Push(inputChar);
                        break;
                    case '[':
                        stack5.Push(inputChar);
                        break;
                    case ']':
                        stack6.Push(inputChar);
                        break;
                    default:
                        break;
                }



            }
            if (stack1.Count == stack2.Count)
            {
                Console.WriteLine("소괄호가 완성되었습니다.");
            }
            else
            {
                Console.WriteLine("소괄호가 미완성입니다.");
            }

            if (stack3.Count == stack4.Count)
            {
                Console.WriteLine("중괄호가 완성되었습니다.");
            }
            else
            {
                Console.WriteLine("중괄호가 미완성입니다.");
            }

            if (stack5.Count == stack6.Count)
            {
                Console.WriteLine("대괄호가 완성되었습니다.");
            }
            else
            {
                Console.WriteLine("대괄호가 미완성입니다.");
            }
        }
        #endregion

        #region 과제2

        //과제2
        //
        //다음의 조건을 충족하는 작업 일정 계산기 프로그램을 구현하시오
        //하루에 8시간씩 일하는 회사가 있으며 남는시간 없이 주어진 일을 계속한다
        //각 작업이 몇시간이 걸리는 작업인지 포함하는 배열을 받을 때,
        //각각의 작업이 끝나는 날짜를 결과 배열로 출력하는 함수를 작성하자
        //예시
        //입력 : [4, 4, 12, 10, 2, 10]
        //출력 : [1, 1, 3, 4, 4, 6]
        //해석
        //1일차 : 0번째 작업의 4/4 완료 + 1번쨰 작업의 4/4 완료.
        //2일차 : 2번째 작업의 8/12 완료
        //3일차 : 2번째 작업의 4/12 완료 + 3번째 작업의 4/10 완료
        //4일차 : 3번째 작업의 6/10 완료 + 4번째 작업의 2/2 완료
        //5일차 : 5번째 작업의 8/10 완료
        //6일차 : 5번째 작업의 2/10 완료

        static void WorkCalculater()
        {
            //일단, 작업 시간들을 저장할 queue를 생성하고 데이터를 입력받는다.
            Queue<int> que = new();

            while (true)
            {
                Console.Write("작업 시간을 입력하세요. 999를 입력시 입력을 종료합니다.");
                string input = Console.ReadLine();
                int workTime;
                bool success = int.TryParse(input, out workTime);

                if (success)
                {
                    if (workTime == 999)
                    {
                        Console.WriteLine("입력을 종료합니다.");
                        break;
                    }

                    else if (workTime > 0)
                    {
                        que.Enqueue(workTime);
                    }
                    else
                    {
                        Console.WriteLine("양수를 입력해주세요.");
                    }
                }
                else
                {
                    Console.WriteLine("양의 정수를 입력해주세요");
                }
            }


            //이제 작업 시간이 저장된 queue가 생성되어있는 상태이다.
            //이제 dequeue를 반복하면서 8로 나눌때 마다 다음 일자로 넘어가는걸 만들면 될 것 같다.

            //int day = 1;
            //int time = 8;

            //while (que.Count > 0)
            //{
            //    int work = que.Dequeue();

            //    while (work > 0)
            //    {
            //        if (work <= time)
            //        {
            //            Console.WriteLine($"작업이 {day}일에 완료되었습니다.");
            //            time -= work;
            //            work = 0;
            //        }
            //        else
            //        {
            //            work -= time;
            //            Console.WriteLine($"작업이 {day}일차에 {time}만큼 완료되었습니다.");
            //            day++;
            //            time = 8;
            //        }
            //    }
            //}

            // 어렵다

        }
        #endregion

        static void Main(string[] args)
        {
            Console.Write("괄호를 검사할 문자열을 입력해주세요 : ");
            string input = Console.ReadLine();
            CheckCorrectBracket(input);

            WorkCalculater();
        }
    }
}
