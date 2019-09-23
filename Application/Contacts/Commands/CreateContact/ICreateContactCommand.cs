namespace Application.Contacts.Commands.CreateContact
{
    public interface ICreateContactCommand
    {
        Response<int> Execute(ContactModel model);
    }
}
