namespace OtusHomework
{
    public class BinaryTreeStorage<T> where T : class, IComparable<T>

    {
        private Node<T>? _root;

        public void Add(T data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var nodeToAdd = new Node<T>(data);

            AddNode(nodeToAdd, _root);
        }


        public T? Find(T data, Node<T> baseNode)
        {
            if (baseNode is null)
            {
                throw new ArgumentNullException(nameof(baseNode));
            }

            if (data.CompareTo(baseNode.Data) < 0)
            {
                if (baseNode.LeftNode is null)
                {
                    return null;
                }
                return Find(data, baseNode.LeftNode);
            }
            else if (data.CompareTo(baseNode.Data) > 0)
            {
                if (baseNode.RightNode is null)
                {
                    return null;
                }
                return Find(data, baseNode.RightNode);
            }
            else
            {
                return baseNode.Data;
            }
        }

        private void AddNode(Node<T> nodeToAdd, Node<T>? baseNode)
        {
            if (nodeToAdd is null)
            {
                throw new ArgumentNullException(nameof(nodeToAdd));
            }

            if (baseNode is null)
            {
                _root = nodeToAdd;
            }
            else if (nodeToAdd.CompareTo(baseNode) < 0)
            {
                if (baseNode.LeftNode == null)
                {
                    baseNode.LeftNode = nodeToAdd;
                }
                else
                {
                    AddNode(nodeToAdd, baseNode.LeftNode);
                }
            }
            else
            {
                if (baseNode.RightNode == null)
                {
                    baseNode.RightNode = nodeToAdd;
                }
                else
                {
                    AddNode(nodeToAdd, baseNode.RightNode);
                }
            }
        }
    }
}
