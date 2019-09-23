using Application.Contacts;
using AutoMapper;
using Domain;

namespace Application.AutoMapper
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<ContactModel, Contact>()
                .ForMember(x => x.Id, y => y.Ignore());

            CreateMap<ContactInformationModel, ContactInformation>()
                 .ForMember(x => x.Id, y => y.Ignore());

            CreateMap<Contact, ContactModel>();
            CreateMap<ContactInformation, ContactInformationModel>();
        }
    }
}
