namespace Monster_Attack
{
    internal class Program
    {
        public class Monster
        {
            public string name;
            protected string skill;

            public Monster(string name)
            {
                this.name = name;
            }

            public void Attack()
            {   
                Console.WriteLine($"{skill}!");
            }
        }

        public class Pikachu : Monster
        {
            public Pikachu(string name = "피카츄") : base(name)
            {
                skill = "백만볼트";
            }
        }
        public class Charmander : Monster
        {
            public Charmander(string name = "파이리") : base(name)
            {
                skill = "화염방사";
            }
        }
        public class Squirtle : Monster
        {
            public Squirtle(string name = "꼬북이") : base(name)
            {
                skill = "물총발사";
            }
        }
        public class Bulbasaur : Monster
        {
            public Bulbasaur(string name = "이상해씨") : base(name)
            {
                skill = "덩쿨채찍";
            }
        }
        static void Main(string[] args)
        {
            Monster[] monsters = new Monster[5];
            monsters[0] = new Pikachu();
            monsters[1] = new Charmander();
            monsters[2] = new Squirtle();
            monsters[3] = new Bulbasaur();
            monsters[4] = new Pikachu("털뭉치");

            foreach (Monster monster in monsters)
            {
                Console.WriteLine($"{monster.name} 공격해!");
                monster.Attack();
                Console.WriteLine();
            }
        }
    }
}
