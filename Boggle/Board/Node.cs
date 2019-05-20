using System;
using System.Collections.Generic;

namespace Board
{
    public class Node
    {
        private string character;
        private Position position;
        public Position[] neighbors;

        public Node(string c, int pos_x, int pos_y)
        {
            character = c;
            position = new Position(pos_x, pos_y);
            neighbors = computeNeighbors(pos_x,pos_y);
        }

        public Position[] computeNeighbors(int pos_x, int pos_y)
        {
            // initialization of varibales
            int[] direction = new int[] { -1, 0, 1 };
            List<Position> neighborsList = new List<Position>();

            // loop thru to find neighbor
            foreach (int r in direction)
            {
                foreach (int c in direction)
                {
                    int neighbor_x = pos_x + r;
                    int neighbor_y = pos_y + c;
                    if (isValid(neighbor_x, neighbor_y, pos_x, pos_y))
                    {
                        Position neighbor = new Position(neighbor_x, neighbor_y);
                        neighborsList.Add(neighbor);
                    }
                } 
            }

            return neighborsList.ToArray();
        }

        public bool isValid(int neighbor_x, int neighbor_y, int pos_x, int pos_y)
        {
            if (pos_x == neighbor_x && pos_y == neighbor_y) { return false; }
            return (neighbor_x >= 0 && neighbor_y >= 0 && neighbor_x < Board.dimension && neighbor_y < Board.dimension);
        }

        public override string ToString()
        {
            return character;
        }

        public void PrintNode()
        {
            Console.WriteLine($"Node char: {character}");
            Console.WriteLine($"x: {position.pos_x}, y: {position.pos_y}");
        }
    }
}
