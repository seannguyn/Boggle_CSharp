using System;
using System.Collections.Generic;
using System.Diagnostics;
using Boggle;
using Boggle.Common;

namespace Board
{
    public class Board
    {
        public Node[,] board;
        public static int dimension { get; set; }
        private ISolver solver;
        private Stopwatch stopwatch;

        public Board(string boggleString, ISolver solver) 
        {
            BuildBoard(boggleString);
            this.solver = solver;
        }

        public void BuildBoard(string boggleString)
        {
            // check the validity of the Boggle board
            dimension = boggleString.checkBoardDimension();

            // build the board
            board = new Node[dimension,dimension];
            char[] boggleChar = boggleString.ToCharArray();
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    int offset = dimension * i + j;
                    board[i,j] = new Node(boggleChar[offset].ToString(), i, j);
                }
            }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Node n = board[i, j];
                    Console.Write(n+" ");
                }
                Console.WriteLine();
            }
        }

        public void solve()
        {
            Console.WriteLine($"The Solver is: {solver.GetType().Name}");
            Console.WriteLine();
            PrintBoard();

            StartTimer();
            List<string> solution = solver.solve(this.board);
            StopTimer();
            Console.WriteLine("=================");
            foreach (string word in solution)
            {
                Console.WriteLine($"{word}");
            }
            Console.WriteLine("=================");
            Console.WriteLine($"Total: {solution.Count}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static List<Node> GetNeighbor(Node[,] board,Node node)
        {
            Position[] neighbors = node.neighbors;
            List<Node> neighborNodes = new List<Node>();

            foreach (Position p in neighbors)
            {
                neighborNodes.Add(board[p.pos_x,p.pos_y]);
            }
            return neighborNodes;
        }

        private void StartTimer()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private void StopTimer()
        {
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Logger.Info("RunTime: " + elapsedTime);
        }
    }
}


/*
 * Array of arrays VS 2D array
 * 
 * Array of array can be jagged
 * such as 
 * 
 *      double[][] a = new double[5][];
 *      a[0] = new double[5];
 *      a[1] = new double[10];
 *      a[2] = new double[7];
 * 
 * 2D array has to be uniform 
 * 
 * such as 
 *      double[,] a = new double[5,5];
 * 
 * 
*/
