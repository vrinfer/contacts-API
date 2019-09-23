namespace Application.Contacts.Commands
{
    public interface IUpdateContactCommand
    {
        Response<int> Execute(int contactId, ContactModel contactModel);
    }
}
