using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionsController : ControllerBase
    {
        private List<Directions> direction = new List<Directions>
        {
            new Directions
            {
                Id = 1,
                StartLatitude = 6.27829,
                StartLongitude = 81.40232,
                DestLatitude = 6.31331,
                DestLongitude = 81.46917
            },
            new Directions
            {
                Id = 2,
                StartLatitude = 6.27829,
                StartLongitude = 81.40232,
                DestLatitude = 6.31331,
                DestLongitude = 81.46917
            }
        };
        [HttpGet]
        public IActionResult GetDirections()
        {
            return Ok(direction);
        }

        [HttpPost]
        public IActionResult CreateDirections([FromBody]Directions newDirection)
        {
            newDirection.Id = direction.Select(s => s.Id).Max() + 1;
            direction.Add(newDirection);

            return Ok(newDirection); 
        }

        [HttpPut]
        public IActionResult UpdateDirections(int id,[FromBody] Directions updateDirection)
        {
            var directions = direction.Where(s => s.Id == id).FirstOrDefault();

            if (directions == null)
                return NotFound();

            directions.StartLatitude = updateDirection.StartLatitude;
            directions.StartLongitude = updateDirection.StartLongitude;
            directions.DestLatitude = updateDirection.DestLatitude;
            directions.DestLongitude = updateDirection.DestLongitude;

            var index = direction.FindIndex(s => s.Id == id);
            direction[index] = directions;

            return Ok(directions);
        }
    }
}
