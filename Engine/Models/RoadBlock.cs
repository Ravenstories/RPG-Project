using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class RoadBlock
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public List<ItemQuantity> QuestItemsToProgress { get; set; }
        public List<QuestStatus> QuestNeededToProgress { get; set; }

        public RoadBlock(int id, string name, string description, List<ItemQuantity> questItemsToProgress, List<QuestStatus> questNeededToProgress)
        {
            ID = id;
            Name = name;
            Description = description;
            QuestItemsToProgress = questItemsToProgress;
            QuestNeededToProgress = questNeededToProgress;
        }
    }

}
