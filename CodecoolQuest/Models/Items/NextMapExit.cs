using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.Quest.Models.Items
{
    public class NextMapExit : Item
    {
        public override string TileName { get; set; } = "nextMapExit";

        public NextMapExit(Cell cell) : base(cell)
        {

        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
