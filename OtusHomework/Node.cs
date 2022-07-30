namespace OtusHomework
{
    public class Node<T> : IComparable<Node<T>> where T : class, IComparable<T>
    {
        public T Data { get; private set; }
        public Node<T>? LeftNode { get; set; }
        public Node<T>? RightNode { get; set; }

        public Node(T data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public int CompareTo(Node<T>? other)
        {
            return Data.CompareTo(other?.Data);
        }
    }
}
