namespace Application.Contacts.Commands.DeleteContact
{
    public interface IDeleteContactCommand
    {
        Response<bool> Execute(int contactId);
    }
}
