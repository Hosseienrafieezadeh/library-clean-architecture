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

      


        public void Update(Book book)
        {
            _context.Books.Update(book);
        }

        public List<GetBookDto> GetAll(GetBookFilterDto filterDto)
        {
            IQueryable<Book> query = _context.Books;
            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                query = query.Where(_ => _.Name.Contains(filterDto.Name));
            }
            if (!string.IsNullOrWhiteSpace(filterDto.Genre))
            {
                query = query.Where(_ => _.Shelf.Title.Contains(filterDto.Genre));
            }
            List<GetBookDto> books = query.Select(book => new GetBookDto
            {
                Id = book.Id,
                Name = book.Name,
                 WriterName = book.Writer.Name,
                 DateOfRelease = book.DateOfRelease,
                Inventory = book.Inventory,
                RentInventory = _context.Set<Rent>().Count(_ => _.BookId == book.Id && _.BackBook == false),
                ShelfTitle = book.Shelf.Title,
            }).ToList();
            return books;
        }
    }
}
