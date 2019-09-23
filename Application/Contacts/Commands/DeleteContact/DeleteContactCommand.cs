using Application.Interfaces;
using System;
using System.Linq;
using System.Net;

namespace Application.Contacts.Commands.DeleteContact
{

    public class DeleteContactCommand : IDeleteContactCommand
    {
        private readonly IContacDbContext _contactDbContext;

        public DeleteContactCommand(IContacDbContext contactDbContext)
        {
            _contactDbContext = contactDbContext;
        }

        public Response<bool> Execute(int contactId)
        {
            var contact = _contactDbContext.Contacts.SingleOrDefault(x => x.Id == contactId);

            if (contact == null)
            {
                return new Response<bool>
                {
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }

            try
            {
                _contactDbContext.Contacts.Remove(contact);
                _contactDbContext.Save();
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError
                };
            }

            return new Response<bool>
            {
                Data = true,
                HttpStatusCode = HttpStatusCode.Created
            };
        }
    }
}
