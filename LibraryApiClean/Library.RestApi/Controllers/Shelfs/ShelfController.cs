using Library.Services.Shelfs.Contracts.Dtos;
using Library.Services.Shelfs.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers.Shelfs
{
    [Route("api/shelf")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly ShelfService _service;

        public ShelfController(ShelfService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task AddShelf([FromBody] AddShelfDto dto)
        {
            await _service.Add(dto);
            
        }

        [HttpPatch("update/{id}")]
        public async Task UpdateShelf([FromRoute] int id, [FromBody] UpdateShelfDto dto)
        {
            await _service.Update(id, dto);
            
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteShelf([FromRoute] int id)
        {
            await _service.Delete(id);
            
        }
        [HttpGet]
        public List<GetShelfsDto> GetAll([FromQuery] GetShelfFilterDto dto)
        {
            return _service.GetAll(dto);
        }
    }
}
