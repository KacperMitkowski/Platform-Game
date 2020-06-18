using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.Quest.Models.Items
{
    public abstract class Item : IDrawable
    {
        public Cell Cell { get; protected set; }

        public int X => Cell.X;
        public int Y => Cell.Y;

        public abstract string TileName { get; set; }
        public abstract void Move();
        protected Item(Cell cell)
        {
            Cell = cell;
            Cell.Item = this;
        }
    }
}
