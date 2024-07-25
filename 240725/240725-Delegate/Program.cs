namespace _240725_Delegate
{
    internal class Program
    {

        //과제 1
        public class Player
        {
            private Armor curArmor;

            public void Equip(Armor armor)
            {
                Console.WriteLine($"플레이어가 {armor.name} 을/를 착용합니다.");
                curArmor = armor;
                curArmor.OnBreaked += UnEquip;
            }

            public void UnEquip()
            {
                Console.WriteLine($"플레이어가 {curArmor.name} 을/를 해제합니다.");
                curArmor.OnBreaked -= UnEquip;
                curArmor = null;

            }

            public void Hit()
            {
                // 1. 플레이어가 피격을 받을 때마다 착용중인 갑옷의 내구도를 1씩 감소시킨다.
                Console.WriteLine($"플레이어가 피격을 받아 {curArmor.name} 의 내구도가 1 감소했습니다.");
                curArmor.DecreaseDurability();
            }
        }

        public class Armor
        {
            public string name;
            private int durability;

            public event Action OnBreaked;

            public Armor(string name, int durability)
            {
                this.name = name;
                this.durability = durability;
            }

            public void DecreaseDurability()
            {
                durability--;
                if (durability <= 0)
                {
                    Break();
                }
            }

            private void Break()
            {
                // 2. 갑옷의 내구도가 0이 될 때, 플레이어가 갑옷을 UnEquip하도록 한다.
                Console.WriteLine($"{name} 이/가 파괴되었습니다.");
                
                if(OnBreaked != null)
                {
                    OnBreaked();
                }
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Armor ammor = new Armor("갑옷", 3);

            player.Equip(ammor);

            player.Hit();
            player.Hit();
            player.Hit();
        }

    }
}
