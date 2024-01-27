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
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionServices _prescriptionServices;
        private readonly IMapper _mapper;

        public PrescriptionController(IPrescriptionServices prescriptionServices,IMapper mapper)
        {
            _prescriptionServices = prescriptionServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<PrescriptionToReturnDto>>> GetAllPrescriptions(string patientId)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ApiResponse(400));
            var prescriptions = await _prescriptionServices.GetAllPrescriptionsForPatient(patientId);
            if(prescriptions is null)
                return NotFound(new ApiResponse(404));
            var prescriptionMapped = _mapper.Map<List<PrescriptionToReturnDto>>(prescriptions);
            return Ok(prescriptionMapped);
        }
        [HttpGet("details")]
        public async Task<ActionResult<PrescriptionToReturnDto>> GetPrescription(string patientId,int doctorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(400));
            var prescriptions = await _prescriptionServices.GetPrescription(patientId,doctorId);
            if (prescriptions is null)
                return NotFound(new ApiResponse(404));
            var prescriptionMapped = _mapper.Map<PrescriptionToReturnDto>(prescriptions);
            return Ok(prescriptionMapped);
        }
    }
}
