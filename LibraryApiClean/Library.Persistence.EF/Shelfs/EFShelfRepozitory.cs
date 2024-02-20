using Library.Entitis;
using Library.Persistence.EF.EntitisMaps;
using Library.Services.Shelfs.Contracts;
using Library.Services.Shelfs.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EF.Shelfs
{
    public class EFShelfRepozitory : ShelfRepozotory
    {
        private readonly EFDataContext _context;

        public EFShelfRepozitory(EFDataContext context)
        {
            _context = context;
        }
        public void Add(Shelf shelf)
        {
            _context.Shelves.Add(shelf);
        }

        public void Delete(Shelf shelf)
        {
         _context.Shelves.Remove(shelf);
        }

       

        public List<GetShelfsDto> GetAll(GetShelfFilterDto dto)
        {
            IQueryable<Shelf> query = _context.Shelves;
            if (!string.IsNullOrWhiteSpace(dto.Title))
            {
                query = query.Where(genre => genre.Title.Contains(dto.Title));
            }
            List<GetShelfsDto> genres = query.Select(genre => new GetShelfsDto
            {
                Id = genre.Id,
                Title = genre.Title,

            }).ToList();

            return genres;
        }

       

        public Shelf IsExisShelf(int Id)
        {
            return _context.Shelves.FirstOrDefault(_ => _.Id == Id);
        }

        public void Update(Shelf shelf)
        {
          _context.Shelves.Update(shelf);
        }
    }
}
