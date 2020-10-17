using Emporos.API.Pharmacy.Controllers.ModelView;
using Emporos.API.Pharmacy.Domain.Internal;
using Emporos.API.Pharmacy.Domain.UserAggregate;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Domain.Contracts
{
    public interface IDomainService
    {
        public Task<ItemEntity> CreateItem(CreateItemRequest createItemRequest);
        public Task<bool> UpdateItem(long id, UpdateItemRequest updateItemRequest);
        public Task<PharmacyInventoryEntity> CreatePharmacyInventory(CreatePharmacyInventoryRequest createPharmacyInventoryRequest);
        public Task<bool> UpdatePharmacyInventory(long id, UpdatePharmacyInventoryRequest updatePharmacyInventoryRequest);
        public Task<bool> DeletePharmacyInventory(long id);
    }
}
