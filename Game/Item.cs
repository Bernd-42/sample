using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{


    public abstract class Item : ICollidable, IDrawable
    {

        public Position Position;
        public Map CurrentMap = null;
        public string type;
        public int amount;


        public Item(int x, int y)
        {
            Position = new Position(x, y);
        }

        public virtual void ActionOnCollision()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            Console.ForegroundColor = GetColor();
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(GetSymbol());
        }

        public virtual ConsoleColor GetColor()
        {
            throw new NotImplementedException();
        }

        public Position GetPosition()
        {
            return Position;
        }

        public virtual char GetSymbol()
        {
            throw new NotImplementedException();
        }
    }
}
