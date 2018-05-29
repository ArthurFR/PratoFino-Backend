namespace PratoFinoBack.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}