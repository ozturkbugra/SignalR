using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var result = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto dto)
        {
            var value = _mapper.Map<Discount>(dto);
            _discountService.TAdd(value);
            return Ok("İndirim eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim Silindi");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto dto)
        {
            var value = _mapper.Map<Discount>(dto);
            _discountService.TUpdate(value);
            return Ok("İndirim güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            var result = _mapper.Map<GetDiscountDto>(value);
            return Ok(result);
        }
    }
}
