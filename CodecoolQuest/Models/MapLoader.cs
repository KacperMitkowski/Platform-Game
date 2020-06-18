using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Items;
using System.Diagnostics;
using System.IO;

namespace Codecool.Quest.Models
{
    public class MapLoader
    {
        public static GameMap LoadMap()
        {
            int currentLevel = GameMap.level;
            var stream = new StreamReader($"map_{currentLevel}.txt");
            var firstLine = stream.ReadLine();
            var firstLineSplit = firstLine.Split(' ');

            var width = int.Parse(firstLineSplit[0]);
            var height = int.Parse(firstLineSplit[1]);

            var map = new GameMap(width, height, CellType.Empty);

            for (var y = 0; y < height; y++)
            {
                var line = stream.ReadLine();

                for (var x = 0; x < width; x++)
                {
                    if (x < line.Length)
                    {
                        var cell = map.GetCell(x, y);

                        switch (line[x])
                        {
                            case ' ':
                            {
                                cell.CellType = CellType.Empty;
                                break;
                            }
                            case '#':
                            {
                                cell.CellType = CellType.Wall;
                                break;
                            }
                            case 'g':
                                cell.CellType = CellType.Grass;
                                break;
                            case 'w':
                                cell.CellType = CellType.Water;
                                break;
                            case 't':
                                cell.CellType = CellType.Tree;
                                break;
                            case '.':
                            {
                                cell.CellType = CellType.Floor;
                                break;
                            }
                            case 'l':
                                cell.CellType = CellType.Floor;
                                GameMap.Actors.Add(new LinearMob(cell));
                                break;
                            case 'n':
                            {
                                cell.CellType = CellType.Floor;
                                GameMap.Actors.Add(new NormalMob(cell));
                                break;
                            }
                            case 'h':
                            {
                                cell.CellType = CellType.Floor;
                                GameMap.Actors.Add(new ShootingMob(cell, 1, 0));
                                break;
                            }
                            case 'v':
                            {
                                cell.CellType = CellType.Floor;
                                GameMap.Actors.Add(new ShootingMob(cell, 0, 1));
                                break;
                            }
                            case 'd':
                            {
                                cell.CellType = CellType.Floor;
                                GameMap.Items.Add(new Door(cell));
                                break;
                            }
                            case '@':
                            {
                                cell.CellType = CellType.Floor;
                                map.Player = new Player(cell);
                                break;
                            }
                            case 'k':
                            {
                                cell.CellType = CellType.Floor;
                                GameMap.Items.Add(new Key(cell));
                                break;
                            }
                            case 'e':
                            {
                                cell.CellType = CellType.Floor;
                                GameMap.Items.Add(new NextMapExit(cell));
                                break;
                            }
                            case 'r':
                            {
                                cell.CellType = CellType.Floor;
                                GameMap.Items.Add(new ReturnMapExit(cell));
                                break;
                            }
                        }
                    }
                }
            }

            return map;
        }
    }
}