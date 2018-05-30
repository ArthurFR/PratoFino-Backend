using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PratoFinoBack.Models
{
    public class Restaurant
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        public virtual List<Meal> Meals { get; set;} = new List<Meal>();
    }
}
