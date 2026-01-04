using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            var result = _mapper.Map<List<ResultAboutDto>>(values);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto dto)
        {
            var about = _mapper.Map<About>(dto);
            _aboutService.TAdd(about);
            return Ok("Hakkımda kısmı eklendi");
        }


        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda Kısmı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto dto)
        {
            var about = _mapper.Map<About>(dto);
            _aboutService.TUpdate(about);
            return Ok("Hakkımda kısmı güncellendi");
        }


        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            var result = _mapper.Map<GetAboutDto>(value);
            return Ok(result);
        }

    }
}
