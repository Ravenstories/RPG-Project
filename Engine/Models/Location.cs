using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;
using Engine.ViewModels;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageName { get; }
        public List<Quests> QuestsAvailableHere { get; } = new List<Quests>();

        public List<MonsterEncounter> MonsterHere { get; } = new List<MonsterEncounter>();

        public Trader TraderHere { get; set; }

        public RoadBlock AdvanceTo { get; set; }

        public Location(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            ImageName = imageName;
        }

        public void AddMonster(int monsterID, int chanceOfEncountering) 
        {
            if (MonsterHere.Exists(m => m.MonsterID == monsterID))
            {
                //Hvis monster er her, reset gammel værdi med ny værdi.
                MonsterHere.First(m => m.MonsterID == monsterID).ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                //Hvis der ikke er noget monster, tilføj monster.
                MonsterHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }
        }
        public Monster GetMonster() 
        {
            if (!MonsterHere.Any())
            {
                return null;
            }
            // Procenten af monster på given location
            int totalChances = MonsterHere.Sum(m => m.ChanceOfEncountering);
            // Finder et nummer mellem 1 og maks
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            int runningTotal = 0;

            foreach (MonsterEncounter monsterEncounter in MonsterHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;
                if (randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }
            // Hvis der er en fejl i listen, giver den sidste kendte id     
            return MonsterFactory.GetMonster(MonsterHere.Last().MonsterID);
        }
    }
}