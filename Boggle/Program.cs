using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Boggle.Solve;

namespace Boggle
{
    class Program
    {
        static void Main(string[] args)
        {
            Board.Board a = new Board.Board("lnoynursi", new DFS());
            a.solve();

            Board.Board b = new Board.Board("lnoynursi", new DictionarySolver());
            b.solve();

            Board.Board c = new Board.Board("lnoynursi", new TrieSolver());
            c.solve();
        }

        public static async Task GetObject()
        {
            HttpClient _httpClient = new HttpClient();
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");
            await response.Content.LoadIntoBufferAsync();
            string content = await response.Content.ReadAsStringAsync();
            using (StreamWriter sw = new StreamWriter("hello.txt"))
            {
                sw.WriteLine(content);
            }

            Console.WriteLine("Hello World!");
        }

        public static void searchFileName()
        {
            string[] fileNames = Directory.GetFiles("testfolder", "*", SearchOption.TopDirectoryOnly);
            var result = from x in fileNames where !x.Contains("copy") select x;

            foreach (string s in result.ToList())
            {
                Console.WriteLine(s);
            }
        }
    }
}
