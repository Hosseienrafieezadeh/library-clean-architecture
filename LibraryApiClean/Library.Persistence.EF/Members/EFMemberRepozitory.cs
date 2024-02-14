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

        public List<Member> GetAll(GetMemberDto dto)
        {
            var query = _context.members
                .Include(m => m.Rents)
                    .ThenInclude(r => r.Book)
                .AsQueryable();

            if (!string.IsNullOrEmpty(dto.Name))
            {
                query = query.Where(m => m.Name.Contains(dto.Name));
            }

            if (!string.IsNullOrEmpty(dto.Email))
            {
                query = query.Where(m => m.Email.Contains(dto.Email));
            }

            return query.ToList();
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
    }
}
