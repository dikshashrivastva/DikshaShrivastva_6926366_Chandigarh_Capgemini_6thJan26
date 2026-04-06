using AutoMapper;
using HospitalAPI.DTOs;
using HospitalAPI.Models;

namespace HospitalAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mappings
            CreateMap<User, UserResponseDTO>();
            CreateMap<RegisterDTO, User>();

            // Department Mappings
            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.DoctorCount,
                    opt => opt.MapFrom(src => src.Doctors.Count));
            CreateMap<CreateDepartmentDTO, Department>();

            // Doctor Mappings
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.User != null ? src.User.FullName : ""))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.User != null ? src.User.Email : ""))
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : ""));
            CreateMap<CreateDoctorDTO, Doctor>();

            // Appointment Mappings
            CreateMap<Appointment, AppointmentDTO>()
                .ForMember(dest => dest.PatientName,
                    opt => opt.MapFrom(src => src.Patient != null ? src.Patient.FullName : ""))
                .ForMember(dest => dest.DoctorName,
                    opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : ""))
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.Department != null ? src.Doctor.Department.DepartmentName : ""));
            CreateMap<CreateAppointmentDTO, Appointment>();

            // Prescription Mappings
            CreateMap<Prescription, PrescriptionDTO>()
                .ForMember(dest => dest.PatientName,
                    opt => opt.MapFrom(src => src.Appointment != null && src.Appointment.Patient != null ? src.Appointment.Patient.FullName : ""))
                .ForMember(dest => dest.DoctorName,
                    opt => opt.MapFrom(src => src.Appointment != null && src.Appointment.Doctor != null && src.Appointment.Doctor.User != null ? src.Appointment.Doctor.User.FullName : ""));
            CreateMap<CreatePrescriptionDTO, Prescription>();

            // Bill Mappings
            CreateMap<Bill, BillDTO>()
                .ForMember(dest => dest.TotalAmount,
                    opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.PatientName,
                    opt => opt.MapFrom(src => src.Appointment != null && src.Appointment.Patient != null ? src.Appointment.Patient.FullName : ""))
                .ForMember(dest => dest.DoctorName,
                    opt => opt.MapFrom(src => src.Appointment != null && src.Appointment.Doctor != null && src.Appointment.Doctor.User != null ? src.Appointment.Doctor.User.FullName : ""));
            CreateMap<CreateBillDTO, Bill>();
        }
    }
}