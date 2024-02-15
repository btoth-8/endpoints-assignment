using EndpointImplementationProject.Models;
using EndpointImplementationProject.Services;
using Microsoft.AspNetCore.Mvc;


namespace EndpointImplementationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToysController : ControllerBase
    {
        // GET api/Toys
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return ToyStorage.Toys;
        }


        // GET api/Toys/5
        [HttpGet("{toyid}")]
        public ActionResult<Toy> Get(Guid toyid)
        {
            // Find the toy in the ToyStorage in-memory database
            var toy = ToyStorage.Toys.FirstOrDefault(t => t.ToyId == toyid);

            if (toy == null)
            {
                return NotFound("Toy not found.");
            }

            return toy;
        }


        // POST api/Toys
        [HttpPost]
        public IActionResult AddNewToy(AddNewToyRequest addNewToyRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create a new Toy object from the AddNewToyRequest
            var toy = new Toy()
            {
                ToyId = Guid.NewGuid(),
                Description = addNewToyRequest.Description,
                ElementIds = addNewToyRequest.ElementIds,
                PictureId = addNewToyRequest.PictureId,
                UserId = addNewToyRequest.UserId
            };

            ToyStorage.Toys.Add(toy);

            return Ok(toy);
        }


        // PUT api/Toys/5
        [HttpPut("{toyId}")]
        public ActionResult Put(Guid toyId, [FromBody] ToyUpdateDto updatedToy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toy = ToyStorage.Toys.FirstOrDefault(t => t.ToyId == toyId);

            if (toy == null)
            {
                return NotFound("Toy not found.");
            }

            toy.ElementIds = updatedToy.ElementIds;
            toy.PictureId = updatedToy.PictureId;
            toy.Description = updatedToy.Description;

            return Ok(toy);
        }


        // DELETE api/Toys/5
        [HttpDelete("{toyid}")]
        public ActionResult Delete(Guid toyid)
        {
            var toy = ToyStorage.Toys.FirstOrDefault(t => t.ToyId == toyid);
            
            if (toy == null) 
            {
                return NotFound("Toy not found.");
            }

            ToyStorage.Toys.Remove(toy);

            return Ok(new { Message = "Toy successfully deleted." });
        }


        // GET api/Toys/SearchByElements?elementIds=element1&elementIds=element2
        [HttpGet("SearchByElements")]
        public ActionResult<IEnumerable<Toy>> SearchByElements([FromQuery] List<string> elementIds)
        {
            // Find the toys in ToyStorage in-memory database that contain any of the given elementIds in their ElementIds list
            var toys = ToyStorage.Toys.Where(t => t.ElementIds.Intersect(elementIds).Any()).ToList();

            if (toys.Count == 0)
            {
                return NotFound("No toys found matching the provided elements.");
            }

            return toys;
        }


        // PUT api/Toys/5/Score
        [HttpPut("{toyId}/Score")]
        public ActionResult Score(Guid toyId, [FromBody] Score score)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the authenticated user's ID (currently mock userId)
            var authenticatedUserId = "user-0";

            // Prevent the owner of the toy from scoring their own toy
            if (authenticatedUserId == score.UserId)
            {
                return Forbid("You cannot score your own toy.");
            }

            var toy = ToyStorage.Toys.FirstOrDefault(t => t.ToyId == toyId);

            if (toy == null)
            {
                return NotFound("Toy not found.");
            }

            toy.Scores.Add(score);

            return Ok(toy);
        }

    }
}
