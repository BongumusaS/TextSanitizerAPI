using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextSanitizerAPI.DataContext;

namespace TextSanitizerAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class SanitizeController : ControllerBase
    {
        private  ApplicationDbContext _context;

        public SanitizeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Sanitize
        [HttpPost]
        [Route("sanitize")]
        [SwaggerOperation(Summary = "Sanitize a string", Description = "Replaces sensitive words in a string with asterisks.")]
        [SwaggerResponse(StatusCodes.Status200OK, "OK")]
        public async Task<ActionResult<string>> SanitizeString([FromBody] string input)
        {
            var sensitiveWords = await _context.SensitiveWords.Select(w => w.Word.ToLower()).ToListAsync();
            foreach (var word in sensitiveWords)
            {
                input = Regex.Replace(input, Regex.Escape(word), new string('*', word.Length), RegexOptions.IgnoreCase);
            }
            return Ok(input);
        }

    }

}
