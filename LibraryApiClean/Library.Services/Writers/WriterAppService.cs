using Library.Entitis;
using Library.Services.Writers.Contracts;
using Library.Services.Writers.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavv.Constract;

namespace Library.Services.Writers
{
    public class WriterAppService:WriterService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly WriterRepozitory _repozitory;
        public WriterAppService(UnitOfWork unitOfWork,WriterRepozitory  repozitory) 
        {
            _repozitory = repozitory;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddWriterDto dto)
        {
            var writer = new Writer
            {
                Name = dto.Name
            };

            _repozitory.Add(writer);
          await  _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var writer = (_repozitory.IsExisWriter(id));
            if (writer == null)
            {
                throw new Exception("Writer not found.");
            }
            _repozitory.Delete(writer);
          await  _unitOfWork.Complete();
        }

        public List<GetWriterDto > GetAll(GetWriterFilterDto dto)
        {
            return _repozitory.GetAll(dto);
        }

        public async Task Update(int id, UpdateWriterDto dto)
        {
            var writer = (_repozitory.IsExisWriter(id));
            if (writer == null)
            {
                throw new Exception("Writer not found.");
            }
            writer.Name = dto.Name;
            _repozitory.Update(writer);
           await _unitOfWork.Complete();
        }
    }
}
