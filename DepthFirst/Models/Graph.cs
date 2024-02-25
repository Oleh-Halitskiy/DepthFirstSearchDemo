namespace DepthFirst.Models
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; set; }
        public bool AllNodesConnected => AllNodesHaveEdges();
        
        public Graph()
        {
            Nodes = new List<Node<T>>();
        }

        public Graph(List<Node<T>> nodes)
        {
            Nodes = nodes;
        }

        public void AddNode(Node<T> node)
        {
            Nodes.Add(node);
        }

        public void AddEdge(Node<T> parent, Node<T> child)
        {
            parent.AddNeighbor(child);
            child.AddNeighbor(parent);
        }

        private bool AllNodesHaveEdges()
        {
            foreach (var node in Nodes)
            {
                if (node.Neighbors.Count == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
