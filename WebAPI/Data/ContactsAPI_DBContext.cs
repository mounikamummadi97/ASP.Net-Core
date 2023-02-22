using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ContactsAPI_DBContext : DbContext
    {
        public ContactsAPI_DBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        //public DbSet<AddContactRequest> AddContacts { get; set; }
        //public DbSet<UpdateContactRequest> UpdateContact { get; set; }
        //public DbSet<>

         } 

}
