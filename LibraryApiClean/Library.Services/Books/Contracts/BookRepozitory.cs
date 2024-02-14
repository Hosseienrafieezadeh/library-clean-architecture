using Library.Entitis;
using Library.Services.Books.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contracts
{
    public interface BookRepozitory
    {
        void Add(Book book);
        Book IsExistBook(int Id);
        void Delete(Book book);

        void Update( Book book);
        List<Book> GetAll(GetBookDto dto);
           
    }
}
