using AutoMapper;
using WEB_API.Dtos.Contact;
using WEB_API.Models;

namespace WEB_API
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile() {
            CreateMap<Contacts, ContactReponse>();
            CreateMap<ContactRequest, Contacts>();
        }
    }
}
