using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.Quest.Models.Items
{
    public class ReturnMapExit : Item
    {
        public override string TileName { get; set; } = "returnMapExit";

        public ReturnMapExit(Cell cell) : base(cell)
        {

        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
