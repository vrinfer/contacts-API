using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IContacDbContext
    {
        DbSet<Contact> Contacts { get; set; }

        void Save();
    }
}
