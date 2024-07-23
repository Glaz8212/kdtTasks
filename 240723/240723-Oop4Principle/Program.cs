namespace _240723_Oop4Principle
{
    internal class Program
    {
        abstract class Firearm
        {
            public float ammo;
            string[] modes = new string[3]
            { "단발" , "연사" , "점사" };
            string name;

            public Firearm(float ammo, string name)
            {
                this.ammo = ammo;
                this.name = name;
            }
            public void Shot()
            {
                Console.WriteLine($"{name} 총기가 {ammo} 총알을 발사합니다. ");
            }

            public abstract void Reload(); // virtual 키워드 : 추상메서드로 선언
                      

            public void Zoom()
            {
                Console.WriteLine("조준기를 통해 적을 바라봅니다.");
            }
        }

        class AKM : Firearm
        {
            public AKM() : base(7.62f, "AKM") 
            {
            }

            public override void Reload() // override 키워드 : 재정의
            {
                Console.WriteLine("30발을 재장전 합니다.");
            }
        }

        class M416 : Firearm
        {
            public M416() : base(5.56f, "M416")
            {
            }

            public override void Reload() // override 키워드 : 재정의
            {
                Console.WriteLine("30발을 재장전 합니다.");
            }
        }
        class AWM : Firearm
        {
            public AWM() : base(0.300f, "AWM")
            {
            }

            public override void Reload() // override 키워드 : 재정의
            {
                Console.WriteLine("5발을 재장전 합니다.");
            }
        }

        // 과제 2.
        // 추상클래스의 정의.
        //
        // 추상클래스란 미완성된 클래스를 말한다. 
        // 미완성된 클래스라는것은 미완성된 메소드를 포함하고 있다는 뜻이다.
        // 추상클래스의 목적은 자식클래스에서 공유할 수 있도록 부모클래스의 공통적인 정의를 제공하는 것이다.
        // 추상클래스 안에서 선언되는 모든 변수, 메소드들은 접근 제한자를 적지 않으면 private이다.
        //
        // 오버로딩의 정의.
        //
        // 오버로딩이란 하나의 메소드로 여러개의 구현을 과적 하는것을 말한다.
        // 오버로딩은 같은 메소드 이름으로 매개 변수의 개수 또는 타입을 다르게 정의할 수 있다.
        // 오버로딩을 활용하면 메소드 이름을 새로 지을 필요가 없을 뿐 아니라, 코드를 일관성 있게 유지해준다.
        //
        // 오버라이딩의 정의.
        //
        // 오버라이딩은 부모 클래스에서 물려받은 메소드를 자식 클래스에서 재정의하는 것이다.
        // 오버라이딩을 하게되면 부모 클래스의 메소드보다 자식 클래스의 메소드가 우선시된다.
        // 오버라이딩을 하게되면 객체 지향 프로그래밍에서 다향성을 구현할 수 있다.
        // 오버라이딩을 위해서는 메소드가 virtual 키워드로 한정되어 있어야 하고, 오버라이딩하는 메소드는 override 키워드로 한정해주어야 한다.
        // 또한, private 키웓로 한정된 매소드는 오버라이딩 할 수 없다.
       
        static void Main(string[] args)
        {
            AKM akm = new AKM();
            M416 m416 = new M416();
            AWM awm = new AWM();

            akm.Shot();
            akm.Reload();
            akm.Zoom();
            Console.WriteLine();
            m416.Shot();
            m416.Reload();
            m416.Zoom();
            Console.WriteLine();
            awm.Shot(); 
            awm.Reload();
            awm.Zoom();
        }
    }
}
