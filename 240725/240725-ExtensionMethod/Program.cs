namespace ExtensionMethod
{
    public class Program
    {
        public static void Main()
        {
            Console.Write ("아이디를 입력하세요 : ");
            string id = Console.ReadLine();

            if (id.IsAllowedID())
            {
                Console.WriteLine("ID가 유효합니다.");
            }
            else
            {
                Console.WriteLine("ID에 허용되지 않는 특수문자가 있습니다.");
            }
        }
    }

    public static class Extension
    {
        public static bool IsAllowedID(this string id)
        {
            char[] chararray = { '!', '@', '#', '$', '%', '^', '&', '*' };
            foreach (char special in chararray)
            {
                if (id.Contains(special))
                {
                    return false;
                }
            }
            return true;
        }
    }
}