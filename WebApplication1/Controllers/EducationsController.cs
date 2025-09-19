using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOS.Education;
using WebApplication1.Models;
using WebApplication1.Repositories.GenericRepositories;
using WebApplication1.Repositories.SpecificRepositories.EducationRepositories;

namespace WebApplication1.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly PortfolioContext _context;
        private readonly IGenericRepositories _genericRepositories;
        private readonly IEducationRepositories _educationRepositories;
        private readonly IMapper _mapper;

        public EducationsController(PortfolioContext context, IMapper mapper, IGenericRepositories genericRepositories, IEducationRepositories educationRepositories
            )
        {
            _context = context;
            _mapper = mapper;
            _genericRepositories = genericRepositories;
            _educationRepositories = educationRepositories;
        }

        // GET: api/Education
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationReadDTO>>> GetEducation()
        {
            
            var education = await _context.Education.ToListAsync();
            var educationReadDto = _mapper.Map<List<EducationReadDTO>>(education);

            return Ok(educationReadDto);
        }

        // GET: api/Education/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationReadDTO>> GetEducation(int id)
        {
            var education = await _genericRepositories.GetbyID<Education>(id);
            var educationReadDto = _mapper.Map<EducationReadDTO>(education);

            if (education == null)
            {
                return NotFound();
            }

            return Ok(educationReadDto);
        }

        // GET: [/Education/5
        [HttpGet]
        [Route("~/api/eucation/instutionName/{InstutionName}")]
        public async Task<ActionResult<EducationReadDTO>> GetEducation(string InstutionName)
        {
            var education = await _educationRepositories.GetInstututionName(InstutionName);

            var educationReadDto = _mapper.Map<EducationReadDTO>(education);

            if (education == null)
            {
                return NotFound();
            }

            return Ok(educationReadDto);
        }

        // PUT: api/Education/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation(int id, EducationUpdateDTO educationUpdateDto)
        {
            var education = _mapper.Map<Education>(educationUpdateDto);
            if (id != education.EducationId)
            {
                return BadRequest();
            }

            _context.Entry(education).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(educationUpdateDto);
        }

        // POST: api/Education
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EducationCreateDTO>> PostEducation(EducationCreateDTO educationCreateDto)
        {
            var education = _mapper.Map<Education>(educationCreateDto);
            _context.Education.Add(education);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducation", new { id = educationCreateDto.EducationId }, educationCreateDto);
        }

        // DELETE: api/Education/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var education = await _context.Education.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            _context.Education.Remove(education);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducationExists(int id)
        {
            return _context.Education.Any(e => e.EducationId == id);
        }
    }
}
