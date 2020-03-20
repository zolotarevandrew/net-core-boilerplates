using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public class ListGraph<TId, TValue> : IGraph<TId, TValue>
    {
        Dictionary<TId, List<Vertex<TId, TValue>>> _list;

        public ListGraph()
        {
            _list = new Dictionary<TId, List<Vertex<TId, TValue>>>();
        }

        public int VertexCount => _list.Keys.Count;

        public void AddEdge(Vertex<TId, TValue> t1, Vertex<TId, TValue> t2)
        {
            if (t1 == null || t2 == null) throw new InvalidOperationException("t1 or t2 is null");

            void NewEdge(Vertex<TId, TValue> item1, Vertex<TId, TValue> item2)
            {
                if (!_list.ContainsKey(item1.Id))
                {
                    _list[item1.Id] = new List<Vertex<TId, TValue>>
                    {
                        item1,
                        item2
                    };
                } else
                {
                    _list[item1.Id].Add(item2);
                }
            }
            NewEdge(t1, t2);
            NewEdge(t2, t1);
        }

        public IEnumerable<Vertex<TId, TValue>> BFS(TId id) 
        {
            if (!_list.ContainsKey(id)) yield break;

            Dictionary<TId, bool> visited = new Dictionary<TId, bool>();
            visited[id] = true;

            var queue = new List<TId>();
            queue.Add(id);

            while(queue.Count > 0)
            {
                var curId = queue[0];
                var vertexList = _list[curId];
                var vertex = vertexList[0];
                yield return vertex;
                queue.Remove(curId);

                for(int idx = 1; idx < vertexList.Count; idx++)
                {
                    var curVertex = vertexList[idx];
                    if (!visited.ContainsKey(curVertex.Id) || !visited[curVertex.Id])
                    {
                        visited[curVertex.Id] = true;
                        queue.Add(curVertex.Id);
                    }
                }
            }

            yield break;
        }

        public IEnumerable<Vertex<TId, TValue>> DFS(TId id, bool recursive = false)
        {
            Dictionary<TId, bool> visited = new Dictionary<TId, bool>();
            if (!recursive) return DFSByStack(id, visited);
            return DFSRecurse(id, visited);
        }

        public Vertex<TId, TValue> FindMother()
        {
            Dictionary<TId, bool> visited = new Dictionary<TId, bool>();
            TId mother = default;
            foreach (var key in _list.Keys)
            {
                var curVertex = _list[key][0];
                if (!visited.ContainsKey(curVertex.Id) || !visited[curVertex.Id])
                {
                    foreach (var item in DFSRecurse(mother, visited, (id) => visited[id] = true)) { }
                    mother = curVertex.Id;
                }
            }
            visited = new Dictionary<TId, bool>();
            foreach (var item in DFSRecurse(mother, visited, (id) => visited[id] = true)) { }

            if (visited.Count != _list.Keys.Count) return null;
            if (!_list.ContainsKey(mother)) return null;
            return _list[mother][0];
        }

        IEnumerable<Vertex<TId, TValue>> DFSRecurse(
            TId itemId, 
            Dictionary<TId, bool> visitedDict, 
            Action<TId> push = null)
        {
            if (!_list.ContainsKey(itemId)) yield break;
            visitedDict[itemId] = true;
            push?.Invoke(itemId);
            yield return _list[itemId][0];

            for (int idx = 1; idx < _list[itemId].Count; idx++)
            {
                var curVertex = _list[itemId][idx];
                if (!visitedDict.ContainsKey(curVertex.Id) || !visitedDict[curVertex.Id])
                {
                    foreach (var item in DFSRecurse(curVertex.Id, visitedDict, push)) yield return item;
                }
            }
        }

        IEnumerable<Vertex<TId, TValue>> DFSByStack(TId id, Dictionary<TId, bool> visited)
        {
            if (!_list.ContainsKey(id)) yield break;

            visited[id] = true;

            var stack = new Stack<TId>();
            stack.Push(id);

            do
            {
                var curId = stack.Peek();
                var vertexList = _list[curId];

                for (int idx = 1; idx < vertexList.Count; idx++)
                {
                    var curVertex = vertexList[idx];
                    if (!visited.ContainsKey(curVertex.Id) || !visited[curVertex.Id])
                    {
                        visited[curVertex.Id] = true;
                        stack.Push(curVertex.Id);
                        break;
                    }
                    if (idx == vertexList.Count - 1)
                    {
                        var res = stack.Pop();
                        yield return _list[res][0];
                    }
                }
            }
            while (stack.Count > 0);
        }

        public int CountPaths(TId from, TId to)
        {
            if (!_list.ContainsKey(from) || !_list.ContainsKey(to)) throw new InvalidOperationException();
            int paths = 0;
            void CountPathsRecurse(TId u, TId v, ref Dictionary<TId, bool> vis, ref int numPaths)
            {
                vis[u] = true;
                if (u.Equals(v)) numPaths++;
                else
                {
                    var vertexList = _list[u];
                    for (int idx = 1; idx < vertexList.Count; idx++)
                    {
                        var curVertex = vertexList[idx];
                        if(!vis.ContainsKey(curVertex.Id) || !vis[curVertex.Id])
                            CountPathsRecurse(curVertex.Id, v, ref vis, ref numPaths);
                    }
                }
                vis[u] = false;
            }
            var visited = new Dictionary<TId, bool>();
            CountPathsRecurse(from, to, ref visited, ref paths);
            return paths;
        }
    }
}
