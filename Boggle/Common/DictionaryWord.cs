using System;
using System.Collections.Generic;
using System.IO;

namespace Boggle
{
    public class DictionaryWord
    {
        public static List<string> dictionary;
        private static readonly object _obj = new object { };

        static DictionaryWord()
        {
            if (dictionary == null) {
                lock (_obj)
                {
                    string[] words = File.ReadAllLines("dict.txt");
                    dictionary = new List<string>(words);
                }
            }
        }
    }
}
