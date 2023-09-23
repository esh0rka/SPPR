using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_153504_Gaikevich.API.Data;
using WEB_153504_Gaikevich.API.Services;
using WEB_153504_Gaikevich.Domain.Entities;
using WEB_153504_Gaikevich.Domain.Models;

namespace WEB_153504_Gaikevich.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoPartsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAutoPartService _autoPartService;

        public AutoPartsController(AppDbContext context, IAutoPartService autoPartService)
        {
            _context = context;
            _autoPartService = autoPartService;
        }

        [HttpGet("{pageInfo:regex(^page\\d+$)?}")]
        [HttpGet("{categoryNormalizedName}/{pageInfo:regex(^page\\d+$)?}")]
        [HttpGet("{categoryNormalizedName:regex(^(?!page\\d+$).*)}")]
        public async Task<ActionResult<ResponseData<List<AutoPart>>>> GetAutoPart(string? categoryNormalizedName,
            string? pageInfo = null, int pageSize = 3)
        {
            var pageNo = !string.IsNullOrEmpty(pageInfo) ? int.Parse(pageInfo?[4..] ?? "1") : 1;
            return Ok(await _autoPartService.GetProductListAsync(categoryNormalizedName, pageNo, pageSize));
        }

        // GET: api/AutoParts/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AutoPart>> GetAutoPart(int id)
        {
          if (_context.AutoPart == null)
          {
              return NotFound();
          }
            var autoPart = await _context.AutoPart.FindAsync(id);

            if (autoPart == null)
            {
                return NotFound();
            }

            return autoPart;
        }

        // PUT: api/AutoParts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAutoPart(int id, AutoPart autoPart)
        {
            if (id != autoPart.Id)
            {
                return BadRequest();
            }

            _context.Entry(autoPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoPartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AutoParts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AutoPart>> PostAutoPart(AutoPart autoPart)
        {
          if (_context.AutoPart == null)
          {
              return Problem("Entity set 'AppDbContext.AutoPart'  is null.");
          }
            _context.AutoPart.Add(autoPart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutoPart", new { id = autoPart.Id }, autoPart);
        }

        // DELETE: api/AutoParts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutoPart(int id)
        {
            if (_context.AutoPart == null)
            {
                return NotFound();
            }
            var autoPart = await _context.AutoPart.FindAsync(id);
            if (autoPart == null)
            {
                return NotFound();
            }

            _context.AutoPart.Remove(autoPart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutoPartExists(int id)
        {
            return (_context.AutoPart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
