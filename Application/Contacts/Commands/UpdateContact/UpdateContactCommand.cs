using Application.Interfaces;
using AutoMapper;
using System;
using System.Linq;
using System.Net;

namespace Application.Contacts.Commands
{

    public class UpdateContactCommand : IUpdateContactCommand
    {
        private readonly IContacDbContext _contactDbContext;
        private readonly IMapper _mapper;

        public UpdateContactCommand(IContacDbContext contactDbContext, IMapper mapper)
        {
            _contactDbContext = contactDbContext;
            _mapper = mapper;
        }

        public Response<int> Execute(int contactId, ContactModel contactModel)
        {
            var contact = _contactDbContext.Contacts.SingleOrDefault(x => x.Id == contactId);

            if (contact == null)
            {
                return new Response<int>
                {
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }

            try
            {
                _mapper.Map(contactModel, contact);

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
                HttpStatusCode = HttpStatusCode.OK
            };
        }
    }
}
