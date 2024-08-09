namespace ArrangeString
{
    internal class Program
    {
        // 문제 9
        // 문자열로 구성된 리스트 strings와, 정수 n이 주어졌을 때,
        // 각 문자열의 인덱스 n번째 글자를 기준으로 오름차순 정렬하려 합니다.
        // 예를 들어 strings가 ["sun", "bed", "car"]이고 n이 1이면
        // 각 단어의 인덱스 1의 문자 "u", "e", "a"로 strings를 정렬합니다.
        public class Solution
        {
            public string[] solution(string[] strings, int n)
            {
                string[] answer = strings.OrderBy(str => str[n]).ThenBy(str=>str).ToArray();
                //LINQ사용 https://learn.microsoft.com/ko-kr/dotnet/csharp/linq/how-to-query-strings
                //orderby https://learn.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/orderby-clause
                //thenby  https://learn.microsoft.com/ko-kr/dotnet/api/system.linq.enumerable.thenby?view=net-8.0

                /* // 정렬을 이용해서 풀기
                 * https://learn.microsoft.com/ko-kr/dotnet/api/system.string.compareto?view=net-8.0
                 * // CompareTo 메서드
                 * 
                 * // 비교 메서드 만들기
                 * public int Compare(string a, string b)
                 * {
                 *      char x = a[n]
                 *      char y = b[n]
                 *      
                 *      // x가 y보다 작으면 -
                 *      // x가 y보다 크면 +
                 *      
                 *      int result = x.CompareTo(y);
                 * 
                 *      // 비교값이 0이면 (즉 자릿수가 같으면)
                 *      if (result == 0)
                 *      {
                 *          // n번째 문자가 아닌 string을 비교
                 *          return a.CompareTo(b);
                 *      }
                 *      
                 *      return result;
                 * }
                 * 
                 * // solution 함수 내부에
                 * 
                 * Array.Sort(strings, Compare);
                 * 
                 * return strings;
                 * 
                 */

                return answer;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
