using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class GoldItem : Item
    {
        public new int amount;
        public new string type = "gold";
        public GoldItem(int x, int y, int amount) : base(x,y)
        {
            this.amount = amount;
        }

        public override void ActionOnCollision()
        {
            Program.CurrentItem = this;
            //Program.RemoveItem(this);
            Player.GetInstance().Gold += amount;
            // Ausgabe 50 Gold gefunden, aktueller Bestand:...
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkYellow;
        }

        public override char GetSymbol()
        {
            return 'G';
        }

    }
}
