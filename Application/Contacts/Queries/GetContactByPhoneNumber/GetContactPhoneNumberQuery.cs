using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Application.Contacts.Queries.GetContactByPhoneNumber
{
    public class GetContactByPhoneNumberQuery : ContactsQueriesBase, IGetContactByPhoneNumberQuery
    {
        private readonly IContacDbContext _contactDbContext;

        public GetContactByPhoneNumberQuery(IContacDbContext contactDbContext, IMapper mapper) : base(mapper)
        {
            _contactDbContext = contactDbContext;
        }

        public Response<List<ContactModel>> Execute(string phoneNumber)
        {
            try
            {
                var contacts = _contactDbContext.Contacts
                    .Where(x => x.ContactInformation.PersonalPhoneNumber == phoneNumber || x.ContactInformation.CompanyPhoneNumber == phoneNumber)
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
