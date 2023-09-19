using Microsoft.AspNetCore.Mvc;
using WEB_API.Dtos.Contact;
using WEB_API.Models;
using WEB_API.Services.ContactsService;

namespace WEB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _icontactService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger, IContactService iContactService) { 
            _icontactService = iContactService;
            _logger = logger;

        }
        [HttpGet]
        public async Task<ActionResult<ServerBaseReponse<List<ContactReponse>>>> GetContacts()
        {
            var contact = await _icontactService.GetContacts();
            return Ok(contact);
        }
        [HttpPost]
        public async Task<ActionResult<ServerBaseReponse<List<bool>>>> AddContact(ContactRequest request)
        {
            var contact = await _icontactService.AddContact(request);
            return Ok(contact);
        }
        [HttpPut]
        public async Task<ActionResult<ServerBaseReponse<bool>>> UpdateContact(ContactRequest request)
        {
            var contact = await _icontactService.UpdateContact(request);
            return Ok(contact);
        }
    }
}
