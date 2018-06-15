using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Symbols
{
    public class TypesHelper
    {
        public TypesTable<bool> PromotionTable { get; private set; }

        public TypesTable<IType> ResultTable { get; private set; }
        
        private IDictionary<IType, int> ind = new Dictionary<IType, int>();

        private IDictionary<int, IType> revind = new Dictionary<int, IType>();

        private List<List<int>> list = new List<List<int>>();

        private int[,] graph;

        private int[,] result;

        private void AddVertex(IType type)
        {
            int id = ind.Count;
            ind.Add(type, id);
            revind.Add(id, type);
            list.Add(new List<int>());
        }

        private void AddEdge(IType start, IType end)
        {
            if (ind.ContainsKey(start) && ind.ContainsKey(end))
            {
                int startId = ind[start];
                int endId = ind[end];
                list[startId].Add(endId);
            }
            else
            {

            }
        }

        private void Generate()
        {
            int vertices = list.Count;
            graph = new int[vertices, vertices];
            for (int v = 0; v < vertices; ++v)
            {
                graph[v, v] = 1;
                foreach (int u in list[v])
                {
                    graph[v, u] = 1;
                }
            }

            RoyWarshall(graph);

            result = new int[vertices, vertices];
            for (int v = 0; v < vertices; ++v)
            {
                for (int u = 0; u < vertices; ++u)
                {
                    result[v, u] = ClosestCommonSuccessor(v, u);
                }
            }

            PromotionTable = new TypesTable<bool>();
            ResultTable = new TypesTable<IType>();
            for (int i = 0; i < vertices; ++i)
            {
                for (int j = 0; j < vertices; ++j)
                {
                    PromotionTable[revind[i], revind[j]] = graph[i, j] != 0;
                    int res = result[i, j];
                    if (res == -1)
                    {
                        ResultTable[revind[i], revind[j]] = null;
                    }
                    else
                    {
                        ResultTable[revind[i], revind[j]] = revind[result[i, j]];
                    }
                }
            }
        }

        private void RoyWarshall(int[,] graph)
        {
            int vertices = list.Count;
            for (int i = 0; i < vertices; ++i)
                for (int j = 0; j < vertices; ++j)
                    for (int k = 0; k < vertices; ++k)
                        if (graph[j, k] == 0)
                            graph[j, k] = graph[j, i] * graph[i, k];
        }

        private int ClosestCommonSuccessor(int a, int b)
        {
            Queue<int> toVisit = new Queue<int>();
            int vertices = list.Count;
            bool[] visited = new bool[vertices];

            toVisit.Enqueue(a);
            while (toVisit.Count != 0)
            {
                int v = toVisit.Dequeue();
                if (!visited[v])
                {
                    visited[v] = true;
                    foreach (int u in list[v])
                    {
                        toVisit.Enqueue(u);
                    }
                }
            }

            int commonSuccessor = -1;

            toVisit.Enqueue(b);
            while (toVisit.Count != 0)
            {
                int v = toVisit.Dequeue();
                if (!visited[v])
                {
                    visited[v] = true;
                    foreach (int u in list[v])
                    {
                        toVisit.Enqueue(u);
                    }
                }
                else
                {
                    commonSuccessor = v;
                    break;
                }
            }

            return commonSuccessor;
        }

        public void Prepare()
        {
            IType @bool = Types.GetType("Boolean");
            IType @char = Types.GetType("Char");
            IType @byte = Types.GetType("Byte");
            IType @sbyte = Types.GetType("SByte");
            IType @short = Types.GetType("Int16");
            IType @ushort = Types.GetType("UInt16");
            IType @int = Types.GetType("Int32");
            IType @uint = Types.GetType("UInt32");
            IType @long = Types.GetType("Int64");
            IType @ulong = Types.GetType("UInt64");
            IType @float = Types.GetType("Single");
            IType @double = Types.GetType("Double");
            IType @intptr = Types.GetType("IntPtr");
            IType @uintptr = Types.GetType("UIntPtr");

            AddVertex(@bool);
            AddVertex(@char);
            AddVertex(@byte);
            AddVertex(@sbyte);
            AddVertex(@short);
            AddVertex(@ushort);
            AddVertex(@int);
            AddVertex(@uint);
            AddVertex(@long);
            AddVertex(@ulong);
            AddVertex(@float);
            AddVertex(@double);
            AddVertex(@intptr);
            AddVertex(@uintptr);

            AddEdge(@sbyte, @short);
            AddEdge(@short, @int);
            AddEdge(@int, @long);
            AddEdge(@long, @float);

            AddEdge(@char, @int);
            AddEdge(@char, @ushort);

            AddEdge(@byte, @short);
            AddEdge(@byte, @ushort);

            AddEdge(@ushort, @int);
            AddEdge(@ushort, @uint);

            AddEdge(@uint, @long);
            AddEdge(@uint, @ulong);

            AddEdge(@ulong, @float);

            AddEdge(@float, @double);

            Generate();

            ResultTable[@long, @ulong] = null;
            ResultTable[@ulong, @long] = null;
        }
    }
}
