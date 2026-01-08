using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var result = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto dto)
        {
            var value = _mapper.Map<Feature>(dto);
            _featureService.TAdd(value);
            return Ok("Öne Çıkan Bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto dto)
        {
            var value = _mapper.Map<Feature>(dto);
            _featureService.TUpdate(value);
            return Ok("Öne Çıkan Bilgisi güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            var result = _mapper.Map<GetFeatureDto>(value);
            return Ok(result);
        }
    }
}
