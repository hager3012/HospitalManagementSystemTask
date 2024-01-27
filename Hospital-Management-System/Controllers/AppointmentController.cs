using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Erorrs;
using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Entity.PatientModule;
using Hospital_ManagementSystem.Core.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentServices _appointmentServices;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentServices appointmentServices,IMapper mapper)
        {
            _appointmentServices = appointmentServices;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> BookAppointment(string patientId , AppointmentRequestDto appointmentRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new ApiValidationResponse(400) { Errors = errors });
            }
            appointmentRequest.PatientId= patientId;
            var appoinment = _mapper.Map<AppointmentRequestDto,Appointment>(appointmentRequest);
            var bookAppointment = await _appointmentServices.BookAppointment(patientId, appoinment);
            return bookAppointment switch
            {
                0 => BadRequest(new ApiResponse(400)),
                -1 => BadRequest(new ApiResponse(400,"This patient has appointment in this date and time")),
                1 => Ok()
            } ;    
        }
        [HttpGet]
        public async Task<ActionResult<List<AppointmentReturnDto>>> GetAppointments(string patientId)
        {
            if (string.IsNullOrEmpty(patientId))
                return BadRequest(new ApiResponse(400));
            var appointments = await _appointmentServices.GetAppointments(patientId);
            if(appointments.Count==0)
                return NotFound(new ApiResponse(404));
            var appointmentMapped = _mapper.Map<List<AppointmentReturnDto>>(appointments);
            return appointmentMapped;
        }
        [HttpDelete]
        public async Task<ActionResult> CancelAppointment(int appointmentId)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ApiResponse(400));
            var appointmentCancel = await _appointmentServices.CancelAppointment(appointmentId);
            if(appointmentCancel<=0)
                return BadRequest(new ApiResponse(400));
            return Ok();
        }
    }
}
