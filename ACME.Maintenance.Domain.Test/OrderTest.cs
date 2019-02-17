using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACME.Maintenance.Domain.Test
{
    [TestClass]
    public class OrderTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void Test()
        {
            var orderService = new OrderService();

            var contract = new Contract
            {
                ContractId = "CONTRACTID",
                ExpirationDate = DateTime.Now.AddDays(1)
            };

            var order = orderService.CreateOrder(contract);

            var part = new Part()
            {
                PartId = "PARTID",
                Price = 50.0
            };

            var orderItem = new OrderItem()
            {
                Part = part,
                Price = part.Price,
                Quantity = 1,
                LineTotal = part.Price
            };

            order.AddOrderItem(orderItem);
        }
    }
}
