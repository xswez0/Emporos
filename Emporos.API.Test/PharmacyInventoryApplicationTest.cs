using AutoMapper;
using Emporos.API.Pharmacy.Controllers.Mappings;
using Emporos.API.Pharmacy.Controllers.ModelView;
using Emporos.API.Pharmacy.Controllers.V1;
using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Domain.Internal;
using Emporos.API.Pharmacy.Domain.Mappings;
using Hellang.Middleware.ProblemDetails;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Emporos.API.Test
{
    [TestClass]
    public class PharmacyInventoryApplicationTest
    {
        private PharmacyInventoryController _controller;
        private IDomainService _domainService;
        private IMapper _mapper;
        private DataSetTest dataSetTest;

        [TestInitialize]
        public void Initialize()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new Mapping()));
            _mapper = new Mapper(mapperConfig);

            dataSetTest = new DataSetTest();
            _domainService = new MockDomainService();
            _controller = new PharmacyInventoryController(null, _domainService, _mapper);
        }

        [TestMethod]
        public async Task PharmacyInventoryCreate_QuantityOnHand_IsNonZero_Success()
        {
            var expectedResult = dataSetTest.GetFakeCreatePharmacyInventoryResponse_QuantityOnHandNonZero();
            var result = await _controller.Post(dataSetTest.GetFakeCreatePharmacyInventoryRequest_QuantityOnHandNonZero());

            Assert.AreEqual(expectedResult.HospitalName, result.HospitalName);
            Assert.AreEqual(expectedResult.PharmacyName, result.PharmacyName);
            Assert.AreEqual(expectedResult.QuantityOnHand, result.QuantityOnHand);
            Assert.AreEqual(expectedResult.ReorderQuantity, result.ReorderQuantity);
            Assert.AreEqual(expectedResult.SellingUnitOfMeasure, result.SellingUnitOfMeasure);
            Assert.AreEqual(expectedResult.UnitPrice, result.UnitPrice);
            Assert.AreEqual(expectedResult.UPC, result.UPC);
            Assert.AreEqual(expectedResult.VendorName, result.VendorName);
        }

        [TestMethod]
        public async Task PharmacyInventoryUpdate_QuantityOnHand_IsNonZero_Success()
        {
            var expectedResult = dataSetTest.GetFakeUpdatePharmacyInventoryResponse_QuantityOnHandNonZero();
            var result = await _controller.Put(dataSetTest.GetFakeUpdatePharmacyInventoryRequest_QuantityOnHandNonZero(), 1);

            Assert.AreEqual(expectedResult.Message, result.Message);
        }
    }
}
