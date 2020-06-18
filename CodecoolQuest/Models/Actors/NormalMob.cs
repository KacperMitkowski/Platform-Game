using System;

namespace Codecool.Quest.Models.Actors
{
    public class NormalMob : Actor
    {
        private Random random = new Random();
        public override string TileName { get; set; } = "normalMob";
        public NormalMob(Cell cell) : base(cell)
        {
        }

        public override void Move()
        {
            int dx = GetDir();
            int dy = GetDir();
            var nextCell = Cell.GetNeighbor(dx, dy);

            // check if mob kills player
            if (nextCell.Actor is Player)
            {
                Game.MoveInterval = 10000;
            }
            else
            {
                // change mob position if floor only
                if (nextCell.CellType == CellType.Floor && !(nextCell.Actor is ShootingMob))
                {
                    Cell.Actor = null;
                    nextCell.Actor = this;
                    Cell = nextCell;
                }
            }
        }
        private int GetDir()
        {
            return random.Next(-1, 2);
        }
    }
}