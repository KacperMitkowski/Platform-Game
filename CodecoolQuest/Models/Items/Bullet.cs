using Codecool.Quest.Models.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.Quest.Models.Items
{
    public class Bullet : Item
    {
        public override string TileName { get; set; } = "bullet";

        public Bullet(Cell cell) : base(cell)
        {

        }

        public void Move(int dx, int dy)
        {
            var nextCell = Cell.GetNeighbor(dx, dy);
            if (nextCell.Actor is Player)
            {
                Game.MoveInterval = 10000;
            }
            else
            {
                if (nextCell.CellType == CellType.Wall || nextCell.CellType == CellType.Grass || nextCell.CellType == CellType.Tree || nextCell.CellType == CellType.Water)
                {
                    this.Cell.Item = null;
                }
                else
                {
                    Cell.Item = null;
                    nextCell.Item = this;
                    Cell = nextCell;
                }
            }
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
