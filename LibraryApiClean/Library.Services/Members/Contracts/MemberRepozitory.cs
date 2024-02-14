using Library.Entitis;
using Library.Services.Members.Contracts.Dtos;
using Library.Services.Shelfs.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Members.Contracts
{
    public interface  MemberRepozitory
    {
        void Add(Member member);
        Member IsExistMember(string name);
        Book IsExistBook(int Id);
        Rent IsExistRent(UpdateMemberRentBookDTo dTo);

        void AddMemberRentBook(Rent rent);
        void UpdateMemberrentBook(Rent rent);
        void Delete(Member member);

        void Update(Member member);
        List<Member> GetAll(GetMemberDto dto);
    }
}
