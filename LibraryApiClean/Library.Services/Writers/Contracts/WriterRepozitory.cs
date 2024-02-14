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
    public interface WriterRepozitory
    {
        void Add(Writer writer);
        Writer IsExisWriter(int Id);
        void Delete(Writer writer);

        void Update(Writer writer);
        List<Writer> GetAll(GetWriterDto dto);
    }
}
