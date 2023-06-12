using System;

namespace GamePromotion.DAL.Entities
{
    public abstract class EntityBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime startsat { get; set; }
        public DateTime expiresat { get; set;}
    }
}
