using Game.Interfaces;
using System;

namespace Game
{
    public class Player : IDrawable, IMovable
    {
        public Position Position;
        public Direction MoveDirection;
        public Map CurrentMap = null;

        private int beatenEnemies;

        public int BeatenEnemiesold
        {
            get { return beatenEnemies; }
            set
            {
                if (beatenEnemies < 0)
                {
                    beatenEnemies = 0;
                }
                else
                {
                    beatenEnemies = value;
                }
            }
        }

        private int gold;

        public int Gold
        {
            get { return gold; }
            set
            {
                if (gold < 0)
                {
                    gold = 0;
                }
                else
                {
                    gold = value;
                }
            }
        }

        private int health;
        public int Health
        {
            get { return health; }
            set
            {
                if (health < 0)
                {
                    health = 0;
                }
                else if (health > 200)
                {
                    health = 200;
                }
                else
                {
                    health = value;
                }
            }
        }

        private static Player instance = null;

        public static Player GetInstance()
        {
            if (instance == null)
                instance = new Player();
            return instance;
        }

        private Player()
        {
            Position = new Position(1, 1);
            Health = 100;
            Gold = 0;
        }

        #region IDrawable implementation
        public void Draw()
        {
            Console.ForegroundColor = GetColor();
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(GetSymbol());
        }

        public ConsoleColor GetColor()
        {
            return ConsoleColor.Green;
        }

        public char GetSymbol()
        {
            return '*';
        }
        #endregion

        #region IMovable implementation
        public Direction GetMoveDirection()
        {
            return MoveDirection;
        }

        public bool CanMove()
        {
            if (CurrentMap == null)
                return false;

            var tempPosition = new Position(Position.X, Position.Y);
            tempPosition.Move(GetMoveDirection());

            return !(tempPosition.X < CurrentMap.MinLeft ||
                tempPosition.X > CurrentMap.MaxLeft ||
                tempPosition.Y < CurrentMap.MinTop ||
                tempPosition.Y > CurrentMap.MaxTop);
        }

        public void Move()
        {
            Position.Move(GetMoveDirection());
        }
        #endregion
    }
}
