using Codecool.Quest.Models.Items;

namespace Codecool.Quest.Models.Actors
{
    public abstract class Actor : IDrawable
    {
        public Cell Cell { get; protected set; }
        public Item Item { get; protected set; }
        public int Health { get; set; }
        public int X => Cell.X;
        public int Y => Cell.Y;


        public abstract string TileName { get; set; }

        protected Actor(Cell cell)
        {
            Cell = cell;
            Cell.Actor = this;
        }

        public abstract void Move();
    }
}