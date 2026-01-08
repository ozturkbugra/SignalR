using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var result = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto dto)
        {
            var Contact = _mapper.Map<Contact>(dto);
            _contactService.TAdd(Contact);
            return Ok("İletişim eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("İletişim Silindi");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
            var Contact = _mapper.Map<Contact>(dto);
            _contactService.TUpdate(Contact);
            return Ok("İletişim güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            var result = _mapper.Map<GetContactDto>(value);
            return Ok(result);
        }
    }
}
