using System.Timers;

namespace _240723_Oop4Principle_Deepen
{
    internal class Program
    {
        // 과제1. 트레이너와 몬스터 제작하기

        // 과제1-1.열거형 MobType 제작.
        enum Mobtype
        {
            Electric, Fire, Water, Grass
        }

        // 과제1-1. 추상클래스 Monster 구현
        abstract class Monster
        {
            protected int level;                          // 정수형 레벨
            protected Mobtype mobtype;                    // 열거형 몹타입
            public string name;                           // 문자열 이름

            public abstract void BaseAttack();            // abstract 메서드 추가

            public Monster(int level, Mobtype mobtype, string name)
            {
                this.level = level;
                this.mobtype = mobtype;
                this.name = name;
            }
        }

        //1-2.자식 클래스 구현
        class Pikachu : Monster
        {
            public Pikachu(int level, string name) : base(level, Mobtype.Electric, name)
            { }
            public override void BaseAttack()
            {
                Console.WriteLine($"{name} : '전광석화'");
            }
        }
        class Squirtle : Monster
        {
            public Squirtle(int level, string name) : base(level, Mobtype.Water, name)
            { }
            public override void BaseAttack()
            {
                Console.WriteLine($"{name} : '물총발사'");
            }
        }
        class Bulbasaur : Monster
        {
            public Bulbasaur(int level, string name) : base(level, Mobtype.Grass, name)
            { }
            public override void BaseAttack()
            {
                Console.WriteLine($"{name} : '덩굴채찍'");
            }
        }
        class Charmander : Monster
        {
            public Charmander(int level, string name) : base(level, Mobtype.Fire, name)
            { }
            public override void BaseAttack()
            {
                Console.WriteLine($"{name} : '화염방사'");
            }
        }

        //1-3 트레이너 구현
        class Trainer
        {
            Monster[] monsters = new Monster[6];

            public Trainer()
            {
                monsters[0] = new Pikachu(1, "피카츄");
            }

            public void AddMonster(Monster input, int i)
            {
                if (monsters[i] == null)
                {
                    monsters[i] = input;
                    Console.WriteLine($"{i + 1}번째 칸에 {input.name}을 추가했습니다.");
                    return;
                }
            }

            public void AllAttack()
            {
                for (int i = 0; i < monsters.Length; i++)
                {
                    if (monsters[i] != null)
                    {
                        monsters[i].BaseAttack();
                    }
                }
            }
            static void Main(string[] args)
            {
                Trainer trainer = new Trainer();
                Charmander charmander = new Charmander(5, "파이리");
                trainer.AddMonster(charmander, 4);
                trainer.AllAttack();
            }
        }
    }
}
