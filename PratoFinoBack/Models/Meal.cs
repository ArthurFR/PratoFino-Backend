namespace PratoFinoBack.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}