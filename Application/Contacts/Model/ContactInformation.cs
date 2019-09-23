using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Application.Contacts
{
    public class ContactInformationModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string PersonalPhoneNumber { get; set; }
     
        public string CompanyPhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
