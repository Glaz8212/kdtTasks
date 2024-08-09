namespace Hate_Same_Number
{
    internal class Program
    {
        public static List<int> Solution(List<int> array)
        {
            List<int> result = new List<int>();

            result = array;

            for (int i = 0; i < result.Count-1; i++)
            {
                if (result[i] == result[i+1])
                {
                    result.Remove(result[i+1]);
                }
            }

            return result;
        }
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1,1,3,4,4,2,2 };

            List<int> result = Solution(ints);

            foreach (int i in result)
            {
                Console.Write($"{i}, ");
            }
        }
    }
}
