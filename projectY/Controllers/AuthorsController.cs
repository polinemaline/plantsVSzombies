using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using projectY.Manager;
using projectY.Models;

namespace projectY.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IManagerAuthor _manager;

        public AuthorsController(IManagerAuthor manager)
        {
            _manager = manager;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _manager.GetAuthorsAsync();
            return Ok(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _manager.GetAuthorByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            var success = await _manager.UpdateAuthorAsync(id, author);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            var createdAuthor = await _manager.CreateAuthorAsync(author);
            return CreatedAtAction("GetAuthor", new { id = createdAuthor.Id }, createdAuthor);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var success = await _manager.DeleteAuthorAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
