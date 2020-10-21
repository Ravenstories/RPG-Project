using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.ViewModels;


namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(2, -2, "Farmer's Field",
                "There are rows of corn growing here, with giant rats hiding between them.",
                "Field.jpg");
            newWorld.LocationAt(2, -2).AddMonster(2, 80);
            newWorld.LocationAt(2, -2).AddMonster(4, 20);

            newWorld.AddLocation(2, -1, "Lonely farm",
                "This is the house of farmer David.",
                "FarmerHouse.jpg");
            newWorld.LocationAt(2, -1).TraderHere = TraderFactory.GetTraderByName("David the farmer");
            newWorld.LocationAt(2, -1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(2));

            newWorld.AddLocation(0, -1, "Home",
                "This is your home",
                "Home.jpg");

            newWorld.AddLocation(-1, 0, "Trading Shop",
                "The shop of River, the trader.",
                "Shop.jpg");
            newWorld.LocationAt(-1, 0).TraderHere = TraderFactory.GetTraderByName("River");

            newWorld.AddLocation(0, 0, "Town square",
                "You see a fountain here and two shops one to the north and one to the east. You live to the south",
                "TownSquare.jpg");

            newWorld.AddLocation(1, 0, "Town Gate",
                "There is a gate here, protecting the town.",
                "TownGate.jpg");

            newWorld.AddLocation(2, 0, "Road outside the town",
                "Long and winding roads. To the east, the spider forest, south is the fields and to the north is the mountain.",
                "Road.jpg");
            newWorld.LocationAt(2, 0).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(3));
            newWorld.LocationAt(2, 0).TraderHere = TraderFactory.GetTraderByName("Tore the bug expert");

            newWorld.AddLocation(3, 0, "Spider Forest",
                "The trees in this forest are covered with spider webs.",
                "SpiderForest.jpg");
            newWorld.LocationAt(3, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "Herbalist's hut",
                "You see a small hut, with plants drying from the roof.",
                "HerbalistHouse.jpg");
            newWorld.LocationAt(0, 1).TraderHere = TraderFactory.GetTraderByName("Florian Flower");
            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(0, 2, "Herbalist's garden",
                "There are many plants here, with snakes hiding behind them.",
                "HerbalistGarden.jpg");
            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            newWorld.AddLocation(99, 99, "The Gate Beyond",
                "You died all too young",
                "Dead.jpg");

            return newWorld;
        }
    }
}