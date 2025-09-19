using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOS.Profile;
using WebApplication1.Models;
using Profile = WebApplication1.Models.Profile;

namespace WebApplication1.controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public ProfilesController(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileReadDTO>>> GetProfiles()
        {
            var profile = await _context.Profile.ToListAsync();
            var profileReadDto = _mapper.Map<List<ProfileReadDTO>>(profile);
            return Ok(profileReadDto);
        }

        // GET: api/Profiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileReadDTO>> GetProfile(int id)
        {
            var profile = await _context.Profile.FindAsync(id);
            var profileReadDto = _mapper.Map<ProfileReadDTO>(profile);
            
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profileReadDto);
        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, ProfileUpdateDTO profileUpdateDto)
        {
            
            var profile = _mapper.Map<Profile>(profileUpdateDto);
            
            if (id != profile.ProfileId)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(profileUpdateDto);
        }

        // POST: api/Profiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostProfile(ProfileCreateDTO profileCreateDto)
        {
            var profile = _mapper.Map<Models.Profile>(profileCreateDto);
            
            _context.Profile.Add(profile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfileExists(profile.ProfileId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfile", new { id = profileCreateDto.ProfileId }, profileCreateDto);
            //return Ok(profileCreateDto);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _context.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.Profile.Remove(profile);
            //profile.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(int id)
        {
            return _context.Profile.Any(e => e.ProfileId == id);
        }
    }
}
