using Application.Contacts;
using Application.Contacts.Commands;
using Application.Contacts.Commands.CreateContact;
using Application.Contacts.Commands.DeleteContact;
using Application.Contacts.Queries.GetAllContactsByCity;
using Application.Contacts.Queries.GetContactByEmail;
using Application.Contacts.Queries.GetContactByPhoneNumber;
using Application.Contacts.Queries.GetContactDetail;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace ContactsAPI.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        
        private readonly ICreateContactCommand _createContactCommand;
        private readonly IUpdateContactCommand _updateContactCommand;
        private readonly IDeleteContactCommand _deleteContactCommand;
        private readonly IGetAllContactsByCityQuery _getAllContactsByCity;
        private readonly IGetAllContactsByStateQuery _getAllContactsByStateQuery;
        private readonly IGetContactByEmailQuery _getContactByEmailQuery;
        private readonly IGetContactByPhoneNumberQuery _getContactByPhoneNumberQuery;
        private readonly IGetContactDetailQuery _getContactDetailQuery;

        public ContactsController(ICreateContactCommand createContactCommand, 
                                  IUpdateContactCommand updateContactCommand, 
                                  IDeleteContactCommand deleteContactCommand, 
                                  IGetAllContactsByCityQuery getAllContactsByCity, 
                                  IGetAllContactsByStateQuery getAllContactsByStateQuery, 
                                  IGetContactByEmailQuery getContactByEmailQuery, 
                                  IGetContactByPhoneNumberQuery getContactByPhoneNumberQuery, 
                                  IGetContactDetailQuery getContactDetailQuery)
        {
            _createContactCommand = createContactCommand;
            _updateContactCommand = updateContactCommand;
            _deleteContactCommand = deleteContactCommand;
            _getAllContactsByCity = getAllContactsByCity;
            _getAllContactsByStateQuery = getAllContactsByStateQuery;
            _getContactByEmailQuery = getContactByEmailQuery;
            _getContactByPhoneNumberQuery = getContactByPhoneNumberQuery;
            _getContactDetailQuery = getContactDetailQuery;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _getContactDetailQuery.Execute(id);

            return CreateResult(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContactModel contact)
        {
            var response = _createContactCommand.Execute(contact);

            return CreateResult(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ContactModel contact)
        {
            var response = _updateContactCommand.Execute(id, contact);

            return CreateResult(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _deleteContactCommand.Execute(id);

            return CreateResult(response);
        }

        [HttpGet("phoneNumber/{phoneNumber}")]
        public IActionResult GetByPhoneNumber([FromRoute] string phoneNumber)
        {
            var response = _getContactByPhoneNumberQuery.Execute(phoneNumber);

            return CreateResult(response);
        }

        [HttpGet("email/{email}")]
        public IActionResult GetByEmail([FromRoute]string email)
        {
            var response = _getContactByEmailQuery.Execute(email);

            return CreateResult(response);
        }

        [HttpGet("state/{state}/all")]
        public IActionResult GetAllByState([FromRoute]string state)
        {
            var response = _getAllContactsByStateQuery.Execute(state);

            return CreateResult(response);
        }

        [HttpGet("city/{city}/all")]
        public IActionResult GetAllByCity([FromRoute]string city)
        {
            var response = _getAllContactsByCity.Execute(city);

            return CreateResult(response);
        }

        private IActionResult CreateResult<TResponse>(Response<TResponse> response)
        {
            IActionResult result;

            switch (response.HttpStatusCode)
            {
                case HttpStatusCode.Created:
                    result = Created($"{Request.Path}/{response.Data.ToString()}", response.Data);
                    break;
                case HttpStatusCode.NotFound:
                    result = NotFound(response.Data);
                    break;
                case HttpStatusCode.BadRequest:
                    result = response.ErrorMessage != null ? BadRequest(response.ErrorMessage) : BadRequest(ModelState);
                    break;
                case HttpStatusCode.Conflict:
                case HttpStatusCode.InternalServerError:
                    result = StatusCode((int)response.HttpStatusCode);
                    break;
                default:
                    result = Ok(response.Data);
                    break;
            }

            return result;
        }
    }
}
