using System.Collections.Generic;

namespace Application.Contacts.Queries.GetAllContactsByCity
{
    public interface IGetAllContactsByStateQuery
    {
        Response<List<ContactModel>> Execute(string state);
    }
}
