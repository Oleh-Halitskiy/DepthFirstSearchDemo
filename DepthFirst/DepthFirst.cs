using System.Data.Common;
using System.Text;
using DepthFirst.Models;

namespace DepthFirst.Core
{
    public static class DepthFirstModule
    {
        public static string SearchNode<T>(Graph<T> graph, T value)
        {
            Stack<Node<T>> path = new Stack<Node<T>>();
            List<Node<T>> visited = new List<Node<T>>();

            path.Push(graph.Nodes[0]);
            visited.Add(graph.Nodes[0]);

            while (graph.Nodes.Count >= visited.Count)
            {
                var currentNode = path.Peek();

                if (currentNode.Value.Equals(value))
                {
                    return StackToString(path);
                }

                if(visited.Contains(currentNode.Neighbors[0]))
                {
                    // check if current node has any unvisited neighbors
                    // comeback to previous node if it doesn't
                    var unvisitedNode = FindUnvisitedNode(currentNode, visited);

                    if (unvisitedNode != null)
                    {
                        path.Push(unvisitedNode);
                        visited.Add(unvisitedNode);
                    }
                    else
                    {
                        path.Pop();
                    }
                }
                else
                {
                    path.Push(currentNode.Neighbors[0]);
                    visited.Add(currentNode.Neighbors[0]);
                }
            }
            return "";
        }

        private static string StackToString<T>(Stack<Node<T>> stack)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var node in stack)
            {
                sb.Append(node.Value);
                sb.Append(" ");
            }
            return sb.ToString();
        }

        private static Node<T> FindUnvisitedNode<T>(Node<T> node, List<Node<T>> visited)
        {
            foreach (var neighbor in node.Neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    return neighbor;
                }
            }
            return null;
        }
    }
}