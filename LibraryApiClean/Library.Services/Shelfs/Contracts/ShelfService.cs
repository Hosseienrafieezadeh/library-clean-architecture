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
    public interface  ShelfService
    {
        Task Add(AddShelfDto dto);
        Task Update(int id, UpdateShelfDto dto);
        Task Delete(int id);
        List<Shelf> GetAll(GetShelfsDto dto);
    }
}
