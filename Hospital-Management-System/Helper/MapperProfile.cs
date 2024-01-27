using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Entity.PatientModule;
using Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities;

namespace Hospital_Management_System.Helper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Record, RecordDto>().ForMember(d => d.FristName,o => o.MapFrom(s => s.Patient.FristName))
                .ForMember(d => d.LastName,o => o.MapFrom(s => s.Patient.LastName))
                .ForMember(d => d.Email,o => o.MapFrom(s => s.Patient.Email))
                .ForMember(d => d.SurgicalHistories,o => o.MapFrom(s => s.MedicalHistory.SurgicalHistories))
                .ForMember(d => d.Past_Illnesses,o => o.MapFrom(s => s.MedicalHistory.Past_Illnesses))
                .ForMember(d => d.VitalSigns,o => o.MapFrom(s => s.MedicalHistory.VitalSigns));
            CreateMap<SurgicalHistory, surgicalHistoriesDto>();
            CreateMap<Past_illnesses, past_IllnessesDto>();
            CreateMap<VitalSigns,vitalSignsDto>();
            CreateMap<Doctor, DoctorToReturnDto>();
            CreateMap<Patient, PatientInfoDto>().ReverseMap();
            CreateMap<DoctorSchedule, DoctorScheduleDto>()
               .ForMember(d => d.DoctorName, o => o.MapFrom(s => s.Doctor.FullName))
               .ForMember(d => d.DoctorSpecialization, o => o.MapFrom(s => s.Doctor.Specialization));
            CreateMap< AppointmentRequestDto,Appointment>();
            CreateMap<Appointment, AppointmentReturnDto>()
               .ForMember(d => d.DoctorName, o => o.MapFrom(s => s.Doctor.FullName))
               .ForMember(d => d.DoctorSpecialization, o => o.MapFrom(s => s.Doctor.Specialization))
               .ForMember(d => d.AppointmentId,o => o.MapFrom(s => s.Id));
        }
    }
}
