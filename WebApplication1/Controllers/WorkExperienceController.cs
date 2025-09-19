using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOS.WorkExperience;
using WebApplication1.Models;

namespace WebApplication1.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : ControllerBase
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public WorkExperienceController(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/WorkExperience
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkExperienceReadDTO>>> GetWorkExperiences()
        {
            var workExperience= await _context.WorkExperience.ToListAsync();
            var workExperienceReadDto = _mapper.Map<List<WorkExperienceReadDTO>>(workExperience);
            
            return Ok(workExperienceReadDto);
        }

        // GET: api/WorkExperience/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkExperienceReadDTO>> GetWorkExperience(int id)
        {
            var workExperience = await _context.WorkExperience.FindAsync(id);
            var workExperienceReadDto = _mapper.Map<WorkExperienceReadDTO>(workExperience);
            if (workExperience == null)
            {
                return NotFound();
            }

            return Ok(workExperienceReadDto);
        }

        // PUT: api/WorkExperience/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkExperience(int id, WorkExperienceUpdateDTO workExperienceUpdateDto)
        {
            var workExperience = _mapper.Map<WorkExperience>(workExperienceUpdateDto);
            if (id != workExperience.WorkExperienceId)
            {
                return BadRequest();
            }

            _context.Entry(workExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExperienceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(workExperienceUpdateDto);
        }

        // POST: api/WorkExperience
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkExperienceCreateDTO>> PostWorkExperience(WorkExperienceCreateDTO workExperienceCreateDto)
        {
            var workExperience = _mapper.Map<WorkExperience>(workExperienceCreateDto);

            _context.WorkExperience.Add(workExperience);
            await _context.SaveChangesAsync();

            return Ok(workExperience);
        }

        // DELETE: api/WorkExperience/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkExperience(int id)
        {
            var workExperience = await _context.WorkExperience.FindAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }

            _context.WorkExperience.Remove(workExperience);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperience.Any(e => e.WorkExperienceId == id);
        }
    }
}
