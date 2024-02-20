using Library.Entitis;
using Library.Services.Shelfs.Contracts.Dtos;
using Library.Services.Writers.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Shelfs.Contracts
{
    public interface ShelfRepozotory
    {
        void Add(Shelf shelf);
        Shelf IsExisShelf(int Id);
        void Delete(Shelf shelf);
        List<GetShelfsDto> GetAll(GetShelfFilterDto dto);
        void Update(Shelf shelf);

    }
}
