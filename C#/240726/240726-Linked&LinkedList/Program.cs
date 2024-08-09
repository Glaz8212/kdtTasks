using System.Security.Cryptography.X509Certificates;

namespace _240726
{
    internal class Program
    {
        #region 과제1
        //과제1
        //
        //프로그램 시작 시 인벤토리는 빈 상태에서 시작한다.
        //프로그램이 구동되는 동안 입력마다 콘솔에 지속적으로 인벤토리의 상태를 표시한다
        //인벤토리는 최대 9개의 아이템을 가질 수 있다.
        //인벤토리는 빈칸 없이 앞부터 채워서 가진다
        //숫자키 0을 누르면 랜덤으로 아이템의 종류를 획득하고 인벤토리에 추가한다
        //숫자키 1~9를 누르면 해당하는 숫자의 아이템을 제거한다
        //구현 클래스
        //Inventory
        //Item
        //Potion : Item
        //Weapon : Item
        //Armor : Item
        //Accessory : Item
        //Food : Item

        #region 아이템 클래스
        public class Item
        {
            public string _name { get; set; }

            public Item(string name)
            {
                _name = name;
            }
        }

        public class Potion : Item
        {
            public Potion() : base("포션") { }
        }

        public class Weapon : Item
        {
            public Weapon() : base("무기") { }
        }
        public class Armor : Item
        {
            public Armor() : base("방어구") { }
        }
        public class Accessory : Item
        {
            public Accessory() : base("장신구") { }
        }
        public class Food : Item
        {
            public Food() : base("음식") { }
        }
        #endregion

        #region 1에서 5까지 랜덤 추출
        static int Rand1to5()
        {
            Random random = new Random();
            return random.Next(1, 6);
        }
        #endregion

        #region 아이템 얻기
        static Item GetRandomItem()
        {
            switch (Rand1to5())
            {
                case 1:
                    return new Potion();
                case 2:
                    return new Weapon();
                case 3:
                    return new Accessory();
                case 4:
                    return new Food();
                case 5:
                    return new Armor();
                default:
                    return null;
            }
        }
        #endregion

        #region 인벤토리
        public class Inventory
        {
            public List<Item> inventory = new List<Item>(9);

            public void Add(Item item)
            {
                if (inventory.Count < 9)
                {
                    inventory.Add(item);
                    Console.WriteLine($"{item._name}이/가 인벤토리에 추가되었습니다.");
                }
                else
                {
                    Console.WriteLine("인벤토리가 가득 찼습니다.");
                }
            }

            public void Remove(int index)
            {
                Item item = inventory[index - 1];
                inventory.RemoveAt(index - 1);
                Console.WriteLine($"{item._name}이/가 인벤토리에서 제거되었습니다.");
            }

            public void Write()
            {
                Console.Write("인벤토리 : ");
                foreach (Item item in inventory)
                {
                    Console.Write($"{item._name} ");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region 본문
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            while (true)
            {
                Console.WriteLine("0을 누르시면 아이템이 랜덤으로 추가되며, 1~9를 누르시면 해당 아이템이 제거됩니다.");
                ConsoleKeyInfo input = Console.ReadKey(true);
                int value;
                int.TryParse(input.KeyChar.ToString(), out value);

                if (value == 0)
                {
                    inventory.Add(GetRandomItem());
                    inventory.Write();
                }
                else if (1 <= value && value <= 9)
                {
                    int index = value;
                    inventory.Remove(index);
                    inventory.Write();
                }
                else
                {
                    Console.WriteLine("잘 못 입력하셨습니다");
                }
            }
        }
        #endregion
        #endregion


        #region 과제2
        //과제2
        //
        //1번부터 N번까지 N명의 사람이 원을 이루면서 앉아있고, 양의 정수 K(≤ N)가 주어진다.
        //이제 순서대로 K번째 사람을 제거한다.
        //한 사람이 제거되면 남은 사람들로 이루어진 원을 따라 이 과정을 계속해 나간다.
        //이 과정은 N명의 사람이 모두 제거될 때까지 계속된다.
        //원에서 사람들이 제거되는 순서를 (N, K)-요세푸스 순열이라고 한다.
        //예를 들어 (7, 3)-요세푸스 순열은 <3, 6, 2, 7, 5, 1, 4>이다.
        //
        //아래의 요세푸스 순열에 대한 설명을 보고 N와 K 가 주어지면 결과를 출력하는 프로그램으로 구현하시오.


        static string Josephus(int x, int y)
        {
            LinkedList<int> josephus = new LinkedList<int>();
            List<int> josephusList = new List<int>();
            
            for (int i = 1; i <= x; i++)
            {
                josephus.AddLast(i);
            }

            LinkedListNode<int> here = josephus.First;

            while (josephus.Count > 0)
            {
                for (int i = 1; i < y; i++)
                {
                    if (here.Next != null)
                    {
                        here = here.Next;
                    }
                    else
                    {
                        here = josephus.First;
                    }
                }

                josephusList.Add(here.Value);

                josephus.Remove(here);

            }

            string returnJosephus;
            
            foreach (int i in josephusList)
            {
                Console.WriteLine($"{i}");
            }
        }
    }
}
#endregion
