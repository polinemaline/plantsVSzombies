using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectY.Manager;
using projectY.Models;

namespace projectY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IManagerPublisher _manager;

        public PublishersController(IManagerPublisher manager)
        {
            _manager = manager;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
        {
            var publisher = await _manager.GetPublishersAsync();
            return Ok(publisher);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(int id)
        {
            var publisher = await _manager.GetPublisherByIdAsync(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return Ok(publisher);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            var success = await _manager.UpdatePublisherAsync(id, publisher);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<Author>> PostPublisher(Publisher publisher)
        {
            var createdPublisher = await _manager.CreatePublisherAsync(publisher);
            return CreatedAtAction("GetPublisher", new { id = createdPublisher.Id }, createdPublisher);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var success = await _manager.DeletePublisherAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
