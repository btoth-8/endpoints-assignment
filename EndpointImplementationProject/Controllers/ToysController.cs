using EndpointImplementationProject.Models;
using EndpointImplementationProject.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndpointImplementationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToysController : ControllerBase
    {
        // GET: api/Toys
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return ToyStorage.Toys;
        }


        // GET api/Toys/5
        [HttpGet("{id}")]
        public ActionResult<Toy> Get(int id)
        {
            var toy = ToyStorage.Toys.FirstOrDefault(t => t.ToyId == id);
            if (toy == null)
            {
                return NotFound();
            }
            return toy;
        }


        // PUT api/Toys/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Toy updatedToy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            else 
            {
                var toy = ToyStorage.Toys.FirstOrDefault(t => t.ToyId == id);
                if (toy == null)
                {

                    return NotFound();
                }

                // Update the toy properties
                toy.ElementId = updatedToy.ElementId;
                toy.UserId = updatedToy.UserId;
                toy.PictureId = updatedToy.PictureId;
                toy.Description = updatedToy.Description;

                return NoContent();
            }
        }


        // POST api/Toys
        [HttpPost]
        public ActionResult<Toy> Post([FromBody] Toy newToy)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            else 
            {
                // Add the new toy to the storage
                ToyStorage.Toys.Add(newToy);

                // Return the added toy with a CreatedAtAction status code
                return CreatedAtAction(nameof(Get), new { id = newToy.ToyId }, newToy);
            }
        }


        // DELETE api/Toys/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var toy = ToyStorage.Toys.FirstOrDefault(t => t.ToyId == id);
            
            if (toy == null) 
            {
                return NotFound();
            }

            ToyStorage.Toys.Remove(toy);
            return NoContent();
        }


        // GET api/Toys/SearchByElement/{elementId}
        [HttpGet("SearchByElement/{elementId}")]
        public ActionResult<IEnumerable<Toy>> SearchByElement(string elementId)
        {
            var toys = ToyStorage.Toys.Where(t => t.ElementId == elementId).ToList();
            
            if (toys.Count == 0) 
            {
                return NotFound();
            }
            return toys;
        }


        // PUT api/Toys/5/Score
        [HttpPut("{id}/Score")]
        public ActionResult Score(int id, [FromBody] Score score)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            } 
            else 
            {
                var toy = ToyStorage.Toys.FirstOrDefault(t => t.ToyId == id);
                if (toy == null) {

                    return NotFound();
                }

                toy.Scores.Add(score);
                return NoContent();
            }
        }
    }
}
