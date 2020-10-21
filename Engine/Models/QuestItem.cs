using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class QuestItem
    {
        public int ID { get; }
        public string Name { get; }
        public List<ItemQuantity> QuestItems { get; } = new List<ItemQuantity>();

        public QuestItem(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public void AddQuestItem(int itemID, int quantity)
        {
            if (!QuestItems.Any(x => x.ItemID == itemID))
            {
                QuestItems.Add(new ItemQuantity(itemID, quantity));
            }
        }
     }
}