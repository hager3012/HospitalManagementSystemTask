using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Erorrs;
using Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities;
using Hospital_ManagementSystem.Core.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordServices _recordServices;
        private readonly IMapper _mapper;

        public RecordController(IRecordServices recordServices,IMapper mapper)
        {
            _recordServices = recordServices;
            _mapper = mapper;
        }
        [HttpGet("{patientId}")]
        public async Task<ActionResult<RecordDto>> ViewRecord(string patientId)
        {
            if (string.IsNullOrEmpty(patientId))
                return BadRequest(new ApiResponse(400));
            var record = await _recordServices.ViewRecord(patientId);
            if (record is null)
                return NotFound(new ApiResponse(404));
            var recordMapping=_mapper.Map<RecordDto>(record);
            return Ok(recordMapping);
        }
    }
}
