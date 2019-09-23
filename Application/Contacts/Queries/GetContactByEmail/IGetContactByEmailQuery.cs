using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contacts.Queries.GetContactByEmail
{
    public interface IGetContactByEmailQuery
    {
        Response<List<ContactModel>> Execute(string email);
    }
}
