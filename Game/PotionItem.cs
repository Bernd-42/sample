using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class PotionItem : Item
    {
       
        public int amount;
        public string type = "potion";
        public PotionItem(int x, int y, int health) : base(x, y)
        {
            this.amount = health;
       
    }
        public override void ActionOnCollision()
        {
            Player.GetInstance().Health += amount;
            Program.CurrentItem = this; ;
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Blue;
        }

        public override char GetSymbol()
        {
            return '&';
        }


    }
}
