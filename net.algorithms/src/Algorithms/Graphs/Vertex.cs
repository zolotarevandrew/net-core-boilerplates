namespace Algorithms.Graphs
{
    public class Vertex<TId, TValue>
    {
        public TId Id { get; set; }
        public TValue Value { get; set; }

        public Vertex()
        {

        }

        public Vertex(TId id, TValue value)
        {
            Id = id;
            Value = value;
        }
    }
}
