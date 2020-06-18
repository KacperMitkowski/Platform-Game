using Codecool.Quest.Models.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.Quest.Models.Items
{
    public class Key : Item
    {
        public override string TileName { get; set; } = "key";

        public Key(Cell cell) : base(cell)
        {
            Cell = cell;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
