using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Application.Contacts.Queries.GetAllContactsByCity
{

    public class GetAllContactsByCityQuery : ContactsQueriesBase, IGetAllContactsByCityQuery
    {
        private readonly IContacDbContext _contactDbContext;

        public GetAllContactsByCityQuery(IContacDbContext contactDbContext, IMapper mapper)
            :base (mapper)
        {
            _contactDbContext = contactDbContext;
        }

        public Response<List<ContactModel>> Execute(string city)
        {
            var contactsResult = new List<ContactModel>();
            try
            {
                 var contacts = _contactDbContext.Contacts
                .Where(x => x.City == city)
                .Include(c => c.ContactInformation); ;

                contactsResult = _mapper.Map<List<ContactModel>>(contacts);
            }
            catch (Exception ex)
            {
                return new Response<List<ContactModel>>
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError
                };
            }

            return new Response<List<ContactModel>>
            {
                Data = contactsResult,
                HttpStatusCode = HttpStatusCode.OK
            };
        }
    }
}
