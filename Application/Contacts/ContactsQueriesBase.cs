using AutoMapper;

namespace Application.Contacts
{
    public class ContactsQueriesBase
    {
        protected readonly IMapper _mapper;

        public ContactsQueriesBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
