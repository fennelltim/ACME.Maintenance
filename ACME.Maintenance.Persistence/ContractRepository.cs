using ACME.Maintenance.Domain;
using ACME.Maintenance.Domain.DTO;
using ACME.Maintenance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Maintenance.Persistence
{
    public class ContractRepository : IContractRepository
    {
        public ContractDto GetById(string contractId)
        {
            var contractDto = new ContractDto();

            if (contractId == "CONTRACTID")
            {
                contractDto.ExpirationDate = DateTime.Now.AddDays(1);
            }
            else if (contractId == "EXPIREDCONTRACTID")
            {
                contractDto.ExpirationDate = DateTime.Now.AddDays(-1);
            }

            // Stubbed ... ultimately, it will go out to the
            // database and retrieve the given Contract
            // record based on the contractId.

            contractDto.ContractId = contractId;
            //contractDto.ExpirationDate = DateTime.Now.AddDays(1);
            
            return contractDto;
        }
    }
}
