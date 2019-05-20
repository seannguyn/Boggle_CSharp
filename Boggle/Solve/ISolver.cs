using System;
using System.Collections.Generic;

namespace Boggle
{
    public interface ISolver
    {
        List<string> solve(Board.Node[,] board);
    }
}
