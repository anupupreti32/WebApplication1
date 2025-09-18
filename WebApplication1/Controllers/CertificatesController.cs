using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOS.Certificate;
using WebApplication1.Models;

namespace WebApplication1.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public CertificatesController(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Certificate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificateReadDTO>>> GetCertificate()
        {
            var certificate = await _context.Certificate.ToListAsync();
            var certificateReadDto = _mapper.Map<List<CertificateReadDTO>>(certificate);


            return Ok(certificateReadDto);
        }

        // GET: api/Certificate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificateReadDTO>> GetCertificate(int id)
        {
            
            var certificate = await _context.Certificate.FindAsync(id);
            var  certificateReadDto = _mapper.Map<CertificateReadDTO>(certificate);

            if (certificate == null)
            {
                return NotFound();
            }

            return Ok(certificateReadDto);
        }

        // PUT: api/Certificate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificate(int id, CertificateUpdateDTO certificateUpdateDto)
        {
            var certificate = _mapper.Map<Certificate>(certificateUpdateDto);
            
            if (id != certificate.CertificateId)
            {
                return BadRequest();
            }

            _context.Entry(certificate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(certificateUpdateDto);
        }

        // POST: api/Certificate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificateCreateDTO>> PostCertificate(CertificateCreateDTO certificateCreateDto)
        {
            var certificate = _mapper.Map<Certificate>(certificateCreateDto);
            _context.Certificate.Add(certificate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCertificate", new { id = certificateCreateDto.CertificateId }, certificateCreateDto);
        }

        // DELETE: api/Certificate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            var certificate = await _context.Certificate.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }

            _context.Certificate.Remove(certificate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificateExists(int id)
        {
            return _context.Certificate.Any(e => e.CertificateId == id);
        }
    }
}
