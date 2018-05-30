using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PratoFinoBack.Models
{
    public class Meal
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}