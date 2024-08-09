namespace _10.Shortest
{
    internal class Program
    {
        // 문제 10
        // ROR 게임은 두 팀으로 나누어서 진행하며, 상대 팀 진영을 먼저 파괴하면 이기는 게임입니다.
        // 따라서, 각 팀은 상대 팀 진영에 최대한 빨리 도착하는 것이 유리합니다.
        // 지금부터 당신은 한 팀의 팀원이 되어 게임을 진행하려고 합니다.
        // 다음은 5 x 5 크기의 맵에, 당신의 캐릭터가(행: 1, 열: 1) 위치에 있고,
        // 상대 팀 진영은(행: 5, 열: 5) 위치에 있는 경우의 예시입니다.
        // 위 그림에서 검은색 부분은 벽으로 막혀있어 갈 수 없는 길이며, 흰색 부분은 갈 수 있는 길입니다.
        // 캐릭터가 움직일 때는 동, 서, 남, 북 방향으로 한 칸씩 이동하며, 게임 맵을 벗어난 길은 갈 수 없습니다.
        // 아래 예시는 캐릭터가 상대 팀 진영으로 가는 두 가지 방법을 나타내고 있습니다.
        // 첫 번째 방법은 11개의 칸을 지나서 상대 팀 진영에 도착했습니다.
        // 두 번째 방법은 15개의 칸을 지나서 상대팀 진영에 도착했습니다.
        // 위 예시에서는 첫 번째 방법보다 더 빠르게 상대팀 진영에 도착하는 방법은 없으므로,
        // 이 방법이 상대 팀 진영으로 가는 가장 빠른 방법입니다.
        // 만약, 상대 팀이 자신의 팀 진영 주위에 벽을 세워두었다면 상대 팀 진영에 도착하지 못할 수도 있습니다.
        // 예를 들어, 다음과 같은 경우에 당신의 캐릭터는 상대 팀 진영에 도착할 수 없습니다.
        // 게임 맵의 상태 maps가 매개변수로 주어질 때, 캐릭터가 상대 팀 진영에 도착하기 위해서
        // 지나가야 하는 칸의 개수의 최솟값을 return 하도록 solution 함수를 완성해주세요.
        // 단, 상대 팀 진영에 도착할 수 없을 때는 -1을 return 해주세요.

        class Solution
        {
            // 너비 우선 탐색을 사용하면 될 것 같다.
            // 최단 경로가 보장되고, 가중치가 없기 때문이다.
            // 아래 수업에서 배운 BFS를 조금 수정해본다.
            /*
            public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parent)
            {
                int size = graph.GetLength(0);  // 그래프의 정점 갯수
                visited = new bool[size];       // 탐색 여부
                parent = new int[size];         // 정점을 탐색한 정점이 누구인지

                for (int i = 0; i < size; i++)  // 처음으로 가져야 하는 값들
                {
                    visited[i] = false;
                    parent[i] = -1;
                }

                Queue<int> queue = new Queue<int>();  // 앞으로 탐색해야하는 정점들의 대기열
                queue.Enqueue(start);                 // 처음으로 탐색해야하는 시작 정점
                visited[start] = true;                // 탐색 여부 체크

                while (queue.Count > 0)               // 대기열에 아무것도 없을때 까지
                {
                    int vertex = queue.Dequeue();     // 다음으로 탐색해야하는 정점이 나온다.

                    for (int i = 0; i < size; i++)    // 모든 정점들을 확인해서
                    {
                        if (graph[vertex, i] == true && visited[i] == false) //  연결되어 있는                                                            정점 && 찾은적 없는 정점
                        {
                            visited[i] = true;        // 탐색여부 체크
                            parent[i] = vertex;       // 탐색하게 되는 정점을 표시
                            queue.Enqueue(i);         // 탐색해야하는 정점을 대기열에 추가
                        }
                    }
                }
            }
            */
            

            public int solution(int[,] maps)
            {
                int x = maps.GetLength(0);
                int y = maps.GetLength(1);
                int size = x * y;
                int start = maps[0, 0];
                int distance;

                bool[] visited = new bool[size];
                int[] parents = new int[size];

                for (int i = 0; i < size; i++ )
                {
                    visited[i] = false;
                    parents[i] = -1;
                }

                Queue<int> queue = new Queue<int>();
                queue.Enqueue(start);
                visited[start] = true;

                while (queue.Count > 0)
                {
                    int vertex = queue.Dequeue();

                    for (int i = 0; i < size; i++)
                    {
                        visited[i] = true;
                        parents[i] = vertex;
                        queue.Enqueue(vertex);
                    }
                }
            }
            // x, y 좌표 조절하는게 감이 안온다.
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
