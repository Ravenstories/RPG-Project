﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int monsterID)
        {
            switch (monsterID)
            {
                case 1:
                    Monster snake =
                        new Monster("Snake", "Snake.jpg", 4, 4, 5, 1);

                    snake.CurrentWeapon = ItemFactory.CreateGameItem(1501);
                    AddLootItem(snake, 9001, 25);
                    AddLootItem(snake, 9002, 75);

                    return snake;

                case 2:
                    Monster rat =
                        new Monster("Rat", "Rat.jpg", 5, 5, 5, 1);

                    rat.CurrentWeapon = ItemFactory.CreateGameItem(1502);
                    AddLootItem(rat, 9003, 25);
                    AddLootItem(rat, 9004, 75);
                    AddLootItem(rat, 3001, 40);

                    return rat;

                case 3:
                    Monster spider =
                        new Monster("Spider", "Spider.jpg", 10, 10, 10, 1);

                    spider.CurrentWeapon = ItemFactory.CreateGameItem(1503);
                    AddLootItem(spider, 9005, 25);
                    AddLootItem(spider, 9006, 75);
                    AddLootItem(spider, 3002, 35);

                    return spider;

                case 4:
                    Monster scarecrow =
                        new Monster("Scarecrow", "Scarecrow.jpg", 30, 30, 100, 0);

                    scarecrow.CurrentWeapon = ItemFactory.CreateGameItem(1504);
                    AddLootItem(scarecrow, 9007, 90);
                    AddLootItem(scarecrow, 9008, 10);

                    return scarecrow;

                default:
                    throw new ArgumentException(string.Format("MontsterType '{0}' does not exist", monsterID));
            }
        }
        private static void AddLootItem(Monster monster, int itemID, int percentage)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
                monster.AddItemToInventory(ItemFactory.CreateGameItem (itemID));
            }
        }
    }
}
