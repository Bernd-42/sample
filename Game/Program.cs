using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Game
{
    class Program
    {
        const string ENEMY_DATA_PATH = "enemies.json";
        const string ITEM_DATA_PATH = "items.json";

        static List<IDrawable> DrawableEntities = new List<IDrawable>();
        static List<IMovable> MovableEntities = new List<IMovable>();
        static List<ICollidable> Collidables = new List<ICollidable>();

        static EnemyFactory EnemyFactory = new EnemyFactory();
        static ItemFactory ItemFactory = new ItemFactory();

        public static bool IsFighting = false;
        public static Enemy CurrentEnemy = null;
        public static Item CurrentItem = null;

        static bool IsGameOver = false;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Map map = new Map(1, 1, 20, 50);

            List<EnemySaveData> enemySaveDataList = LoadEnemySaveData(true);
            foreach (EnemySaveData enemySaveData in enemySaveDataList)
            {
                GenerateEnemy(enemySaveData.EnemyType, map, enemySaveData.X, enemySaveData.Y);
            }

            List<ItemSafeData> itemSafeDataList = LoadItemSafeData(true);
            foreach (ItemSafeData item in itemSafeDataList)
            {
                GenerateItem("gold", map, 3, 5, 66);
                GenerateItem("gold", map, 13, 15, 66);
                GenerateItem("potion", map, 3, 15, 66);
                GenerateItem("potion", map, 7, 5, 66);
            }


            Player player = Player.GetInstance();
            player.CurrentMap = map;

            DrawableEntities.Add(map);
            DrawableEntities.Add(player);
            MovableEntities.Add(player);

            while (!IsGameOver)
            {
                if (IsFighting)
                {
                    DrawFightScreen();
                }
                else
                {
                    if (CurrentItem != null)
                    {

                        CheckItem();
                    }
                    DrawScreen();
                    HandleInput();
                    MoveEntities();
                    CheckCollisions();
                }

                if (IsGameOver)
                    DrawGameOverScreen();
            }
        }


        //todo Item verschwindet erst beim 4. treffer => Fehlersuche
        static void CheckItem()
        {

            if (CurrentItem.type == "gold")
            {
                Player.GetInstance().Gold += CurrentItem.amount;
            }
            else if (CurrentItem.type == "potion")
            {
                Player.GetInstance().Health += CurrentItem.amount;
            }

            Collidables.Remove(CurrentItem);
            DrawableEntities.Remove(CurrentItem);
            CurrentItem = null;
        }

        static void GenerateEnemySaveData()
        {
            if (!File.Exists(ENEMY_DATA_PATH))
            {
                List<EnemySaveData> enemySaveDataList = new List<EnemySaveData>();
                enemySaveDataList.Add(new EnemySaveData()
                {
                    EnemyType = "orc",
                    X = 5,
                    Y = 10
                });
                enemySaveDataList.Add(new EnemySaveData()
                {
                    EnemyType = "demon",
                    X = 15,
                    Y = 15
                });
                enemySaveDataList.Add(new EnemySaveData()
                {
                    EnemyType = "undead",
                    X = 20,
                    Y = 8
                });

                string json = JsonSerializer.Serialize(enemySaveDataList);
                File.WriteAllText(ENEMY_DATA_PATH, json);
            }
        }

        static void GenerateItemSafeData()
        {
            if (!File.Exists(ITEM_DATA_PATH))
            {
                List<ItemSafeData> itemSafeDataList = new List<ItemSafeData>();

                itemSafeDataList.Add(
                    new ItemSafeData()
                    {
                        ItemType = "gold",
                        X = 17,
                        Y = 15,
                        Amount = 50
                    });
                itemSafeDataList.Add(
                new ItemSafeData()
                {
                    ItemType = "gold",
                    X = 12,
                    Y = 12,
                    Amount = 30
                });
                itemSafeDataList.Add(
                new ItemSafeData()
                {
                    ItemType = "potion",
                    X = 4,
                    Y = 15,
                    Amount = 50
                });
                itemSafeDataList.Add(
                 new ItemSafeData()
                 {
                     ItemType = "potion",
                     X = 17,
                     Y = 5,
                     Amount = 40
                 });

                string json = JsonSerializer.Serialize(itemSafeDataList);
                File.WriteAllText(ITEM_DATA_PATH, json);

            }
        }


        static List<ItemSafeData> LoadItemSafeData(bool generateOnFail)
        {
            List<ItemSafeData> itemSafeDataList = new List<ItemSafeData>();
            try
            {
                string json = File.ReadAllText(ITEM_DATA_PATH);
                itemSafeDataList = JsonSerializer.Deserialize(json, typeof(List<ItemSafeData>)) as List<ItemSafeData>;
            }
            catch (FileNotFoundException)
            {
                if (generateOnFail)
                {
                    GenerateItemSafeData();
                    return LoadItemSafeData(false);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed loading and generating item data.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

            }
            catch (JsonException)
            {
                if (generateOnFail)
                {
                    File.Delete(ITEM_DATA_PATH);
                    GenerateItemSafeData();
                    return LoadItemSafeData(false);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed loading and generating item data.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            return itemSafeDataList;
        }



        static List<EnemySaveData> LoadEnemySaveData(bool generateOnFail)
        {
            List<EnemySaveData> enemySaveDataList = new List<EnemySaveData>();

            try
            {
                string json = File.ReadAllText(ENEMY_DATA_PATH);
                enemySaveDataList = JsonSerializer.Deserialize(json, typeof(List<EnemySaveData>)) as List<EnemySaveData>;
            }
            catch (FileNotFoundException)
            {
                if (generateOnFail)
                {
                    GenerateEnemySaveData();
                    return LoadEnemySaveData(false);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed loading and generating enemy data.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            catch (JsonException)
            {
                if (generateOnFail)
                {
                    File.Delete(ENEMY_DATA_PATH);
                    GenerateEnemySaveData();
                    return LoadEnemySaveData(false);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed loading and generating enemy data.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }

            return enemySaveDataList;
        }

        static void GenerateEnemy(string name, Map map, int x, int y)
        {
            Enemy enemy = EnemyFactory.GetEnemy(name, x, y);
            enemy.CurrentMap = map;
            DrawableEntities.Add(enemy);
            MovableEntities.Add(enemy);
            Collidables.Add(enemy);
        }

        static void GenerateItem(string typ, Map map, int x, int y, int amount)
        {
            Item item = ItemFactory.GetItem(typ, x, y, amount);
            item.CurrentMap = map;
            DrawableEntities.Add(item);
            Collidables.Add(item);

        }

        static void RemoveItem(Item item)
        {
            DrawableEntities.Remove(item);
            Collidables.Remove(item);
        }

        static void RemoveEnemy(Enemy enemy)
        {
            DrawableEntities.Remove(enemy);
            MovableEntities.Remove(enemy);
            Collidables.Remove(enemy);
        }

        static void MoveEntities()
        {
            foreach (var movableEntity in MovableEntities)
            {
                if (movableEntity.CanMove())
                    movableEntity.Move();
            }
        }

        static void CheckCollisions()
        {
            foreach (ICollidable collidable in Collidables)
            {
                if (Player.GetInstance().Position.IsEqual(collidable.GetPosition()))
                {
                    collidable.ActionOnCollision();
                }
            }
        }

        static void DrawGameOverScreen()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.ReadLine();
        }

        static void DrawFightScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Fight started!");
            Console.WriteLine($"Your Health: {Player.GetInstance().Health}");
            Console.WriteLine($"Enemy's Health: {CurrentEnemy.Health}");
            Console.WriteLine("Choose action:");
            Console.WriteLine("    0) Run away");
            Console.WriteLine("    1) Fight");

            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 0:
                    IsFighting = false;
                    CurrentEnemy = null;
                    // todo Zufallsgenerator für Gegnertreffer auf Flucht
                    break;
                case 1:
                    Random random = new Random();
                    int randomNumber = random.Next(0, 100);
                    if (randomNumber <= 30)
                    {
                        Player.GetInstance().Health -= 10;
                    }
                    else
                    {
                        CurrentEnemy.Health -= 10;
                    }

                    if (Player.GetInstance().Health <= 0)
                        IsGameOver = true;

                    if (CurrentEnemy.Health <= 0)
                    {
                        RemoveEnemy(CurrentEnemy);
                        CurrentEnemy = null;
                        IsFighting = false;
                    }
                    break;
                default:
                    break;
            }
        }

        static void DrawScreen()
        {
            Console.Clear();

            foreach (var drawableEntity in DrawableEntities)
            {
                drawableEntity.Draw();
            }
        }

        static void HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    Player.GetInstance().MoveDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    Player.GetInstance().MoveDirection = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    Player.GetInstance().MoveDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    Player.GetInstance().MoveDirection = Direction.Down;
                    break;
                default:
                    Player.GetInstance().MoveDirection = Direction.None;
                    break;
            }
        }
    }
}
