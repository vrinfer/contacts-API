using System.Collections.Generic;

namespace Application.Contacts.Queries.GetContactByPhoneNumber
{
    public interface IGetContactByPhoneNumberQuery
    {
        Response<List<ContactModel>> Execute(string phoneNumber);
    }
}
