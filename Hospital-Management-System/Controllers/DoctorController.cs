using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Erorrs;
using Hospital_ManagementSystem.Core.Entity.PatientModule;
using Hospital_ManagementSystem.Core.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServices _doctorServices;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorServices doctorServices,IMapper mapper)
        {
            _doctorServices = doctorServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<DoctorToReturnDto>>> GetDoctors()
        {
            var doctors = await _doctorServices.GetDoctorsAsync();
            if (doctors is null)
                return NotFound(new ApiResponse(404));
            var doctorsMap=_mapper.Map<List<DoctorToReturnDto>>(doctors);
            return Ok(doctorsMap);
        }
        [HttpGet("doctorSchedule")]
        public async Task<ActionResult<List<DoctorScheduleDto>>> GetDoctorSchedule(int doctorId)
        {
            if(!ModelState.IsValid) 
                return BadRequest(new ApiResponse(400));
            var doctorSchedule = await _doctorServices.GetDoctorSchedulesAsync(doctorId);
            if (doctorSchedule is null)
                return NotFound(new ApiResponse(404));
            var doctorScheduleMapped = _mapper.Map<List<DoctorSchedule>,List<DoctorScheduleDto>>(doctorSchedule);
            return Ok(doctorScheduleMapped);
        }
    }
}
