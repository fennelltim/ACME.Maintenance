using ACME.Maintenance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME.Maintenance.Domain.DTO;

namespace ACME.Maintenance.Domain
{
    public class PartService
    {
        private readonly IPartServiceRepository _partServiceRepository;

        public PartService(IPartServiceRepository partServiceRepository)
        {
            _partServiceRepository = partServiceRepository;
        }

        public Part GetById(string partId)
        {
            var partDto = _partServiceRepository.GetById(partId);

            var part = AutoMapper.Mapper.Map<PartDto, Part>(partDto);
            return part;
            
        }
    }
}
