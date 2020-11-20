using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class MeinTest
    {


        public Item GetItem(string type, int amount, int x, int y)
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

        public void TestMethode()
        {
            Console.WriteLine("ich mach garnix");
        }


    }
}
