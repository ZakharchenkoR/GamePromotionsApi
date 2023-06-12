using System;

namespace GamePromotion.BAL.Models
{
    public class ModelBase
    {
        public string Name { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
