using ACME.Maintenance.Domain.Enums;
using ACME.Maintenance.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Maintenance.Domain
{
    public class OrderService
    {
        public Order CreateOrder(Contract contract)
        {
            if (contract.ExpirationDate < DateTime.Now)
                throw new ExpiredContractException();

            var order = new Order { OrderId = Guid.NewGuid().ToString(), Status = OrderStatus.New };
            return order;
        }
    }
}
