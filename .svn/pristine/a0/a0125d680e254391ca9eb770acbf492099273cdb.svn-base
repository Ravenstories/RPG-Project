using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Trader : LivingEntity
    {
        public string ImageName { get; }
        public Trader(string name, string imageName) : base(name, 9999, 9999, 9999)
        {
            ImageName = string.Format($"/Engine;component/Images/Characters/{imageName}", imageName);
        }
    }
}
