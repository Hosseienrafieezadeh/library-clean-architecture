using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;
        public BookController(BookService service)
        {
                _service = service;
        }
        [HttpPost("add-book")]
        public async Task AddBook([FromBody] AddBookDto dto)
        {
           await _service.Add(dto);
          
        }

        [HttpPatch("update/{id}")]
        public async Task UpdateBook([FromRoute] int id, [FromBody] UpdateBookDto dto)
        {
           await _service.Update(id, dto);
           
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteBook([FromRoute]int id)
        {
            
           await _service.Delete(id);
       
        }

        [HttpGet("get")]
        public List<GetBookDto> GetAll([FromQuery] GetBookFilterDto filterDto)
        {

            return _service.GetAll(filterDto);

        }
    }
}
