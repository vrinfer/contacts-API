using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Application.Contacts.Queries.GetContactByEmail
{
    public class GetContactByEmailQuery : ContactsQueriesBase, IGetContactByEmailQuery
    {
        private readonly IContacDbContext _contactDbContext;

        public GetContactByEmailQuery(IContacDbContext contactDbContext, IMapper mapper) : base (mapper)
        {
            _contactDbContext = contactDbContext;
        }

        public Response<List<ContactModel>> Execute(string email)
        {
            try
            {
                var contacts = _contactDbContext.Contacts
                    .Where(x => x.ContactInformation.Email == email)
                    .Include(c => c.ContactInformation);

                return new Response<List<ContactModel>>
                {
                    Data = _mapper.Map<List<ContactModel>>(contacts),
                    HttpStatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<ContactModel>>
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
