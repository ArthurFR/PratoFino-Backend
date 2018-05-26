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

        [HttpGet("{id}", Name = "GetRestaurant")]
        public IActionResult GetById(int id)
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
        public IActionResult Update(int id, [FromBody] Restaurant item)
        {
            if(item == null || item.Id != id)
            {
                return BadRequest();
            }

            var restaurant = context.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            restaurant.Name = item.Name;
            
            context.Restaurants.Update(restaurant);
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var restaurant = context.Restaurants.Find(id);
            if(restaurant == null)
            {
                return NotFound();
            }

            context.Restaurants.Remove(restaurant);
            context.SaveChanges();
            return NoContent();
        }
    }
}