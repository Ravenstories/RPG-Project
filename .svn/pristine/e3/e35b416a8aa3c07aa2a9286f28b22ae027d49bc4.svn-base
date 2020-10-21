using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        public string ImageName { get; }
        public int RewardExperiencePoints { get; }
   
        public Monster (string name, string imageName, int maximumHitPoints, int currentHitPoints, 
            int rewardExperiencePoints, int gold) : base(name, maximumHitPoints, currentHitPoints, gold) 
        {
            ImageName = string.Format($"/Engine;component/Images/Monsters/{imageName}", imageName);
            RewardExperiencePoints = rewardExperiencePoints;
        }
    }
}
