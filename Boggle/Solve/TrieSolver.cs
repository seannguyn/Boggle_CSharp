using System;
using System.Collections.Generic;
using Board;
using Boggle.Common;

namespace Boggle.Solve
{
    public class TrieSolver : ISolver
    {
        public Trie trieTree { get; set; }
        public TrieSolver()
        {
            trieTree = new Trie(DictionaryWord.dictionary);
        }
        public List<string> solve(Node[,] board)
        {
            HashSet<string> wordList = new HashSet<string>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    HashSet<Node> visited = new HashSet<Node>();
                    visited.Add(board[i, j]);
                    search("" + board[i, j], board[i, j], visited, board, wordList);
                }
            }
            return new List<string>(wordList);
        }

        public void search(string word, Node currentNode, HashSet<Node> visited, Node[,] board, HashSet<string> wordList)
        {
            if (!trieTree.hasPrefix(word)) { return; }

            if (word.Length >= 3 && trieTree.isWord(word)) { wordList.Add(word); }

            List<Node> neighborList = Board.Board.GetNeighbor(board, currentNode);
            foreach (Node neighbor in neighborList)
            {
                if (visited.Contains(neighbor)) { continue; }

                visited.Add(neighbor);

                search(word + neighbor, neighbor, visited, board, wordList);

                visited.Remove(neighbor);
            }      
        }
    }
}
