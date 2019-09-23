using System.Collections.Generic;

namespace Application.Contacts.Queries.GetAllContactsByCity
{
    public interface IGetAllContactsByCityQuery
    {
        Response<List<ContactModel>> Execute(string city);
    }
}
