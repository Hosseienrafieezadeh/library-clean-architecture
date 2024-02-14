﻿using Library.Entitis;
using Library.Persistence.EF.EntitisMaps;
using Library.Services.Writers.Contracts;
using Library.Services.Writers.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EF.Writers
{
    public class EFWriterRepozitory:WriterRepozitory
    {
        private readonly EFDataContext _context;
       
        public EFWriterRepozitory(EFDataContext context) 
        {
            _context = context;
        }

        public void Add(Writer writer)
        {
            _context.Writers.Add(writer);
        }

        public void Delete(Writer writer)
        {
            _context.Writers.Remove(writer);
        }

        public List<Writer> GetAll(GetWriterDto dto)
        {
            IQueryable<Writer> query = _context.Writers;

            if (!string.IsNullOrEmpty(dto.Name))
            {
                query = query.Where(w => w.Name.Contains(dto.Name));
            }

            return query.ToList();
        }


        public Writer IsExisWriter(int Id)
        {
            return _context.Writers.FirstOrDefault(_ => _.Id == Id);
        }

        public void Update(Writer writer)
        {
            _context.Writers.Update(writer);
        }
    }
}
