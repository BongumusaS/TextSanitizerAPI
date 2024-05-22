using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextSanitizerAPI.DataContext;
using TextSanitizerAPI.Models;
using Swashbuckle.AspNetCore.Annotations;



namespace TextSanitizerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensitiveWordsController : ControllerBase
    {
        private  ApplicationDbContext _context;
        private ILogger<SensitiveWordsController> _logger;

        public SensitiveWordsController(ApplicationDbContext context, ILogger<SensitiveWordsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/SensitiveWords
        [HttpGet]
        [SwaggerOperation(Summary = "Get all items", Description = "Returns a list of all items.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(IEnumerable<SensitiveWord>))]
        public async Task<ActionResult<IEnumerable<SensitiveWord>>> GetSensitiveWords()
        {

           // Perfomance optimization

            return await _context.SensitiveWords
           .AsNoTracking()
           .ToListAsync();



            //  return await _context.SensitiveWords.ToListAsync();

        }

        // POST: api/SensitiveWords
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new sensitive word", Description = "Creates a new sensitive word.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Created", typeof(SensitiveWord))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        public async Task<ActionResult<SensitiveWord>> AddSensitiveWord(SensitiveWord word)
        {
            _logger.LogInformation("Adding a new sensitive word: {Word}", word.Word);
            _context.SensitiveWords.Add(word);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSensitiveWords), new { id = word.Id }, word);
        }

        // PUT: api/SensitiveWords/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a sensitive word", Description = "Updates an existing sensitive word.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "No Content")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found", typeof(string))]
        public async Task<IActionResult> UpdateSensitiveWord(int id, SensitiveWord word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            _context.Entry(word).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/SensitiveWords/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a sensitive word", Description = "Deletes an existing sensitive word.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "No Content")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found", typeof(string))]
        public async Task<IActionResult> DeleteSensitiveWord(int id)
        {
            var word = await _context.SensitiveWords.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _context.SensitiveWords.Remove(word);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
