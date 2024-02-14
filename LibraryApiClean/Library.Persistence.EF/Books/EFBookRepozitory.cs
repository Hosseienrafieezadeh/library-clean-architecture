using Library.Entitis;
using Library.Persistence.EF.EntitisMaps;
using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EF.Books
{
    public class EFBookRepozitory:BookRepozitory
    {
        private readonly EFDataContext _context;
        public EFBookRepozitory(EFDataContext context)
        {
                _context = context;
        }

        public Book IsExistBook(int Id) 
        {
            return _context.Books.FirstOrDefault(b => b.Id == Id);
        }
        public void Add(Book book)
        {
           _context.Books.Add(book);
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }

        public List<Book> GetAll(GetBookDto dto)
        {
            IQueryable<Book> query = _context.Books.Include(b => b.Rents);

            if (!string.IsNullOrEmpty(dto.Name))
            {
                query = query.Where(b => b.Name.Contains(dto.Name));
            }

            if (!string.IsNullOrEmpty(dto.WriterName))
            {
                query = query.Where(b => b.Writer.Name.Contains(dto.WriterName));
            }

            if (!string.IsNullOrEmpty(dto.ShelfTitle))
            {
                query = query.Where(b => b.Shelf.Title.Contains(dto.ShelfTitle));
            }

            if (dto.DateOfRelease != default)
            {
                query = query.Where(b => b.DateOfRelease == dto.DateOfRelease);
            }

            if (dto.Inventory > 0)
            {
                query = query.Where(b => b.Inventory >= dto.Inventory);
            }

            if (dto.RentInventory > 0)
            {
                query = query.Where(b => b.Inventory>= dto.RentInventory);
            }

            return query.ToList();
        }


        public void Update(Book book)
        {
            _context.Books.Update(book);
        }
    }
}
