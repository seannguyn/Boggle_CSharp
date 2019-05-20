using System;
using System.Collections.Generic;
using Board;

namespace Boggle.Solve
{
    public class DFS : ISolver
    {
        public List<string> solve(Board.Node[,] board)
        {
            HashSet<string> wordsFound = new HashSet<string>();

            for (int i = 0; i < Board.Board.dimension; i++)
            {
                for (int j = 0; j < Board.Board.dimension; j++)
                {
                    HashSet<Node> visited = new HashSet<Node>();
                    visited.Add(board[i, j]);
                    search(board[i, j], wordsFound, visited, board[i, j].ToString(), board);
                }
            }

            return new List<string>(wordsFound);
        }

        public void search(Node current, HashSet<string> wordsFound, HashSet<Node> visited, string words, Board.Node[,] board)
        {
            if (words.Length > 20 || words.Length > board.Length) { return; }

            // get neighbor
            if (DictionaryWord.dictionary.Contains(words) && words.Length >= 3) { wordsFound.Add(words); }

            // loop thru neighbor, if not visited, visit it
            List < Node > neighborNodeList = Board.Board.GetNeighbor(board, current);
            foreach (Node neighbor in neighborNodeList)
            {
                if (visited.Contains(neighbor)) { continue; }
                visited.Add(neighbor);
                search(neighbor, wordsFound, visited, words + neighbor, board);
                visited.Remove(neighbor);
            }
        }
    }
}
