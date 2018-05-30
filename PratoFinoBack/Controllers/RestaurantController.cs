using Microsoft.AspNetCore.Mvc;
using PratoFinoBack.Data;
using PratoFinoBack.Models;
using System.Linq;
using System.Collections.Generic;

namespace PratoFinoBack.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly PratoFinoDbContext context;
        public RestaurantController(PratoFinoDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Restaurant> GetAll()
        {
            return context.Restaurants.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var restaurant = context.Restaurants.Find(id);
            if(restaurant == null)
            {
                return NotFound();
            }
            
            return Ok(restaurant);
        }

        [HttpPost]
        public void Insert([FromBody] Restaurant restaurant)
        {
            if(restaurant == null)
            {
                return;
            }

            context.Restaurants.Add(restaurant);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Restaurant item)
        {
            if(item == null || item.RestaurantId != id)
            {
                return BadRequest();
            }

            var restaurant = context.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            restaurant.RestaurantName = item.RestaurantName;
            
            context.Restaurants.Update(restaurant);
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var restaurant = context.Restaurants.Find(id);
            if(restaurant == null)
            {
                return NotFound();
            }
            
            foreach(Meal meal in restaurant.Meals){
                context.Meals.Remove(meal);
            }
            context.SaveChanges();
            
            context.Restaurants.Remove(restaurant);
            context.SaveChanges();
            return NoContent();
        }
    }
}