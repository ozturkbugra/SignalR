using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var result = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _categoryService.TAdd(category);
            return Ok("Kategori eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _categoryService.TUpdate(category);
            return Ok("Kategori güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            var result = _mapper.Map<GetCategoryDto>(value);
            return Ok(result);
        }
    }
}
