using Library.Entitis;
using Library.Persistence.EF.EntitisMaps;
using Library.Services.Members.Contracts;
using Library.Services.Members.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EF.Members
{
    public class EFMemberRepozitory : MemberRepozitory
    {
        private readonly EFDataContext _context;

        public EFMemberRepozitory(EFDataContext context)
        {
            _context = context;
        }
        public void Add(Member member)
        {
            _context.Add(member);
        }

        public void AddMemberRentBook(Rent rent)
        {
            _context.Rents.Add(rent);
        }

        public void Delete(Member member)
        {
            _context.members.Remove(member);
        }

        



        public Book IsExistBook(int Id)
        {
           return _context.Books.FirstOrDefault(_=>_.Id == Id);
        }

        public Member IsExistMember(string name)
        {
            return _context.members.FirstOrDefault(_ => _.Name == name);
        }

        public Rent IsExistRent(UpdateMemberRentBookDTo dTo)
        {
           return _context.Rents.FirstOrDefault(r => r.UserId == dTo.UserId && r.BookId == dTo.BookId && !r.BackBook);
        }

        public void Update(Member member)
        {
            _context.members.Update(member);
        }

      
            public void UpdateMemberrentBook(Rent rent)
        {
            _context.Rents.Update(rent);
       }

        public List<GetMemberDto> GetUsersByName(GetMemberFillterDto filterDto)
        {

            IQueryable<Member> query = _context.members;

            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                query = query.Where(user => user.Name.Contains(filterDto.Name));
            }

            List<GetMemberDto> users = query.Select(user => new GetMemberDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            }).ToList();
            return users;
        }

        public List<GetMemberRentBook> GetUserRentBooksByID(int userId)
        {
            var user = _context.members.Find(userId);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            var rentUserBooks = _context.Set<Rent>().Where(_ => _.UserId == userId);
            List<GetMemberRentBook> userRents = rentUserBooks.Select(userRent => new GetMemberRentBook
            {
                BookName = userRent.Book.Name,
                Status = (userRent.BackBook ? "Before" : "already")

            }).ToList();
            return userRents;
        }
    }
}
