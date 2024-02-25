// See https://aka.ms/new-console-template for more information
using DepthFirst.Core;
using DepthFirst.Models;

List <Node<string>> nodes = new List<Node<string>>
{
    new Node<string>("A"), // 0
    new Node<string>("B"), // 1
    new Node<string>("C"), // 2
    new Node<string>("D"), // 3
    new Node<string>("G"), // 4
    new Node<string>("H"), // 5
    new Node<string>("E"), // 6
    new Node<string>("F"), // 7
    new Node<string>("I"), // 8

};

Graph<string> graph = new Graph<string>(nodes);

graph.AddEdge(nodes[0], nodes[3]);
graph.AddEdge(nodes[3], nodes[4]);
graph.AddEdge(nodes[4], nodes[5]);
graph.AddEdge(nodes[5], nodes[6]);
graph.AddEdge(nodes[6], nodes[3]);
graph.AddEdge(nodes[0], nodes[1]);
graph.AddEdge(nodes[1], nodes[2]);
graph.AddEdge(nodes[2], nodes[7]);
graph.AddEdge(nodes[7], nodes[8]);

Console.WriteLine(DepthFirstModule.SearchNode(graph, "H")); //graph is taken from https://www.youtube.com/watch?v=by93qH4ACxo&t=90s
