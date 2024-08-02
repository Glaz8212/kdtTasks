namespace Item_Shop
{
    internal class Program
    {
        #region 아이템 클래스
        public class Item
        {
            public string name { get; set; }
            public string description { get; set; }
            public int price { get; set; }
            public int hpPlus { get; set; }
            public int defPlus { get; set; }
            public int atkPlus { get; set; }

            public Item(string name, string description, int price, int hpPlus = 0, int atkPlus = 0, int defPlus = 0)
            {
                this.name = name;
                this.description = description;
                this.price = price;
                this.hpPlus = hpPlus;
                this.defPlus = defPlus;
                this.atkPlus = atkPlus;
            }
        }

        public class LongSword : Item
        {
            public LongSword() : base("롱소드", "기본적인 검이다. 소유하고 있으면, 공격력이 15 상승한다.", 400, atkPlus: 15)
            {
            }
        }
        public class ClothArmor : Item
        {
            public ClothArmor() : base("천갑옷", "천으로 만든 갑옷이다. 소유하고 있으면, 방어력이 15 상승한다.", 500, defPlus: 15)
            {
            }
        }
        public class Necklace : Item
        {
            public Necklace() : base("목걸이", "비싼 보석이 박힌 목걸이다. 소유하고 있으면, 최대체력이 300 상승한다.", 600, hpPlus: 300)
            {
            }
        }
        public class WeirdCandy : Item
        {
            public WeirdCandy() : base("이상한 사탕", "이상한 맛이 나는 사탕이다. 사용하면, 최대체력이 300 상승한다.", 800, hpPlus: 300)
            {
            }
        }
        #endregion

        #region 플레이어 클래스
        public class Player
        {
            public int hp { get; set; }
            public int def { get; set; }
            public int atk { get; set; }
            public int money { get; set; }
            public List<Item> inventory { get; set; }

            public Player()
            {
                money = 3000;
                inventory = new List<Item>();
                hp = 1000;
                def = 50;
                atk = 50;
            }

            public int plusedHp
            {
                get
                {
                    int curHp = hp;
                    foreach (Item item in inventory)
                    {
                        curHp += item.hpPlus;
                    }
                    return curHp;
                }
            }
            public int plusedAtk
            {
                get
                {
                    int curAtk = atk;
                    foreach (Item item in inventory)
                    {
                        curAtk += item.atkPlus;
                    }
                    return curAtk;
                }
            }
            public int plusedDef
            {
                get
                {
                    int curDef = def;
                    foreach (Item item in inventory)
                    {
                        curDef += item.defPlus;
                    }
                    return curDef;
                }
            }
            public void EatCandy(Item item)
            {
                if (item.name == "이상한 사탕")
                {
                    hp += item.hpPlus;
                    inventory.Remove(item);
                    Console.WriteLine("이상한 사탕을 사용했습니다. 체력이 300 증가합니다.");
                }
            }
        }
        #endregion

        #region 구매
        static void Purchase(List<Item> salesList, Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== 아이템 구매 ======");
                Console.WriteLine($"보유한 골드 = {player.money}");
                Console.WriteLine();

                for (int i = 0; i < salesList.Count; i++)
                {
                    Item item = salesList[i];
                    Console.WriteLine($"{i + 1}. {item.name}");
                    Console.WriteLine($"  가격 = {item.price}");
                    Console.WriteLine($"  설명 = {item.description}");
                    Console.WriteLine();
                }

                Console.Write("구매할 아이템을 선택하세요 (뒤로가기 0) : ");
                int input;
                int.TryParse(Console.ReadLine(), out input);

                switch (input)
                {
                    case 0:
                        return;
                    default:
                        if (input <= salesList.Count)
                        {
                            Item selectedItem = salesList[input - 1];
                            if (player.money >= selectedItem.price)
                            {
                                player.money -= selectedItem.price;
                                player.inventory.Add(selectedItem);
                                Console.WriteLine($"{selectedItem.name}을 구매했습니다.");
                            }
                            else
                            {
                                Console.WriteLine("보유한 골드가 부족합니다.");
                            }
                        }
                        break;
                }
                Thread.Sleep(10 * 100);
            }
        }
        #endregion

        #region 판매
        static void Sale(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== 아이템 판매 ======");
                Console.WriteLine($"보유한 골드 = {player.money}");
                Console.WriteLine();

                for (int i = 0; i < player.inventory.Count; i++)
                {
                    Item item = player.inventory[i];
                    Console.WriteLine($"{i + 1}. {item.name}");
                    Console.WriteLine($"  가격 = {item.price}");
                    Console.WriteLine($"  설명 = {item.description}");
                    Console.WriteLine();
                }

                Console.Write("판매할 아이템을 선택하세요 (뒤로가기 0) : ");
                int input;
                int.TryParse(Console.ReadLine(), out input);

                switch (input)
                {
                    case 0:
                        return;
                    default:
                        {
                            if (input <= player.inventory.Count)
                            {
                                Item selectedItem = player.inventory[input - 1];
                                player.money += selectedItem.price;
                                player.inventory.Remove(selectedItem);
                                Console.WriteLine($"{selectedItem.name}을 판매했습니다.");
                            }
                        }
                        break;
                }
                Thread.Sleep(10 * 100);
            }
        }
        #endregion

        #region 인벤토리확인
        static void CheckInventory(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== 인벤토리 확인 ======");
                for (int i = 0; i < player.inventory.Count; i++)
                {
                    Item item = player.inventory[i];
                    Console.WriteLine($"{i + 1}. {item.name}");
                    Console.WriteLine($"  가격 = {item.price}");
                    Console.WriteLine($"  설명 = {item.description}");
                    Console.WriteLine();
                }
                Console.WriteLine("현재 상태 : ");
                Console.WriteLine($"체력 : {player.plusedHp}");
                Console.WriteLine($"공격력 : {player.plusedAtk}");
                Console.WriteLine($"방어력 : {player.plusedDef}");

                Console.WriteLine();
                Console.WriteLine("사용할 아이템 번호를 입력하세요 (뒤로가기 0) : ");

                int input;
                int.TryParse(Console.ReadLine(), out input);

                switch (input)
                {
                    case 0:
                        return;
                    default:
                        if (input <= player.inventory.Count)
                        {
                            Item selectedItem = player.inventory[input - 1];
                            player.EatCandy(selectedItem);
                        }
                        break;
                }
                Thread.Sleep(10 * 100);
            }
        }
        #endregion
        static void Main(string[] args)
        {
            Player player = new Player();
            List<Item> salesList = new List<Item> { new LongSword(), new ClothArmor(), new Necklace(), new WeirdCandy(), };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== 아이템 상점 ======");
                Console.WriteLine();
                Console.WriteLine("====== 상점   메뉴 ======");
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("3. 인벤토리 확인");
                Console.Write("메뉴를 선택하세요 : ");

                int input;
                int.TryParse(Console.ReadLine(), out input);

                switch (input)
                {
                    case 1:
                        Purchase(salesList, player);
                        break;
                    case 2:
                        Sale(player);
                        break;
                    case 3:
                        CheckInventory(player);
                        break;
                    default:
                        break;

                // 이상한 사탕 먹는게 뭔가 제대로 작동 안하는데 이유를 못 찾겠어요 ..
                }
            }
        }
    }
}
