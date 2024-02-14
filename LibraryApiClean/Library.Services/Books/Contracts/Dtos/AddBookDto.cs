using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contracts.Dtos
{
   public class AddBookDto
    {
        public string Name { get; set; }

        public DateTime DateOfRelease { get; set; }

        public int Inventory { get; set; }

        public int WriterId { get; set; }

        public int ShelfId { get; set; }
    }
}
