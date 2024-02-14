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

        [HttpPost("add-shelf")]
        public async Task AddShelf([FromBody] AddShelfDto dto)
        {
            await _service.Add(dto);
            
        }

        [HttpPatch("update-shelf/{id}")]
        public async Task UpdateShelf([FromRoute] int id, [FromBody] UpdateShelfDto dto)
        {
            await _service.Update(id, dto);
            
        }

        [HttpDelete("delete-shelf/{id}")]
        public async Task DeleteShelf([FromRoute] int id)
        {
            await _service.Delete(id);
            
        }

        [HttpGet("get-shelf")]
        public void GetShelf([FromQuery]GetShelfsDto  dto)
        {
            var shelves = _service.GetAll(dto);
            
        }
    }
}
