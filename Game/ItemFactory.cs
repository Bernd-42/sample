using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class ItemFactory
    {
        public Item GetItem(string type, int x, int y, int amount)
        {
            switch (type)
            {
                case "gold":
                    return new GoldItem(x, y, amount);
                case "potion":
                    return new PotionItem(x, y, amount);

            }

            throw new Exception($"Item with {type} does not exist");
        }
    }
}
