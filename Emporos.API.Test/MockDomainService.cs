using Emporos.API.Pharmacy.Controllers.ModelView;
using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emporos.API.Test
{
    public class MockDomainService : IDomainService
    {
        private DataSetTest DataSetTest;
        public MockDomainService()
        {
            DataSetTest = new DataSetTest();
        }
        public async Task<ItemEntity> CreateItem(CreateItemRequest createItemRequest)
        {
            return await Task.FromResult(DataSetTest.GetFakeItemEntity_UPC_12DigitNumber());
        }

        public async Task<PharmacyInventoryEntity> CreatePharmacyInventory(CreatePharmacyInventoryRequest createPharmacyInventoryRequest)
        {
            return await Task.FromResult(DataSetTest.GetFakePharmacyInventoryEntity_QuantityOnHandNonZero());
        }

        public Task<bool> DeletePharmacyInventory(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(long id, UpdateItemRequest updateItemRequest)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePharmacyInventory(long id, UpdatePharmacyInventoryRequest updatePharmacyInventoryRequest)
        {
            return await Task.FromResult(true);
        }
    }
}
