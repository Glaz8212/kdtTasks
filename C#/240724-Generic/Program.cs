namespace _240724_Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory<Potion> potionInventory = new(10);  // <Potion>이 들어가는 인벤토리 배열 생성
                                                          // <Potion : Item> 이므로 사용 가능
            potionInventory.Add(new Potion("체력 포션"));
            potionInventory.Add(new Potion("마나 포션"));
            potionInventory.Add(new Potion("경험치 포션"));
            potionInventory.Add(new Potion("활력 포션"));

            potionInventory.Remove();
            potionInventory.Remove();

            potionInventory.PrintItemNames();
        }
    }
    public abstract class Item                            // 추상 클래스 Item 생성
    {                                                     //
        public string Name { get; private set; }          // 아이템 이름 저장
                                                          //
        public Item(string name)                          // 생성자에서 이름 초기화
        { this.Name = name; }                             //
    }                                                     //
                                                          //
    public class Potion : Item                            // 아이템의 자식 클래스인 포션클래스 생성
    {                                                     //
        public Potion(string name) : base(name) { }       // 생성자에서 이름 초기화
    }                                                     //
                                                          //
    public class Inventory<T> where T : Item              // 클래스에 자체를 제네릭으로 설정
    {                                                     //
        public T[] _list;                                 // 배열을 제네릭으로 생성
        public int _index;                                // 현재 가리키고 있는 데이터를 저장할 변수 선언
                                                          //
                                                          //
        public Inventory(int size)                        // 생성자에서 크기 초기화
        {                                                 //
            _list = new T[size];                          // 제네릭 배열 생성, 인자는 배열의 크기
        }                                                 //
                                                          //
        public void Add(T item)                           // 아이템 추가 메서드 생성
        {                                                 //
            if (_index < _list.Length)                    // 배열 내에 인덱스가 있을 경우
            {                                             //
                _list[_index] = item;                     // 아이템 추가
                _index++;                                 // 이동
            }                                             //
                                                          //
        }                                                 //
        public void Remove()                              // 아이템 제거 메서드 생성
        {                                                 //
            if (_index > 0)                               // 인덱스가 0보다 클 경우
            {                                             //
                _index--;                                 // 이동
                _list[_index] = null;                     // 아이템 비우기
            }                                             //
        }                                                 //
                                                          //
        public void PrintItemNames()                      // 모든 아이템 이름 출력 메서드 생성
        {                                                 //
            Console.WriteLine("아이템 목록 :");            //
                                                          //
            foreach (T item in _list)                     // 리스트에 있는 모든 아이템클래스에 대해
            {                                             //
                if (item != null)                         // 비어있지 않으면
                {                                         //
                    Console.WriteLine(item.Name);         // 이름 출력
                }
            }
        }
    }
}