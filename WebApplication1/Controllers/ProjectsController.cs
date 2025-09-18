using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOS.Project;
using WebApplication1.Models;

namespace WebApplication1.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;
        public ProjectsController(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Ptojects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectReadDTO>>> GetProject()
        {
            var project = await _context.Project.ToListAsync();
            var projectReadDto = _mapper.Map<List<ProjectReadDTO>>(project);
            
            return Ok(projectReadDto);
        }

        // GET: api/Ptojects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectReadDTO>> GetProject(int id)
        {
            var project = await _context.Project.FindAsync(id);
            var projectReadDto = _mapper.Map<ProjectReadDTO>(project);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(projectReadDto);
        }

        // PUT: api/Ptojects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectUpdateDTO projectUpdateDto)
        {
            var project = _mapper.Map<Project>(projectUpdateDto) ;
            
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(projectUpdateDto);
        }

        // POST: api/Ptojects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectCreateDTO>> PostProject(ProjectCreateDTO projectCreateDto)
        {
            var project = _mapper.Map<Project>(projectCreateDto);
            _context.Project.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = projectCreateDto.ProjectId }, projectCreateDto);
        }

        // DELETE: api/Ptojects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Project.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectId == id);
        }
    }
}
