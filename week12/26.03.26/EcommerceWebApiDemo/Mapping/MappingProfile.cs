using AutoMapper;
using EcommerceWebApiDemo.DTOs;
using EcommerceWebApiDemo.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace EcommerceWebApiDemo.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserDTO>();
			CreateMap<RegisterDTO, User>();
		}

	}
}
