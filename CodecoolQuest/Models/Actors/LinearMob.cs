using System;
using System.Diagnostics;

namespace Codecool.Quest.Models.Actors
{
    public class LinearMob : Actor
    {
        public override string TileName { get; set; } = "linearMob";
        private int dx;
        private int dy;
        private Cell cell;

        public LinearMob(Cell cell) : base(cell)
        {
            this.cell = cell;
            prepareDirs();
        }

        private void prepareDirs()
        {
            Random random = new Random();
            int number = random.Next(0, 4);
            switch(number)
            {
                case 0:
                    dx = -1;
                    dy = 0;
                    break;
                case 1:
                    dx = 0;
                    dy = -1;
                    break;
                case 2:
                    dx = 1;
                    dy = 0;
                    break;
                case 3:
                    dx = 0;
                    dy = 1;
                    break;
            }
        }

        public override void Move()
        {
            var nextCell = Cell.GetNeighbor(dx, dy);
            
            // bounce mob if it meets:
            // - wall
            // - tree
            // - water
            // - grass
            if(nextCell.CellType == CellType.Wall || nextCell.CellType == CellType.Tree || nextCell.CellType == CellType.Water || nextCell.CellType == CellType.Grass || (nextCell.Actor is ShootingMob))
            {
                dx = -dx;
                dy = -dy;
                nextCell = Cell.GetNeighbor(dx, dy);
            }


            // check if mob kills player
            if (nextCell.Actor is Player)
            {
                Game.MoveInterval = 10000;
            }
            else
            {
                // change mob position if next cell is not player
                Cell.Actor = null;
                nextCell.Actor = this;
                Cell = nextCell;
            }
        }
    }
}
