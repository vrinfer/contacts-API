namespace Application.Contacts.Queries.GetContactDetail
{
    public interface IGetContactDetailQuery
    {
        Response<ContactModel> Execute(int contactId);
    }
}
