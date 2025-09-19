using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOS.Skill;
using WebApplication1.Models;
using WebApplication1.Repositories.GenericRepositories;
using WebApplication1.Repositories.SpecificRepositories.SkillSpecificRepositories;

namespace WebApplication1.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly PortfolioContext _context;
        private readonly IGenericRepositories _genericRepositories;
        private readonly IMapper _mapper;
        private readonly ISkillSpecificRepositories _skillSpecificRepositories;

        public SkillsController(PortfolioContext context, IMapper mapper, IGenericRepositories genericRepositories,
            ISkillSpecificRepositories skillSpecificRepositories)
        {
            _context = context;
            _mapper = mapper;
            _genericRepositories = genericRepositories;
            _skillSpecificRepositories = skillSpecificRepositories;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillReadDTO>>> GetSkill()
        {
            var skill = await _context.Skill.ToListAsync();
            var skillReadDto = _mapper.Map<List<SkillReadDTO>>(skill);

            return Ok(skillReadDto);
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillReadDTO>> GetSkill(int id)
        {
            var skill = await _genericRepositories.GetbyID<Skill>(id);
            var skillReadDto = _mapper.Map<SkillReadDTO>(skill);

            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skillReadDto);
        }

        // GET: api/Skills/5
        [HttpGet]
        [Route("~/api/skills/skillName/{skillName}")]
        public async Task<ActionResult<SkillReadDTO>> GetSkillName(string skillName)
        {
            var skill = await _skillSpecificRepositories.GetSkillName(skillName);
            var skillReadDto = _mapper.Map<SkillReadDTO>(skill);

            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skillReadDto);
        }

        // PUT: api/Skills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, SkillUpdateDTO skillUpdateDto)
        {
            var skill = _mapper.Map<Skill>(skillUpdateDto);
            if (id != skill.SkillId)
            {
                return BadRequest();
            }

            _context.Entry(skill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(skillUpdateDto);
        }

        // POST: api/Skills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(SkillCreateDTO skillCreateDto)
        {
            var skill = _mapper.Map<Skill>(skillCreateDto);
            _context.Skill.Add(skill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkill", new { id = skillCreateDto.SkillId }, skillCreateDto);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _context.Skill.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skill.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillExists(int id)
        {
            return _context.Skill.Any(e => e.SkillId == id);
        }
    }
}
