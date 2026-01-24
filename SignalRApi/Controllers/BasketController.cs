using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BasketDto;
using SignalR.DtoLayer.ProductDto;

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



        /*[HttpGet("BasketListByMenuTableWithProductName/{id}")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            var values = _basketService.TBasketListByMenuTableWithProductName(id);
            return Ok(values);
        }*/
    }
}
