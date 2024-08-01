namespace _240801_Graph
{
    internal class Program
    {
        public abstract class Graph  //그래프로 나타낼 메서드 구현
        {
            public abstract void Connect(int from, int to);
            public abstract void DisConnect(int from, int to);
            public abstract bool IsConnect(int from, int to);
        }
        public class ListGraph : Graph //리스트그래프 구현과, 사용할 메서드 구현
        {
            private List<int>[] graph;

            public ListGraph(int vertex)
            {
                graph = new List<int>[vertex];
                for (int i = 0; i < vertex; i++)
                {
                    graph[i] = new List<int>();
                }
            }

            public override void Connect(int from, int to)
            {
                graph[from].Add(to);
            }

            public override void DisConnect(int from, int to)
            {
                graph[from].Remove(to);
            }

            public override bool IsConnect(int from, int to)
            {
                return graph[from].Contains(to);
            }
        }
        public class MatrixGraph : Graph // 행렬 그래프 구현과, 사용할 메서드 구현
        {
            private bool[,] graph;

            public MatrixGraph(int vertex)
            {
                graph = new bool[vertex, vertex];
            }

            public override void Connect(int from, int to)
            {
                graph[from, to] = true;
            }

            public override void DisConnect(int from, int to)
            {
                graph[from, to] = false;
            }

            public override bool IsConnect(int from, int to)
            {
                return graph[from, to];
            }
        }
        static void Main(string[] args)
        {
            // 사진 그래프 내용 리스트그래프로 만들기
            ListGraph listGraph = new ListGraph(8);

            listGraph.Connect(0, 3);
            listGraph.Connect(0, 4);

            listGraph.Connect(2, 4);
            listGraph.Connect(2, 6);

            listGraph.Connect(3, 7);

            listGraph.Connect(4, 6);
            listGraph.Connect(4, 7);

            listGraph.Connect(5, 7);

            listGraph.Connect(6, 2);
            listGraph.Connect(6, 5);
            listGraph.Connect(6, 7);

            listGraph.Connect(7, 6);
            

            //출력
            for (int i = 0; i < 8 ; i++)
            {
                Console.WriteLine($"{i}노드 : ");
                for (int j = 0; j < 8; j++)
                {
                    if (listGraph.IsConnect(i, j))
                    {
                        Console.WriteLine($"   {j}노드");
                    }
                }
            }

            // 사진 그래프 내용 행렬그래프로 만들기
            MatrixGraph matrixGraph = new MatrixGraph(8);
            matrixGraph.Connect(0, 3);
            matrixGraph.Connect(0, 4);

            matrixGraph.Connect(2, 4);
            matrixGraph.Connect(2, 6);

            matrixGraph.Connect(3, 7);

            matrixGraph.Connect(4, 6);
            matrixGraph.Connect(4, 7);

            matrixGraph.Connect(5, 7);

            matrixGraph.Connect(6, 2);
            matrixGraph.Connect(6, 5);
            matrixGraph.Connect(6, 7);

            matrixGraph.Connect(7, 6);

            for (int i = 0;i < 8 ; i++)
            {
                Console.WriteLine($"{i}노드 : ");
                for (int j = 0;j < 8; j++)
                {
                    if (matrixGraph.IsConnect(i, j))
                    {
                        Console.WriteLine($"   {j}노드");
                    }
                }
            }
        }
    }
}
