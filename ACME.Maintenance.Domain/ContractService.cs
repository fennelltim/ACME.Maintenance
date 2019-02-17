using ACME.Maintenance.Domain.DTO;
using ACME.Maintenance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ACME.Maintenance.Domain
{
    public class ContractService
    {
        public readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public Contract GetById(string contractId)
        {
            // 1.   Call an instance of my persistence layer
            //var contractRepository = new ContractRepository();


            // 2.   Call the FindById method of the persistence layer
            //      and pass the contractId.
            var contractDto = _contractRepository.GetById(contractId);

            // 3.   Receive the data back from that function and
            //      populate my properties ... similar to this,
            //      but with REAL data:

            //var contract = new Contract();
            //contract.ContractId = contractDto.ContractId;
            //contract.ExpirationDate = contractDto.ExpirationDate;
            var contract = AutoMapper.Mapper.Map<ContractDto, Contract>(contractDto);
            return contract;
        }   
    }
}
