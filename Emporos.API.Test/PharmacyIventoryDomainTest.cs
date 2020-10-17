using AutoMapper;
using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Domain.Internal;
using Emporos.API.Pharmacy.Domain.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Emporos.API.Test
{
    [TestClass]
    public class PharmacyIventoryDomainTest
    {
        private IMapper _mapper;
        private IItemRepository _itemRepository;
        private IItemVendorRepository _itemVendorRepository;
        private IPharmacyRepository _pharmacyRepository;
        private IPharmacyInventoryRepository _pharmacyInventoryRepository;
        private IHospitalRepository _hospitalRepository;
        private IConfiguration _configuration;
        private ILogger _logger;
        private IDomainService _domainService;
        private DataSetTest dataSetTest;

        [TestInitialize]
        public void Initialize()
        {
            dataSetTest = new DataSetTest();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new DataMapping()));
            _mapper = new Mapper(mapperConfig);

            _configuration = new MockConfiguration();
            _logger = new MockLogger();

            _itemRepository = new MockItemRepository(_configuration, _logger);
            _itemVendorRepository = new MockItemVendorRepository(_configuration, _logger);
            _pharmacyRepository = new MockPharmacyRepository(_configuration, _logger);
            _pharmacyInventoryRepository = new MockPharmacyInventoryRepository(_configuration, _logger);
            _hospitalRepository = new MockHospitalRepository(_configuration, _logger);

            _domainService = new DomainService(_mapper, _itemRepository, _itemVendorRepository, _pharmacyRepository, _pharmacyInventoryRepository, _hospitalRepository);
        }
        [TestMethod]
        public async Task CreatePharmacyInventory_OnlyIf_Item_And_Pharmacy_Exists_Success()
        {
            var request = dataSetTest.GetFakeCreatePharmacyInventoryRequest_OnlyIf_Item_And_Pharmacy_Exists_Success();
            var result = await _domainService.CreatePharmacyInventory(request);
            
            Assert.IsTrue(result.Id > 0);
        }
        [TestMethod]
        public async Task UpdatePharmacyInventory_OnlyIf_Item_And_Pharmacy_Exists_Success()
        {
            var expectedResult = true;
            var request = dataSetTest.GetFakeUpdatePharmacyInventoryRequest_OnlyIf_Item_And_Pharmacy_Exists_Success();
            var result = await _domainService.UpdatePharmacyInventory(1, request);

            Assert.IsTrue(result == expectedResult);
        }
    }
}
