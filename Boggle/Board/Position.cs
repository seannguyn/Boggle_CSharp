using System;
namespace Board
{
    public class Position
    {
        public int pos_x { get; set; }
        public int pos_y { get; set; }

        public Position(int pos_x, int pos_y)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }


    }
}
