using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            var result = _mapper.Map<List<ResultBookingDto>>(values);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto dto)
        {
            var values = _mapper.Map<Booking>(dto);
            _bookingService.TAdd(values);
            return Ok("Rezervasyon Yapıldı");
        }


        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateBookingDto dto)
        {
            var value = _mapper.Map<Booking>(dto);
            _bookingService.TUpdate(value);
            return Ok("Rezervasyon güncellendi");
        }


        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _bookingService.TGetById(id);
            var result = _mapper.Map<GetBookingDto>(value);
            return Ok(result);
        }

    }
}
