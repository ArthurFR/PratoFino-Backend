using System.Collections.Generic;

namespace PratoFinoBack.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Meal> Meals { get; set;}
    }
}
