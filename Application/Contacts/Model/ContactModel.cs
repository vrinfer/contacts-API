using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Contacts
{

    public class ContactModel
    {
        public virtual int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Company { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public ContactInformationModel ContactInformation { get; set; }
    }
}
