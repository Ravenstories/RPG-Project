using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Models;
using Engine.Actions;
namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static readonly List<GameItem> _standardGameItems = new List<GameItem>();

        static ItemFactory()
        {
            //Player Weapons
            BuildWeapon(1001, "Pointy Stick", 1, 0, 2);
            BuildWeapon(1002, "Rusty Sword", 5, 1, 3);
            BuildWeapon(1003, "Scythe", 10, 2, 4);
            BuildWeapon(1004, "Longsword", 100, 8, 18);
            BuildWeapon(1005, "Excalibur", 5000, 10, 50);

            //Monster Weapons
            BuildWeapon(1501, "Snake sangs", 0, 0, 2);
            BuildWeapon(1502, "Rat claws", 0, 0, 2);
            BuildWeapon(1503, "Spider fangs", 0, 0, 4);
            BuildWeapon(1504, "Scarecrow claws", 0, 3, 6);

            //Healing Items
            BuildHealingItem(2001, "Mysterious herb", 3, 2, 4);
            BuildHealingItem(2002, "Strong potion", 10, 10, 20);
            BuildHealingItem(2003, "Code of life", 100, 1000, 1000);

            //Ingredients
            BuildMiscellaneousItem(3001, "Empty bottle", 1);
            BuildMiscellaneousItem(3002, "Potent destilled water", 2);

            //Quest Items
            BuildMiscellaneousItem(4001, "Gate Key", 0);

            //Monster drops
            BuildMiscellaneousItem(9001, "Snakeskin", 1);
            BuildMiscellaneousItem(9002, "Snake fang", 2);
            BuildMiscellaneousItem(9003, "Rat Tail", 1);
            BuildMiscellaneousItem(9004, "Rat Fur", 2);
            BuildMiscellaneousItem(9005, "Spider fang", 1);
            BuildMiscellaneousItem(9006, "Spider silk", 2);
            BuildMiscellaneousItem(9007, "Cursed hay", 5);
            BuildMiscellaneousItem(9008, "Corrupted heart", 50);
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            return _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

        }
        private static void BuildMiscellaneousItem(int id, string name, int price)
        {
            _standardGameItems.Add(new GameItem(GameItem.ItemCategory.Miscellaneous, id, name, price));
        }
        private static void BuildWeapon(int id, string name, int price, int minimumDamage, int maximumDamage)
        {
            GameItem weapon = new GameItem(GameItem.ItemCategory.Weapon, id, name, price, true);

            weapon.Action = new AttackWithWeapon(weapon, minimumDamage, maximumDamage);

            _standardGameItems.Add(weapon);
        }
        private static void BuildHealingItem(int id, string name, int price, int minimumHitPointsToHeal, int maximumHitPointsToHeal) 
        {
            GameItem item = new GameItem(GameItem.ItemCategory.Consumable, id, name, price);
            item.Action = new Heal(item, minimumHitPointsToHeal, maximumHitPointsToHeal);
            _standardGameItems.Add(item);
        }

        public static string ItemName(int itemTypeID)
        {
            return _standardGameItems.FirstOrDefault(i => i.ItemTypeID == itemTypeID)?.Name ?? "";
        }
    }
}