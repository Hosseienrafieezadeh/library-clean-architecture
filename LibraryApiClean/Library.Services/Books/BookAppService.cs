using Library.Entitis;
using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavv.Constract;

namespace Library.Services.Books
{
    public class BookAppService :BookService
    {
        private readonly BookRepozitory _repozitory;
      private readonly UnitOfWork _unitOfWork;
        public BookAppService(BookRepozitory repozitory,UnitOfWork unitOfWork)
        {
                _repozitory = repozitory;
            _unitOfWork = unitOfWork;

        }
        public async Task Add(AddBookDto dto)
        {
            var book = new Book
            {
                Name = dto.Name,
                WriterId = dto.WriterId,
                ShelfId = dto.ShelfId,
                DateOfRelease = dto.DateOfRelease,
                Inventory = dto.Inventory
            };
           _repozitory.Add(book);
            await _unitOfWork.Complete();

        }

        public async Task Delete(int id)
        {
         var book=_repozitory.IsExistBook(id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }
            _repozitory.Delete(book);
            await _unitOfWork.Complete();
        }



        public List<Book> GetAll(GetBookDto dto)
        {
            try
            {
            
                var books = _repozitory.GetAll(dto);
                return books;
            }
            catch (Exception ex)
            {
             
                throw new Exception("An error occurred while fetching books: " + ex.Message);
            }
        }





        public async Task Update(int id, UpdateBookDto dto)
        {
            var book = _repozitory.IsExistBook(id);
            if (book is null)
            {
                throw new Exception("Book not found");
            }
            book.Name = dto.Name;
            book.WriterId = dto.WriterId;
            book.ShelfId = dto.ShelfId;
            book.Inventory = dto.Inventory;
            book.DateOfRelease = dto.DateOfRelease;
            _repozitory.Update(book);
            await _unitOfWork.Complete();
        }
    }
}
