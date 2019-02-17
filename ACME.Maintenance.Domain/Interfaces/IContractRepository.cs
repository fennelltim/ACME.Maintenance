﻿using ACME.Maintenance.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Maintenance.Domain.Interfaces
{
    public interface IContractRepository
    {
        ContractDto GetById(string contractId);
    }
}
