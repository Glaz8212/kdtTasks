namespace _240722_Constructor
{
    internal class Program
    {
        // 과제1. 트레이너와 몬스터 제작하기

        class Trainer
        {
            string name;
            Monster[] monsters;

            public Trainer(string name)
            {
                this.name = name;               // 트레이너 인스턴스 생성 시, 트레이너의 이름이 초기화된다.
                this.monsters = new Monster[6]; // 트레이너는 최대 6마리의 몬스터를 가질 수 있다.
            }
        }

        class Monster
        {
            int hp;

            public Monster(int hp)
            {
                this.hp = hp;                   // 트레이너가 몬스터 생성 시, 체력을 지정 값으로 초기화 한다.
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
