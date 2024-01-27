using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Erorrs;
using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _patientServices;
        private readonly IMapper _mapper;

        public PatientController(IPatientServices patientServices,IMapper mapper)
        {
            _patientServices = patientServices;
            _mapper = mapper;
        }
        [HttpGet("{patientId}")]
        public async Task<ActionResult<PatientInfoDto>> GetPatientInfo(string patientId)
        {
            if (string.IsNullOrWhiteSpace(patientId))
                return BadRequest(new ApiResponse(400));
            var patient = await _patientServices.GetPatientInfoAsync(patientId);
            if (patient is null)
                return NotFound(new ApiResponse(404));
            var patientMapp = _mapper.Map<PatientInfoDto>(patient);
            return Ok(patientMapp);
        }
        [HttpPut("{patientId}")]
        public async Task<ActionResult> updatePatientInfo(string patientId,PatientInfoDto patientInfoDto)
        {
            if(string.IsNullOrWhiteSpace(patientId))
                return BadRequest(new ApiResponse(400));
            var patientMapped = _mapper.Map<Patient>(patientInfoDto);

            var patientUpdated = await _patientServices.UpdatePatientInfoAsync(patientId, patientMapped);
            if(patientUpdated <=0)
                return BadRequest(new ApiResponse(400));
            return Ok();
        }
    }
}
