using System;
using System.Collections.Generic;

namespace Boggle.Common
{
    public class Trie
    {
        public class TrieNode
        {
            public string character { get; set; }
            public TrieNode[] children { get; set; }
            public bool isWord { get; set; }
            public TrieNode parent { get; set; }

            public TrieNode()
            {
                children = new TrieNode[26];
                isWord = false;
                parent = null;
            }

            public TrieNode(string character)
            {
                children = new TrieNode[26];
                isWord = false;
                parent = null;
                this.character = character;
            }

            public void addWord(string word)
            {
                // recursion method, keep calling and creating node until the word is empty;
                if (!(string.IsNullOrEmpty(word) && string.IsNullOrWhiteSpace(word)))
                {
                    int index = word[0] - 'a';
                    try
                    {
                        if (children[index] == null)
                        {
                            children[index] = new TrieNode(word[0].ToString());
                            children[index].parent = this;
                        }

                        if (word.Length > 1)
                        {
                            children[index].addWord(word.Substring(1));
                        }
                        else
                        {
                            children[index].isWord = true;
                        }
                    } catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine(word);
                    }

                }
            }

            public bool IsWord()
            {
                return this.isWord;
            }

            public TrieNode getNode(string character)
            {
                return children[character[0] - 'a'];
            }
        }

        TrieNode root;

        public Trie(List<string> dicionary) 
        { 
            root = new TrieNode();
            addWord(dicionary);
        }

        public void addWord(List<string> dicionary)
        {
            foreach (string word in dicionary)
            {
                addWord(word);
            }
        }

        public void addWord(string word)
        {
            root.addWord(word.ToLower());
        }

        public bool hasPrefix(string prefix)
        {
            TrieNode lastNode = descend(prefix);
            return lastNode == null ? false : true;
        }

        public bool isWord(string word)
        {
            TrieNode lastNode = descend(word);
            if (lastNode == null) { return false; }
            return lastNode.isWord;
        }

        public TrieNode descend(string word)
        {
            TrieNode lastNode = root;
            for(int i = 0; i < word.Length; i++)
            {
                lastNode = lastNode.getNode(word[i].ToString());

                if (lastNode == null)
                {
                    return lastNode;
                }
            }

            return lastNode;
        }
    }
}
