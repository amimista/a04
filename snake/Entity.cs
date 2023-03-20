using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    public class Entity
    {
        private int left;
        private int top;
        private char drawnChar;
        public int Left { get; set; }
        public int Top { get; set; }

        public Entity(int left, int top)
        {
            Left = left;
            Top = top;
        }
        public Entity(int left, int top, char insideChar)
        {
            Left = left;
            Top = top;
            this.drawnChar = insideChar;
        }

    }
}
