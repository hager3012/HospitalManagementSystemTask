using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Erorrs;
using Hospital_ManagementSystem.Core.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IPatientServices _patientServices;
        private readonly IMapper _mapper;

        public DoctorController(IPatientServices patientServices,IMapper mapper)
        {
            _patientServices = patientServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<DoctorToReturnDto>>> GetDoctors()
        {
            var doctors = await _patientServices.GetDoctorsAsync();
            if (doctors is null)
                return NotFound(new ApiResponse(404));
            var doctorsMap=_mapper.Map<List<DoctorToReturnDto>>(doctors);
            return Ok(doctorsMap);
        }
    }
}
