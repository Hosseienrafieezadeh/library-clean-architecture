using Library.Entitis;
using Library.Services.Members.Contracts;
using Library.Services.Members.Contracts.Dtos;
using Library.Services.Shelfs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tavv.Constract;

namespace Library.Services.Members
{   
    public class MemberAppService : MemberService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly MemberRepozitory _repozitory;
        public MemberAppService(MemberRepozitory repozitory,UnitOfWork unitOfWork)
        {
                _repozitory = repozitory;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddMemberDto dto)
        {
            var member = new Member
            {
                Name = dto.Name,
                Email = dto.Email
            };
            _repozitory.Add(member);
            await _unitOfWork.Complete();
        }

        public async Task AddMemberRentBook(MemberAddRentBookDto dto)
        {
            var member = _repozitory.IsExistMember(dto.Name);
            if (member == null)
            {
                throw new Exception("Member not found. Please try again later.");
            }

            var book = _repozitory.IsExistBook(dto.BookId);
            if (book == null)
            {
                throw new Exception("Book not found.");
            }

            var memRentBook = new Rent
            {
                BackBook = false,
                Member = member,
                Book = book
            };

            _repozitory.AddMemberRentBook(memRentBook);
            book.Inventory--;
           await _unitOfWork.Complete();

        }

        public async Task Delete( string name)
        {
            var member = _repozitory.IsExistMember(name);

            if (member == null)
            {
                throw new Exception("Member not found.");
            }

            _repozitory.Delete(member);
            await _unitOfWork.Complete();
        }

        public List<GetMemberDto> GetUser(GetMemberFillterDto filterDto)
        {
           
            
                return _repozitory.GetUsersByName(filterDto);

            
        }

        public List<GetMemberRentBook> GetUserRentBooks(int userId)
        {
            return _repozitory.GetUserRentBooksByID(userId);
        }

        public async Task Update(string name, UpdateMemberDtoscs dto)
        {
            var member = _repozitory.IsExistMember(name);

            if (member == null)
            {
                throw new Exception("Member not found.");
            }

            member.Name = dto.Name;
            member.Email = dto.Email;

            _repozitory.Update(member);
           await _unitOfWork.Complete();
        }

        public async Task UpdateMemberrentBook(UpdateMemberRentBookDTo dto)
        {
            var memRentBook = _repozitory.IsExistRent(dto);
            if (memRentBook == null)
            {
                throw new Exception("The specified rent book does not exist or has been returned already.");
            }

            memRentBook.BackBook = true;

            var book = _repozitory.IsExistBook(dto.BookId);
            if (book == null)
            {
                throw new Exception("The specified book does not exist.");
            }

            book.Inventory++;
           await _unitOfWork.Complete();
        }
    }
}
