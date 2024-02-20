using Library.Entitis;
using Library.Services.Shelfs.Contracts;
using Library.Services.Shelfs.Contracts.Dtos;
using Library.Services.Writers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavv.Constract;

namespace Library.Services.Shelfs
{
    public class ShelfAppService : ShelfService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ShelfRepozotory _repozitory;
        public ShelfAppService(UnitOfWork unitOfWork, ShelfRepozotory repozitory)
        {
            _repozitory = repozitory;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(AddShelfDto dto)
        {
            var shelf = new Shelf
            {
                Title = dto.Title
            };
            _repozitory.Add(shelf);
           await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var shelf=_repozitory.IsExisShelf(id);
            if (shelf == null)
            {
                throw new Exception("Shelf not found.");
            }
            _repozitory.Delete(shelf);
            await _unitOfWork.Complete();
        }

      

        public List<GetShelfsDto> GetAll(GetShelfFilterDto dto)
        {
            return _repozitory.GetAll(dto);
        }

        public async Task Update(int id, UpdateShelfDto dto)
        {
            var shelf = _repozitory.IsExisShelf(id);
            if (shelf == null)
            {
                throw new Exception("Shelf not found.");
            }
            shelf.Title= dto.Title;
            _repozitory.Update(shelf);
            await _unitOfWork.Complete();
        }
    }
}
