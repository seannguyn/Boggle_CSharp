using System;
using System.Collections.Generic;
using Board;

namespace Boggle.Solve
{
    public class DictionarySolver : ISolver
    {
        public List<string> solve(Node[,] board)
        {
            HashSet<string> foundWords = new HashSet<string>();
            foreach (string word in DictionaryWord.dictionary)
            {
                if (word.Length < 3) { continue; }
                foreach (Node n in board)
                {
                    if (word.StartsWith(n.ToString()))
                    {
                        HashSet<Node> visited = new HashSet<Node>();
                        visited.Add(n);
                        search(word, n.ToString(), n, foundWords, visited, board);
                    }
                }
            }
            return new List<string>(foundWords);
        }

        public void search(string dictWord, string word, Node current, HashSet<string> foundWords, HashSet<Node> visited, Node[,] board)
        {
            if (!dictWord.Contains(word)) { return; }

            if(dictWord == word)
            {
                foundWords.Add(word);
                return;
            }

            List<Node> neighborList = Board.Board.GetNeighbor(board, current);
            foreach (Node neighbor in neighborList)
            {
                if (visited.Contains(neighbor)) { continue; }
                visited.Add(neighbor);
                search(dictWord, word + neighbor, neighbor, foundWords, visited, board);
                visited.Remove(neighbor);
            }
        }
    }
}
