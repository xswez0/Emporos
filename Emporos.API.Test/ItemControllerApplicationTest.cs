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
    public class ItemControllerApplicationTest
    {
        private ItemController _controller;
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
            _controller = new ItemController(null, _domainService, _mapper);
        }

        [TestMethod]
        public async Task ItemUpdate_UPC_12DigitNumber_Success()
        {
            var expectedResult = dataSetTest.GetFakeUpdateItemResponse_UPC_12DigitNumber();
            var result = await _controller.Put(dataSetTest.GetFakeUpdateItemRequest_UPC_12DigitNumber(), 1);

            Assert.AreEqual(expectedResult.Message, result.Message);
        }

        [TestMethod]
        public async Task ItemCreate_UPC_12DigitNumber_Success()
        {
            var expectedResult = dataSetTest.GetFakeCreateItemResponse_UPC_12DigitNumber();
            var result = await _controller.Post(dataSetTest.GetFakeCreateItemRequest_UPC_12DigitNumber());

            Assert.AreEqual(expectedResult.ItemCost, result.ItemCost);
            Assert.AreEqual(expectedResult.ItemDescription, result.ItemDescription);
            Assert.AreEqual(expectedResult.ItemNumber, result.ItemNumber);
            Assert.AreEqual(expectedResult.MinimumOrderQuantity, result.MinimumOrderQuantity);
            Assert.AreEqual(expectedResult.PurchaseUnitOfMeasure, result.PurchaseUnitOfMeasure);
            Assert.AreEqual(expectedResult.UPC, result.UPC);
            Assert.AreEqual(expectedResult.VendorName, result.VendorName);
        }
    }
}
