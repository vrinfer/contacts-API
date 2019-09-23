using Newtonsoft.Json;

namespace Application.Contacts
{
    public class ContactRequest : ContactModel
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
