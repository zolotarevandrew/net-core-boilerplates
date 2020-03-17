using Algorithms.Graphs;
using System.Linq;
using Xunit;

namespace Algorithms.Tests.Graphs
{
    public class ListGraphTest
    {
        [Fact]
        public void ListGraph_BFS_ShouldReturnAllVertex()
        {
            //Arrange
            var graph = new ListGraph<int, int>();
            var v1 = new Vertex<int, int>(1, 1);
            var v2 = new Vertex<int, int>(2, 2);
            var v3 = new Vertex<int, int>(3, 3);
            var v5 = new Vertex<int, int>(5, 5);
            var v6 = new Vertex<int, int>(6, 6);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);
            graph.AddEdge(v3, v6);

            //Act
            var result = graph.BFS(v6.Id).ToList();

            Assert.Equal(5, result.Count);
            Assert.Contains(result, r => r.Id == v6.Id);
            Assert.Contains(result, r => r.Id == v2.Id);
            Assert.Contains(result, r => r.Id == v3.Id);
            Assert.Contains(result, r => r.Id == v1.Id);
            Assert.Contains(result, r => r.Id == v5.Id);
        }

        [Fact]
        public void ListGraph_DFS_ShouldReturnAllVertex()
        {
            //Arrange
            var graph = new ListGraph<int, int>();
            var v1 = new Vertex<int, int>(1, 1);
            var v2 = new Vertex<int, int>(2, 2);
            var v3 = new Vertex<int, int>(3, 3);
            var v5 = new Vertex<int, int>(5, 5);
            var v6 = new Vertex<int, int>(6, 6);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);
            graph.AddEdge(v3, v6);

            //Act
            var result = graph.DFS(v6.Id).ToList();

            Assert.Equal(5, result.Count);
            Assert.Contains(result, r => r.Id == v6.Id);
            Assert.Contains(result, r => r.Id == v2.Id);
            Assert.Contains(result, r => r.Id == v3.Id);
            Assert.Contains(result, r => r.Id == v1.Id);
            Assert.Contains(result, r => r.Id == v5.Id);
        }

        [Fact]
        public void ListGraph_DFSRecurse_ShouldReturnAllVertex()
        {
            //Arrange
            var graph = new ListGraph<int, int>();
            var v1 = new Vertex<int, int>(1, 1);
            var v2 = new Vertex<int, int>(2, 2);
            var v3 = new Vertex<int, int>(3, 3);
            var v5 = new Vertex<int, int>(5, 5);
            var v6 = new Vertex<int, int>(6, 6);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);
            graph.AddEdge(v3, v6);

            //Act
            var result = graph.DFS(v6.Id, recursive: true).ToList();

            Assert.Equal(5, result.Count);
            Assert.Contains(result, r => r.Id == v6.Id);
            Assert.Contains(result, r => r.Id == v2.Id);
            Assert.Contains(result, r => r.Id == v3.Id);
            Assert.Contains(result, r => r.Id == v1.Id);
            Assert.Contains(result, r => r.Id == v5.Id);
        }
    }
}
