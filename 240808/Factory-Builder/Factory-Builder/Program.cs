using System;

namespace Factory_Builder
{
    internal class Program
    {
        #region 과제1
        // 과제 1. 팩토리 메소드 패턴 활용하기


        //ItemType은 열거형으로 Potion, Weapon, Armor, Food 항목을 가진다
        public enum ItemType { Potion, Weapon, Armor, Food }

        //Item은 ItemFactory를 통해서 생성하도록 한다.
        public class ItemFactory
        {

            //ItemFactory는 Create(ItemType type) 함수를 가진다.
            //ItemFactory는 Create 함수에 매개변수로 받은 열거형의 유형을 기준으로 각 항목에 맞는 아이템 인스턴스를 생성하여 준다.
            public static Item Create(ItemType item)
            {
                if (item == ItemType.Potion)
                {
                    Potion potion = new Potion();
                    potion.name = "포션";
                    potion.price = 100;
                    potion.heelAmount = 100;
                    return potion;
                }
                else if (item == ItemType.Weapon)
                {
                    Weapon weapon = new Weapon();
                    weapon.name = "검";
                    weapon.price = 500;
                    weapon.atk = 10;
                    return weapon;
                }
                else if (item == ItemType.Armor)
                {
                    Armor armor = new Armor();
                    armor.name = "방어구";
                    armor.price = 400;
                    armor.def = 8;
                    return armor;
                }
                else
                {
                    Food food = new Food();
                    food.name = "음식";
                    food.price = 80;
                    food.heelAmount = 60;
                    return food;
                }
            }
        }

        public class Item
        {
            public string name;
            public int price;
        }

        public class Potion : Item
        {
            public int heelAmount;
        }

        public class Weapon : Item
        {
            public int atk;
        }

        public class Armor : Item
        {
            public int def;
        }

        public class Food : Item
        {
            public int heelAmount;
        }
        #endregion

        #region 과제2
        //과제 2. 빌더패턴 활용하기
        //MonsterBuilder 클래스를 만들어 몬스터의 이름, 외형, 전리품, 경험치, 공격범위, 전투스타일 등을 조합하여
        //여러 유형의 Monster들을 만들 수 있습니다.
        //AnimalBuilder 클래스를 만들어 동물의 이름, 외형, 생산품, 울음소리, 사료종류, 등을 조합하여
        //여러 유형의 Animal들을 만들 수 있습니다.
        //UnitBuilder 클래스를 만들어 유닛의 이름, 이동방법, 공격타입, 방어타입, 생산가격 등을 조합하여
        //여러 유형의 Unit들을 만들 수 있습니다.

        public class Monster
        {
            public string name;
            public string appearance;
            public int exp;
            public int range;
        }

        public class MonsterBuilder
        {
            public string name;
            public string appearance;
            public int exp;
            public int range;

            public MonsterBuilder()
            {
                name = "몬스터";
                appearance = "거대함";
                exp = 100;
                range = 5;
            }

            public Monster Build()
            {
                Monster monster = new Monster();
                monster.name = name;
                monster.appearance = appearance;
                monster.exp = exp;
                monster.range = range;
                return monster;
            }

            public void SetName(string name)
            { this.name = name; }

            public void SetAppearance(string appearance)
            { this.appearance = appearance; }

            public void SetExp(int exp)
            { this.exp = exp; }

            public void SetRange(int range)
            { this.range = range; }
        }

        static void Main(string[] args)
        {
            MonsterBuilder dragonBuilder = new MonsterBuilder();
            dragonBuilder.SetName("용");
            dragonBuilder.SetAppearance("무서움");
            dragonBuilder.SetExp(1000);
            dragonBuilder.SetRange(30);

            Monster[] dragons = new Monster[2]; 
            dragons[0] = dragonBuilder.Build();
            dragons[1] = dragonBuilder.Build();
        }
        #endregion
    }
}