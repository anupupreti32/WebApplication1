using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOS.Reference;
using WebApplication1.Models;
using WebApplication1.Repositories.GenericRepositories;
using WebApplication1.Repositories.SpecificRepositories.ReferenceRepositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferencesController : ControllerBase
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories _genericRepositories;
        private readonly IReferenceRepositories _ReferenceRepositories;
        public ReferencesController(PortfolioContext context, IMapper mapper, IGenericRepositories genericRepositories, IReferenceRepositories ReferenceRepositories)
        {
            _context = context;
            _mapper = mapper;
            _genericRepositories = genericRepositories;
            _ReferenceRepositories = ReferenceRepositories;
        }

        // GET: api/References
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reference>>> GetReference()
        {
            var reference = await _context.Reference.ToListAsync();
            var referenceReadDTO = _mapper.Map<List<ReferenceReadDTO>>(reference);
            return Ok(referenceReadDTO);
            //return await _context.Reference.ToListAsync();
        }

        // GET: api/References/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferenceReadDTO>> GetReference(int id)
        {
            //var reference = await _context.Reference.FindAsync(id);
            var reference = await _genericRepositories.GetbyID<Reference>(id);
            var referenceReadDTO = _mapper.Map<ReferenceReadDTO>(reference);    

            if (reference == null)
            {
                return NotFound();
            }
            return Ok(referenceReadDTO);
        }
        // GET: api/References/5
        [HttpGet]
        [Route("~/api/references/referenceName/{referenceName}")]
        public async Task<ActionResult<ReferenceReadDTO>> GetReference(string referenceName)
        {
            //var reference = await _context.Reference.FindAsync(id);
            var reference = await _ReferenceRepositories.GetReferenceName(referenceName);
            var referenceReadDTO = _mapper.Map<ReferenceReadDTO>(reference);

            if (reference == null)
            {
                return NotFound();
            }
            return Ok(referenceReadDTO);
        }

        // PUT: api/References/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReference(int id, ReferenceUpdateDTO referenceUpdateDTO)
        {
            var reference = _mapper.Map<Models.Reference>(referenceUpdateDTO);
            if (id != reference.ReferenceId)
            {
                return BadRequest();
            }

            _context.Entry(reference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferenceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(referenceUpdateDTO);
        }

        // POST: api/References
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reference>> PostReference(ReferenceCreateDTO referenceCreateDTO)
        {
            var reference = _mapper.Map<Models.Reference>(referenceCreateDTO);
            _context.Reference.Add(reference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReference", new { id = referenceCreateDTO.ReferenceId }, referenceCreateDTO);

        }

        // DELETE: api/References/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReference(int id)
        {
            var reference = await _context.Reference.FindAsync(id);
            if (reference == null)
            {
                return NotFound();
            }

            _context.Reference.Remove(reference);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReferenceExists(int id)
        {
            return _context.Reference.Any(e => e.ReferenceId == id);
        }
    }
}
