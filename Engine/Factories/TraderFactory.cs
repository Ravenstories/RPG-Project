﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class TraderFactory
    {
        private static readonly List<Trader> _traders = new List<Trader>();
        static TraderFactory()
        {
            Trader river = new Trader("River", "Trader.jpg");
            river.AddItemToInventory(ItemFactory.CreateGameItem(2002),10);
            river.AddItemToInventory(ItemFactory.CreateGameItem(1004));

            Trader davidTheFarmer = new Trader("David the farmer","Farmer.jpg");
            davidTheFarmer.AddItemToInventory(ItemFactory.CreateGameItem(1003));

            Trader florian = new Trader("Florian Flower", "Herbalist.jpg");
            florian.AddItemToInventory(ItemFactory.CreateGameItem(1001)); 
            florian.AddItemToInventory(ItemFactory.CreateGameItem(2001),40);

            Trader tore = new Trader("Tore the bug expert", "Tore.jpg");
            tore.AddItemToInventory(ItemFactory.CreateGameItem(1001), 2);
            tore.AddItemToInventory(ItemFactory.CreateGameItem(2003));

            AddTraderToList(river);
            AddTraderToList(davidTheFarmer);
            AddTraderToList(florian);
            AddTraderToList(tore);
        }
        public static Trader GetTraderByName(string name)
        {
            return _traders.FirstOrDefault(t => t.Name == name);
        }
        private static void AddTraderToList(Trader trader)
        {
            if(_traders.Any(t => t.Name == trader.Name))
            {
                throw new ArgumentException($"There is already a trader named '{trader.Name}'");
            }
            _traders.Add(trader);   
        }
    }
}
