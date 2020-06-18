﻿using Codecool.Quest.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.Quest.Models.Actors
{
    public class ShootingMob : Actor
    {
        private int dx { get; set; }
        private int dy { get; set; }
        private Random random = new Random();
        private Shoot shoot;
        private Cell cell;
        public override string TileName { get; set; } = "shootingMob";

        public ShootingMob(Cell cell, int dx, int dy) : base(cell)
        {
            shoot = new Shoot(cell);
            this.cell = cell;
            this.dx = dx;
            this.dy = dy;
        }

        public override void Move()
        {
            if(shoot.Cell.Item is null)
            {
                shoot = new Shoot(cell);
            }
            else
            {
                shoot.Move(dx, dy);
            }
        }
    }
}
