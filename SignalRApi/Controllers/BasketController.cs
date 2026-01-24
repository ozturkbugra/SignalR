using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BasketDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }
        [HttpGet("GetBasketByMenuTableNumber/{id}")]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var value = _mapper.Map<List<ResultBasketWithProductAndTable>>(_basketService.TGetBasketByMenuTableNumber(id));
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            var basket = _mapper.Map<Basket>(createBasketDto);
            _basketService.TAdd(basket);
            return Ok("Sepete Ürün Eklendi kısmı eklendi");
        }
    }
}
