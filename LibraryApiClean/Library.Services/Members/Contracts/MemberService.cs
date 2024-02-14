using Library.Entitis;
using Library.Services.Members.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Members.Contracts
{
    public interface MemberService
    {
        Task Add(AddMemberDto dto);
        Task AddMemberRentBook(MemberAddRentBookDto dto);
        Task UpdateMemberrentBook(UpdateMemberRentBookDTo dto);
        Task Delete(string name);

        Task Update(string name,UpdateMemberDtoscs dto);
        List<Member> GetAll(GetMemberDto dto);

    }
}
