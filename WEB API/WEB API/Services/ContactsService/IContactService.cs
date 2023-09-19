using WEB_API.Dtos.Contact;
using WEB_API.Models;

namespace WEB_API.Services.ContactsService
{
    public interface IContactService
    {
        Task<ServerBaseReponse<List<ContactReponse>>> GetContacts();
        Task<ServerBaseReponse<bool>> UpdateContact(ContactRequest request);
        Task<ServerBaseReponse<bool>> AddContact(ContactRequest contacts);
    }
}
