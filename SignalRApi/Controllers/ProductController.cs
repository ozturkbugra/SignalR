using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var result = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(result);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(value);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var value = _productService.TProductCount();
            return Ok(value);
        }

        [HttpGet("ProductCountByCategoryNameTatli")]
        public IActionResult ProductCountByCategoryNameTatli()
        {
            var value = _productService.TProductCountByCategoryNameTatli();
            return Ok(value);
        }
        [HttpGet("ProductCountByCategoryNameCorba")]
        public IActionResult ProductCountByCategoryNameCorba()
        {
            var value = _productService.TProductCountByCategoryNameCorba();
            return Ok(value);
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            var value = _productService.TProductPriceAvg();
            return Ok(value);
        }

        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            var value = _productService.TProductNameByMaxPrice();
            return Ok(value);
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            var value = _productService.TProductNameByMinPrice();
            return Ok(value);
        }


        [HttpGet("AvgPriceByCorba")]
        public IActionResult AvgPriceByCorba()
        {
            var value = _productService.TAvgPriceByCorba();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            var value = _mapper.Map<Product>(dto);
            _productService.TAdd(value);
            return Ok("Ürün eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün Silindi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto dto)
        {
            var value = _mapper.Map<Product>(dto);
            _productService.TUpdate(value);
            return Ok("Ürün güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            var result = _mapper.Map<GetProductDto>(value);
            return Ok(result);
        }
    }
}
