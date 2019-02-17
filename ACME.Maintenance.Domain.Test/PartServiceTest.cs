using System;
using ACME.Maintenance.Domain.DTO;
using ACME.Maintenance.Domain.Interfaces;
using ACME.Maintenance.Domain.Exceptions;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACME.Maintenance.Domain.Test
{
    [TestClass]
    public class PartServiceTest
    {
        private const string ValidPartId = "VALIDPARTID";
        private const string InvalidPartId = "INVALIDPARTID";
        private const double ValidPartAmount = 50.0;

        private IPartServiceRepository _partRepository;

        [TestInitialize]
        public void Initialize()
        {
            _partRepository = A.Fake<IPartServiceRepository>();

            A.CallTo(() => _partRepository.GetById(ValidPartId)).Returns(new PartDto { PartId = ValidPartId, Price = ValidPartAmount });

            A.CallTo(() => _partRepository.GetById(InvalidPartId)).Throws(new PartNotFoundException());
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<PartDto, Part>());
        }

        [TestCleanup]
        public void CleanUp()
        {
            AutoMapper.Mapper.Reset();
        }

        [TestMethod]
        public void GetPartById_ValidId_ReturnsPart()
        {
            var partService = new PartService(_partRepository);
            var part = partService.GetById(ValidPartId);

            Assert.IsInstanceOfType(part, typeof(Part));
            Assert.AreEqual(part.PartId, ValidPartId);
            Assert.AreEqual(part.Price, ValidPartAmount);
        }

        [TestMethod, ExpectedException(typeof(PartNotFoundException))]
        public void GetPartById_InvalidId_ReturnsPart()
        {
            var partService = new PartService(_partRepository);
            var part = partService.GetById(InvalidPartId);
        }
    }
}
