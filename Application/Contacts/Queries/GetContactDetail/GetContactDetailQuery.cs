using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;

namespace Application.Contacts.Queries.GetContactDetail
{
    public class GetContactDetailQuery : ContactsQueriesBase, IGetContactDetailQuery
    {
        private readonly IContacDbContext _contactDbContext;

        public GetContactDetailQuery(IContacDbContext database, IMapper mapper) :base(mapper)
        {
            _contactDbContext = database;
        }

        public Response<ContactModel> Execute(int contactId)
        {
            try
            {
                var contact = _contactDbContext.Contacts
                    .Include(c => c.ContactInformation)
                    .SingleOrDefault(x => x.Id == contactId);

                return new Response<ContactModel>
                {
                    Data = _mapper.Map<ContactModel>(contact),
                    HttpStatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<ContactModel>
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
