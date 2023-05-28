using AutoMapper;
using Entities;
using Models;

namespace Create_Form.Mapping
{
	public class PersonProfile : Profile
	{
		public PersonProfile()
		{
			CreateMap<Person, PersonViewModel>().ReverseMap();

		}
	}
}
