



using Hairdresser.Context;

using Hairdresser.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceApiController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/ServiceApi
        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var services = await _context.services.ToListAsync();
            return Ok(services);
        }

        // GET: api/ServiceApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var services = await _context.services.FindAsync(id);
            if (services == null) return NotFound();
            return Ok(services);
        }

        // POST: api/ServiceApi
        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] Service service)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.services.Add(service);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetService), new { id = service.salonID }, service);
        }


        // PUT: api/ServiceApi/4
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] Service updatedService)
        {
            if (id != updatedService.serviceID) return BadRequest();

            var service = await _context.services.FindAsync(id);
            if (service == null) return NotFound();

            service.serviceName = updatedService.serviceName;
            service.serviceDuration = updatedService.serviceDuration;
            service.servicePrice = updatedService.servicePrice;
            service.salonID = 1;

            _context.services.Update(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/ServiceApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.services.FindAsync(id);
            if (service == null) return NotFound();

            _context.services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}