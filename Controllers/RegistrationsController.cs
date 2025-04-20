using Microsoft.AspNetCore.Mvc;
using StudentRegistrations.Services;
using StudentRegistrations.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentRegistrations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase 
    { 
        private readonly RegistrationService _registrationService;
        public RegistrationsController(RegistrationService registrationService) { 
         _registrationService = registrationService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var result = await _registrationService.allReg();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getById(Guid id)
        {
            var registration = await _registrationService.getRegById(id);
            if (registration == null)
            { return NotFound("Registration not found"); }
           
            return Ok(registration);

        }
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(Guid studentId, Guid courseId)
        {
            var result = await _registrationService.registerStudent(studentId, courseId);
            return Ok(result);
        }
        [HttpPut]  
        public async Task<IActionResult> UpdateReg(Guid id,Guid courseId,Guid studentId)
        {
            var result = await _registrationService.updateReg(id, courseId,studentId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteRg(Guid id)
        {
            var result = await _registrationService.deleteReg(id);
           if(result == null)
            {
                return NotFound("Registration not found");
            }
            return Ok(result);
        }

    }
}
