namespace Move_on_a_Map
{
    internal class Program
    {
        public class Map
        {
            public string name;
            private List<Map>[] map;

            // 맵 배열
            public Map(string name, int vertex)
            {
                this.name = name;
                map = new List<Map>[vertex];

                for (int i = 0; i < map.Length; i++)
                {
                    map[i] = new List<Map>();
                }
            }

            // 맵 연결 메서드
            public void Connect(int from, Map toMap)
            {
                map[from].Add(toMap);
            }


            // 연결된 리스트
            public List<Map> Connected()
            {
                List<Map> connected = new List<Map>();
                foreach (var places in map)
                {
                    connected.AddRange(places);
                    //AddRange : 한번에 다수의 요소 추가
                    //https://learn.microsoft.com/ko-kr/dotnet/api/system.collections.generic.list-1.addrange?view=net-8.0
                }
                return connected;
            }
        }

        static void Main(string[] args)
        {
            // 맵 생성
            Map[] maps = new Map[8];
            maps[0] = new Map("마을", 8);
            maps[1] = new Map("성", 8);
            maps[2] = new Map("묘지", 8);
            maps[3] = new Map("초원", 8);
            maps[4] = new Map("바다", 8);
            maps[5] = new Map("숲", 8);
            maps[6] = new Map("상점", 8);
            maps[7] = new Map("길드", 8);

            // 맵 연결
            maps[0].Connect(0, maps[1]);
            maps[0].Connect(0, maps[2]);

            maps[1].Connect(1, maps[0]);
            maps[1].Connect(1, maps[2]);
            maps[1].Connect(1, maps[3]);
            maps[1].Connect(1, maps[5]);
            maps[1].Connect(1, maps[7]);

            maps[2].Connect(2, maps[0]);
            maps[2].Connect(2, maps[1]);
            maps[2].Connect(2, maps[3]);
            maps[2].Connect(2, maps[4]);

            maps[3].Connect(3, maps[1]);
            maps[3].Connect(3, maps[2]);
            maps[3].Connect(3, maps[4]);
            maps[3].Connect(3, maps[5]);

            maps[4].Connect(4, maps[2]);
            maps[4].Connect(4, maps[3]);
            maps[4].Connect(4, maps[6]);

            maps[5].Connect(5, maps[1]);
            maps[5].Connect(5, maps[3]);
            maps[5].Connect(5, maps[6]);
            maps[5].Connect(5, maps[7]);

            maps[6].Connect(6, maps[4]);
            maps[6].Connect(6, maps[5]);
            maps[6].Connect(6, maps[7]);

            maps[7].Connect(7, maps[1]);
            maps[7].Connect(7, maps[5]);
            maps[7].Connect(7, maps[4]);

            Map place = maps[0];
            // 방문한 경로 배열 생성
            Queue<Map> visited = new Queue<Map>();

            while (true)
            {
                Console.WriteLine("======== 맵 이동 ========");
                Console.WriteLine();
                Console.WriteLine($"현재 위치 = {place.name}");
                Console.Write("방문한 경로 : ");
                foreach (Map visitedplace in visited)
                {
                    Console.Write($"{visitedplace.name} -> ");
                }
                Console.WriteLine();
                Console.WriteLine();
                // 연결 된 장소 출력
                List<Map> connections = place.Connected();
                for (int i = 1; i <= connections.Count; i++)
                {
                    Console.WriteLine($"{i}. {connections[i - 1].name}");
                }
                Console.WriteLine();
                Console.Write("이동할 장소를 선택하세요. (뒤로가기 0) : ");

                int input;
                int.TryParse(Console.ReadLine(), out input);

                // 입력값이 정상적이면 이동, 방문한 목록 쌓기
                if (0 <= input && input <= connections.Count)
                {
                    switch (input)
                    {
                        case 0:
                            place = visited.Dequeue();
                            visited.Enqueue(place);
                            break;
                        default:
                            visited.Enqueue(place);
                            place = connections[input - 1];
                            break;
                    }
                }

                Console.Clear();
            }
        }
    }
}
