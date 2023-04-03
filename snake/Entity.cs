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
        // properties
        public int Left { get; set; }
        public int Top { get; set; }

        public Entity(int left, int top)
        {
            Left = left;
            Top = top;
        }

        public override string ToString()
        {
            return $"ENTITY({Left}, {Top})";
        }

    }
}
