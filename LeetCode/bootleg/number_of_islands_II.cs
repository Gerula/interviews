//  http://lcoj.tk/problems/number-of-islands-ii-danyang3-drafting/
//
//  A 2d grid map of m rows and n columns is initially filled with water. We may perform an addLand operation which turns the water at position (row, col) into a land. Given a list of positions to operate, count the number of islands after each addLand operation. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
//
//  Example:
//
//  Given m = 3, n = 3, positions = [[0,0], [0,1], [1,2], [2,1]].
//  Initially, the 2d grid grid is filled with water. (Assume 0 represents water and 1 represents land).
//
//  0 0 0
//  0 0 0
//  0 0 0
//
//  Operation #1: addLand(0, 0) turns the water at grid[0][0] into a land.
//
//  1 0 0
//  0 0 0   Number of islands = 1
//  0 0 0
//
//  Operation #2: addLand(0, 1) turns the water at grid[0][1] into a land.
//
//  1 1 0
//  0 0 0   Number of islands = 1
//  0 0 0
//
//  Operation #3: addLand(1, 2) turns the water at grid[1][2] into a land.
//
//  1 1 0
//  0 0 1   Number of islands = 2
//  0 0 0
//
//  Operation #4: addLand(2, 1) turns the water at grid[2][1] into a land.
//
//  1 1 0
//  0 0 1   Number of islands = 3
//  0 1 0
//
//  We return the result as an array: [1, 1, 2, 3]

using System;
using System.Collections.Generic;
using System.Linq;

class Node
{
    public int Line { get; private set; }
    public int Column { get; private set; }
    public int Rank { get; private set; }
    public Node Parent { get; private set; }
    public static int Count = 0;

    public Node(int line, int column)
    {
        Line = line;
        Column = column;
        Parent = this;
        Count++;
    }

    public bool IsNeighbor(Node other)
    {
        return Math.Abs(Line - other.Line) == 1 && Column == other.Column ||
               Math.Abs(Column - other.Column) == 1 && Line == other.Line;
    }

    public Node Find()
    {
        if (this.Parent == this)
        {
            return this;
        }

        this.Parent = this.Parent.Find();
        return this.Parent;
    }

    public static void Union(Node a, Node b)
    {
        var parentA = a.Find();
        var parentB = b.Find();

        if (parentA == parentB)
        {
            return;
        }

        Count--;

        if (a.Rank == b.Rank)
        {
            parentA.Parent = parentB;
            return;
        }

        if (a.Rank < b.Rank)
        {
            parentA.Parent = parentB;
        }
        else
        {
            parentB.Parent = parentA;
        }
    }
}

static class Program
{
    static IEnumerable<int> Islands(this int[,] a)
    {
        var nodes = new List<Node>();
        for (var i = 0; i < a.GetLength(0); i++)
        {
            var node = new Node(a[i, 0], a[i, 1]);
            nodes.Add(node);
            foreach (var neighbor in nodes.Where(x => node.IsNeighbor(x)))
            {
                Node.Union(node, neighbor);
            }

            yield return Node.Count;
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new [,] { 
                        { 0, 0 }, { 0, 1 }, { 1, 2 }, { 2, 1 }
                    }.Islands()));
    }
}
