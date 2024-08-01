using System.Numerics;

namespace _240801_Dictionary
{
    internal class Program
    {
        #region 과제 1
        //과제 1 몬스터 데이터베이스 구현하기

        //몬스터 클래스 생성, 인스턴스 생성 시 생성자를 사용해 데이터 초기화
        public class Monster
        {
            public string name;
            public int hp;

            public Monster(string name, int hp)
            {
                this.name = name;
                this.hp = hp;
            }
        }

        static void Main(string[] args)
        {
            //몬스터 이름의 string Key 값으로 딕셔너리에 저장, 5종류 이상
            Dictionary<string, Monster> monsterData = new Dictionary<string, Monster>();

            monsterData.Add("모르고트", new Monster("모르고트", 10399));
            monsterData.Add("라단", new Monster("라단", 9572));
            monsterData.Add("고드릭", new Monster("고드릭", 6080));
            monsterData.Add("모그", new Monster("모그", 14000));
            monsterData.Add("말레니아", new Monster("말레니아", 18473));

            #endregion

            #region 심화 과제
            //다음의 조건을 충족하는 MyDictionary<TKey, TValue> 클래스를 구현하시오
            //Dictionary<TKey, TValue> 클래스의 사용을 금지하며, 배열을 사용해 구현한다.
            //클래스의 인스턴스 생성 시 최초 193의 크기를 가진다.
            //충돌이 발생하는 경우 선형탐사를 통해 충돌상황을 해결한다.
            //공간 사용률이 70 % 를 넘기는 경우 재해싱 과정을 진행한다.
            //아래 필수 구현 메서드 외 내부 동작을 위한 필드 및 메서드 추가는 허용한다.
            //구현 메서드
            //Add(TKey key, TValue value) : 지정한 키를 기준으로 값을 추가한다.
            //Remove(TKey key) : 지정한 키를 기준으로 값을 찾아 삭제한다.
            //Contains(TKey key) : 지정한 키를 기준으로 값이 포함되어 있는지 확인한다.
        }
        public class MyDictionary
        {
            string[] myDictionary = new string[193];

            public MyDictionary()
            {
                string[] myDictionary = new string[193];
            }

            public void Add(int key, string value)
            {
                if (myDictionary[key] == null)
                {
                    for (key = 0; key < myDictionary.Length; key++)
                    {
                        myDictionary[key] = value;
                    }
                }
                else
                {
                    while (myDictionary[key] != null)
                    {
                        key = key++;
                    }
                }
            }

            if 
        }
    }
}
    #endregion