using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Actions
{
    public class Heal : IAction
    {
        private readonly GameItem _item;
        private readonly int _minimumHitPointsToHeal;
        private readonly int _maximumHitPointsToHeal;

        public event EventHandler<string> OnActionPerformed;

        public Heal(GameItem item, int minimumHitPointsToHeal, int maximumHitPointsToHeal)
        {
            if(item.Category != GameItem.ItemCategory.Consumable)
            {
                throw new ArgumentException($"{item.Name} is not consumable");
            }
            _item = item;
            _minimumHitPointsToHeal = minimumHitPointsToHeal;
            _maximumHitPointsToHeal = maximumHitPointsToHeal;
        }

        public void Execute(LivingEntity actor, LivingEntity target)
        {
            int heal = RandomNumberGenerator.NumberBetween(_maximumHitPointsToHeal, _maximumHitPointsToHeal);

            string actorName = (actor is Player) ? "You" : $"The {actor.Name.ToLower()}";
            string targetName = (target is Player) ? "yourself" : $"the {target.Name.ToLower()}";

            ReportResult($"{actorName} heal {targetName} for {heal} point{(heal > 1 ? "s" : "")}");
            target.Heal(heal);
        }

        private void ReportResult(string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
    }
}
