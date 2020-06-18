using Codecool.Quest.Models.Items;

namespace Codecool.Quest.Models.Actors
{
    public class Player : Actor
    {
        public override string TileName { get; set; } = "player";
        public new int Health { get; set; } = 1;
        public Player(Cell cell) : base(cell)
        {
        }

        public void Move(int dx, int dy)
        {
            var nextCell = Cell.GetNeighbor(dx, dy);
            // if player meets mob or shoot
            if (MeetsMobOrShoot(nextCell))
            {
                Game.MoveInterval = 10000;
            }
            else
            {
                // if player meets key
                if (nextCell.Item is Key)
                {
                    nextCell.Item = null;
                    GameMap.Items.ForEach(FoundItem =>
                    {
                        if (FoundItem is Door)
                        {
                            FoundItem.TileName = "floor";
                            FoundItem.Cell.Item = null;
                        }
                    });
                }

                // if player wins map
                if (nextCell.Item is NextMapExit)
                {
                    GameMap.Actors.Clear();
                    GameMap.level++;
                    if (GameMap.level > Game.HowManyMaps)
                    {
                        GameMap.level = 1;
                        Game.GameSingleton.Restart();
                    }
                    else
                    {
                        Game.GameSingleton.Restart();
                    }
                }

                // if player goes to previous map
                if (nextCell.Item is ReturnMapExit)
                {
                    GameMap.Actors.ForEach(Actor => Actor = null);
                    GameMap.level--;
                    Game.GameSingleton.Restart();
                }

                // normal move
                if (nextCell.CellType == CellType.Floor && !(nextCell.Item is Door) && !(nextCell.Item is Shoot) && !(nextCell.Actor is NormalMob) && !(nextCell.Actor is LinearMob) && !(nextCell.Actor is ShootingMob))
                {
                    Cell.Actor = null;
                    nextCell.Actor = this;
                    Cell = nextCell;
                }
            }
        }

        private static bool MeetsMobOrShoot(Cell nextCell)
        {
            return nextCell.Actor is NormalMob || nextCell.Actor is LinearMob || nextCell.Actor is ShootingMob || nextCell.Item is Shoot;
        }

        public override void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}