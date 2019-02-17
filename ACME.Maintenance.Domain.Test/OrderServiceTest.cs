using System;
using System.Collections.Generic;
using ACME.Maintenance.Domain.DTO;
using ACME.Maintenance.Domain.Enums;
using ACME.Maintenance.Domain.Exceptions;
using ACME.Maintenance.Domain.Interfaces;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACME.Maintenance.Domain.Test
{
    [TestClass]
    public class OrderServiceTest
    {
        private IContractRepository _contractRepository;
        private ContractService _contractService;

        private const string ValidContractId = "CONTRACTID";
        private const string ExpiredContractId = "EXPIREDCONTRACTID";

        [TestInitialize]
        public void Initialize()
        {
            // Initilize serves as the "Composition root"

            _contractRepository = A.Fake<IContractRepository>();
            _contractService = new ContractService(_contractRepository);

            A.CallTo(() => _contractRepository.GetById(ValidContractId))
                .Returns(new ContractDto
                {
                    ContractId = ValidContractId,
                    ExpirationDate = DateTime.Now.AddDays(1)
                });

            A.CallTo(() => _contractRepository.GetById(ExpiredContractId))
                .Returns(new ContractDto
                {
                    ContractId = ExpiredContractId,
                    ExpirationDate = DateTime.Now.AddDays(-1)
                });

            
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<ContractDto, Contract>());
        }

        [TestCleanup]
        public void Cleanup()
        {
            AutoMapper.Mapper.Reset();
        }

        [TestMethod]
        public void CreateOrder_ValidContract_CreatesNewOrder()
        {
            // Arrange
            var orderService = new OrderService();
            var contract = _contractService.GetById(ValidContractId);

            // Act
            var newOrder = orderService.CreateOrder(contract);

            // Assert
            Assert.IsInstanceOfType(newOrder, typeof(Order));

            Assert.IsTrue(Guid.TryParse(newOrder.OrderId, out Guid guidOut));

            //Assert.AreEqual(newOrder.OrderId, OrderId);

            Assert.AreEqual(newOrder.Status, OrderStatus.New);
            Assert.IsInstanceOfType(newOrder.OrderItems, typeof(List<OrderItem>));

        }


        [TestMethod, ExpectedException(typeof(ExpiredContractException))]
        public void CreateOrder_ExpiredContract_ThrowsException()
        {
            // Arrange
            var orderService = new OrderService();
            var contract = _contractService.GetById(ExpiredContractId);

            // Act
            var newOrder = orderService.CreateOrder(contract);
        }

        /*
        [TestMethod]
        public void AddOrderItem_ValidPart_AddsOrderItem()
        {
            // Arrange
            var orderService = new OrderService();
            var contract = _contractService.GetById(ValidContractId);
            var newOrder = orderService.CreateOrder(contract);

            var partService = new PartService();
            var part = partService.GetPartById(ValidPartId);

            // Act
            var orderItem = orderService.AddOrderItem(part, quantity);

            // Assert
            Assert.IsInstanceOfType(orderItem, typeof(OrderItem));
            Assert.AreEqual(orderItem.Product, product);
            Assert.AreEqual(order.OrderItemTotal, 100.0);

        }
        */
    }
}
