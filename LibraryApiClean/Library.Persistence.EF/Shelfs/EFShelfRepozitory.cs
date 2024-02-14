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

        public List<Shelf> GetAll(GetShelfsDto dto)
        {
            IQueryable<Shelf> query = _context.Shelves;

            if (!string.IsNullOrEmpty(dto.Title))
            {
                query = query.Where(w => w.Title.Contains(dto.Title));
            }

            return query.ToList();
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
