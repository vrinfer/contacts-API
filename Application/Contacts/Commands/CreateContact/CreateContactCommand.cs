using Application.Interfaces;
using AutoMapper;
using Domain;
using System;
using System.Net;

namespace Application.Contacts.Commands.CreateContact
{

    public class CreateContactCommand : ICreateContactCommand
    {
        private readonly IContacDbContext _contactDbContext;
        private readonly IMapper _mapper;

        public CreateContactCommand(IContacDbContext contactDbContext, IMapper mapper)
        {
            _contactDbContext = contactDbContext;
            _mapper = mapper;
        }

        public Response<int> Execute(ContactModel model)
        {
            var contact = _mapper.Map<Contact>(model);

            try
            {
                _contactDbContext.Contacts.Add(contact);
                _contactDbContext.Save();
            }
            catch (Exception ex)
            {
                return new Response<int>
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError
                };
            }

            return new Response<int>
            {
                Data = contact.Id,
                HttpStatusCode = HttpStatusCode.Created
            };
        }
    }
}
