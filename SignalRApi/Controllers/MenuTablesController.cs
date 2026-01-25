using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {

        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;
        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var values = _menuTableService.TMenuTableCount();
            return Ok(values);
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            var result = _mapper.Map<List<ResultMenuTableDto>>(values);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto dto)
        {
            var MenuTable = _mapper.Map<MenuTable>(dto);
            _menuTableService.TAdd(MenuTable);
            return Ok("Masa kısmı eklendi");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("Masa Kısmı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto dto)
        {
            var MenuTable = _mapper.Map<MenuTable>(dto);
            _menuTableService.TUpdate(MenuTable);
            return Ok("Masa kısmı güncellendi");
        }


        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            var result = _mapper.Map<GetMenuTableDto>(value);
            return Ok(result);
        }
    }
}
