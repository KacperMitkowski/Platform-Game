﻿using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Items;
using System.Collections;
using System.Collections.Generic;

namespace Codecool.Quest.Models
{
    public class GameMap
    {
        public int Height { get; }
        public int Width { get; }
        private readonly Cell[,] _cells;
        public Player Player { get; set; }
        public static int level = 1;
        public static List<Actor> Actors { get; } = new List<Actor>();
        public static List<Item> Items { get; } = new List<Item>();
        public GameMap(int width, int height, CellType defaultCellType)
        {
            Width = width;
            Height = height;
            _cells = new Cell[width, height];
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    _cells[x, y] = new Cell(this, x, y, defaultCellType);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            if (x >= _cells.GetLength(0) || y >= _cells.GetLength(1) || x < 0 || y < 0)
            {
                return null;
            }

            return _cells[x, y];
        }
    }
}