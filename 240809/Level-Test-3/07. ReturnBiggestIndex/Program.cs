namespace ReturnBiggestIndex
{
    internal class Program
    {
        // 문제 7.
        // 정수 배열 array가 매개변수로 주어질 때,
        // 가장 큰 수와 그 수의 인덱스를 담은 배열을 return 하도록 solution 함수를 완성해보세요.
        public class Solution
        {
            public int[] solution(int[] array)
            {
                int[] answer = new int[2];
                // 첫 번째 데이터 = 가장 큰 수
                answer[0] = array.Max();
                // 두 번째 데이터 = 그 수의 인덱스
                answer[1] = Array.IndexOf(array, answer[0]);
                return answer;
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
