﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Members.Contracts.Dtos
{
    public class AddMemberDto
    {
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
