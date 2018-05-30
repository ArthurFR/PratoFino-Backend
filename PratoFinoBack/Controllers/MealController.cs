using Microsoft.AspNetCore.Mvc;
using PratoFinoBack.Data;
using PratoFinoBack.Models;
using System.Collections.Generic;
using System.Linq;

namespace PratoFinoBack.Controllers
{
    [Route("api/[controller]")]
    public class MealController : Controller
    {
        private readonly PratoFinoDbContext context;

        public MealController(PratoFinoDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Meal> GetAll()
        {
            return context.Meals.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var meal = context.Meals.Find(id);
            if(meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        [HttpPost]
        public void Insert([FromBody]Meal meal)
        {
            if (meal == null)
            {
                return;
            }

            this.context.Meals.Add(meal);
            this.context.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]Meal item)
        {
            if(item == null || item.Id != id )
            {
                return BadRequest();
            }

            var meal = context.Meals.Find(id);
            if(meal == null)
            {
                return NotFound();
            }

            meal.Name = item.Name;
            meal.Restaurant = item.Restaurant;
            meal.RestaurantId = item.RestaurantId;
            meal.Price = item.Price;
            context.Meals.Update(meal);
            context.SaveChanges();
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (long id)
        {
            var meal = context.Meals.Find(id);
            if (meal == null)
            {
                return NotFound();
            }

            context.Meals.Remove(meal);
            context.SaveChanges();
            return NoContent();
        }
    }
}