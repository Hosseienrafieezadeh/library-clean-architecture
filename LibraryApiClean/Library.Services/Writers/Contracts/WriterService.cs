using Library.Entitis;
using Library.Services.Books.Contracts.Dtos;
using Library.Services.Writers.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Writers.Contracts
{
    public interface WriterService
    {
        Task Add(AddWriterDto dto);
        Task Update(int id, UpdateWriterDto dto);
        Task Delete(int id);
        List<GetWriterDto> GetAll(GetWriterFilterDto dto);
    }
}
