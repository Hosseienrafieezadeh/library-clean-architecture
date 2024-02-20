using Library.Services.Writers.Contracts;
using Library.Services.Writers.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers.Writers
{
    [Route("api/writer")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly WriterService _service;

        public WritersController(WriterService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task  AddWriter([FromBody] AddWriterDto dto)
        {
            await _service.Add(dto);
           
        }

        [HttpPatch("update/{id}")]
        public async Task UpdateWriter([FromRoute] int id, [FromBody] UpdateWriterDto dto)
        {
            await _service.Update(id, dto);
            
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteWriter([FromRoute] int id)
        {
            await _service.Delete(id);
         
        }

        [HttpGet("get")]
        public List<GetWriterDto> GetAll([FromQuery] GetWriterFilterDto dto)
        {
            return _service.GetAll(dto);
        }
    }
}
