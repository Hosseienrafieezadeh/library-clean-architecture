﻿using Library.Services.Books.Contracts;
using Library.Services.Members.Contracts.Dtos;
using Library.Services.Members.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers.Members
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberService _service;
        public MemberController(MemberService service)
        {
            _service = service;
        }
        [HttpPost("add-member")]
        public async Task AddMember([FromBody] AddMemberDto dto)
        {
        await  _service.Add(dto);
            
        }

        [HttpPost("add-member-rent-book")]
        public async Task AddMemberRentBook([FromBody] MemberAddRentBookDto dto)
        {
           await _service.AddMemberRentBook(dto);
            
        }

        [HttpPatch("member-give-back-rent-book")]
        public async Task UpdateMemberRentBooks([FromBody] UpdateMemberRentBookDTo dto)
        {
            await _service.UpdateMemberrentBook(dto);
            
        }

        [HttpPatch("update-member/{name}")]
        public async Task UpdateMember(string name, [FromBody] UpdateMemberDtoscs dto)
        {
          await  _service.Update(name, dto);
            
        }

        [HttpDelete("delete-member/{name}")]
        public async Task DeleteMember(string name)
        {
            await _service.Delete(name);
            
        }

        [HttpGet("get-member")]
        public void GetMembers(GetMemberDto dto)
        {
            _service.GetAll(dto);
            
        }
    }
}