using System.Collections.Generic;

namespace Algorithms.Graphs
{
    public interface IGraph<TId,TValue>
    {
        int VertexCount { get; }
        void AddEdge(Vertex<TId, TValue> t1, Vertex<TId, TValue> t2);
        IEnumerable<Vertex<TId, TValue>> BFS(TId id);
        IEnumerable<Vertex<TId, TValue>> DFS(TId id, bool recursive = false);
        Vertex<TId, TValue> FindMother();
        int CountPaths(TId from, TId to);
    }
}
