using AutoMapper;
using Emporos.API.Pharmacy.Common.Settings;
using Emporos.API.Pharmacy.Controllers.ModelView;
using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Domain.UserAggregate;
using Emporos.API.Pharmacy.Infraestructure.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Domain.Internal
{
    public class DomainService : IDomainService
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly IItemVendorRepository _itemVendorRepository;
        private readonly IPharmacyRepository _pharmacyRepository;
        private readonly IPharmacyInventoryRepository _pharmacyInventoryRepository;
        private readonly IHospitalRepository _hospitalRepository;

        public DomainService(IMapper mapper, IItemRepository itemRepository, IItemVendorRepository itemVendorRepository
            , IPharmacyRepository pharmacyRepository, IPharmacyInventoryRepository pharmacyInventoryRepository, IHospitalRepository hospitalRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _itemVendorRepository = itemVendorRepository;
            _pharmacyRepository = pharmacyRepository;
            _pharmacyInventoryRepository = pharmacyInventoryRepository;
            _hospitalRepository = hospitalRepository;
        }
        public async Task<PharmacyInventoryEntity> CreatePharmacyInventory(CreatePharmacyInventoryRequest createPharmacyInventoryRequest)
        {
            PharmacyInventoryEntity pharmacyInventoryReturn = null;
            try
            {
                var itemExists = await CheckIfItemExists(createPharmacyInventoryRequest.IdItem);
                if (itemExists)
                {
                    var pharmacyExists = await CheckIfPharmacyExists(createPharmacyInventoryRequest.IdPharmacy);
                    if (pharmacyExists)
                    {
                        var pharmacyInventoryTable = _mapper.Map<PharmacyInventoryTable>(createPharmacyInventoryRequest);
                        
                        var id = await CreatePharmacyInventoryTable(pharmacyInventoryTable);

                        if(id > 0)
                        {
                            var pharmacyInventoryTableRecovered = await GetPharmacyInventoryTableById(id);
                            var itemTableRecovered = await GetItemTableById(pharmacyInventoryTableRecovered.IdItem);
                            var vendorTableRecovered = await GetVendorTableById(itemTableRecovered.IdVendor);
                            var pharmacyTableRecovered = await GetPharmacyTableById(pharmacyInventoryTableRecovered.IdPharmacy);
                            var hospitalTableRecovered = await GetHospitalTableById(pharmacyTableRecovered.IdHospital);
                            
                            var pharmacyInventory = _mapper.Map<PharmacyInventoryEntity>(pharmacyInventoryTableRecovered);
                            var item = _mapper.Map<ItemEntity>(itemTableRecovered);
                            var vendor = _mapper.Map<ItemVendorEntity>(vendorTableRecovered);
                            var pharmacy = _mapper.Map<PharmacyEntity>(pharmacyTableRecovered);
                            var hospital = _mapper.Map<HospitalEntity>(hospitalTableRecovered);
                            item.Vendor = vendor;
                            pharmacy.Hospital = hospital;
                            pharmacyInventory.Item = item;
                            pharmacyInventory.Pharmacy = pharmacy;

                            pharmacyInventoryReturn = pharmacyInventory;
                        }
                    }
                    else
                    {
                        throw new Exception("Pharmacy doesn't exists.");
                    }
                }
                else
                {
                    throw new Exception("Item doesn't exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return pharmacyInventoryReturn;
        }

        public async Task<bool> UpdatePharmacyInventory(long id, UpdatePharmacyInventoryRequest updatePharmacyInventoryRequest)
        {
            bool resp;
            try
            {
                var itemExists = await CheckIfItemExists(updatePharmacyInventoryRequest.IdItem);
                if (itemExists)
                {
                    var pharmacyExists = await CheckIfPharmacyExists(updatePharmacyInventoryRequest.IdPharmacy);
                    if (pharmacyExists)
                    {
                        var pharmacyInventoryTable = _mapper.Map<PharmacyInventoryTable>(updatePharmacyInventoryRequest);
                        pharmacyInventoryTable.Id = id;
                        resp = await UpdatePharmacyInventoryTable(pharmacyInventoryTable);
                    }
                    else
                    {
                        throw new Exception("Pharmacy doesn't exists.");
                    }
                }
                else
                {
                    throw new Exception("Item doesn't exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resp;
        }

        public async Task<bool> DeletePharmacyInventory(long id)
        {
            bool resp;
            try
            {
                if (id <= 0L)
                {
                    throw new Exception("Id of pharmacy inventory must be greater than zero.");
                }

                resp = await DeletePharmacyInventoryTable(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resp;
        }
        public async Task<ItemEntity> CreateItem(CreateItemRequest createItemRequest)
        {
            ItemEntity itemReturn = null;
            try
            {
                var dataVendorExists = await CheckIfVendorExists(createItemRequest.IdVendor);
                if (dataVendorExists)
                {
                    var vendorTable = await GetVendorTableById(createItemRequest.IdVendor);
                    if (vendorTable != null)
                    {
                        var itemTable = _mapper.Map<ItemTable>(createItemRequest);

                        var id = await CreateItemTable(itemTable);

                        if (id > 0)
                        {
                            var itemTableRecovered = await GetItemTableById(id);
                            var item = _mapper.Map<ItemEntity>(itemTableRecovered);
                            var vendor = _mapper.Map<ItemVendorEntity>(vendorTable);
                            item.Vendor = vendor;
                            itemReturn = item;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return itemReturn;
        }

        public async Task<bool> UpdateItem(long id, UpdateItemRequest updateItemRequest)
        {
            bool resp;
            try
            {
                if (id <= 0L)
                {
                    throw new Exception("Id of item must be greater than zero.");
                }

                var dataVendorExists = await CheckIfVendorExists(updateItemRequest.IdVendor);
                if (dataVendorExists)
                {
                    var itemTable = _mapper.Map<ItemTable>(updateItemRequest);
                    itemTable.Id = id;
                    resp = await UpdateItemTable(itemTable);
                }
                else
                {
                    throw new Exception("ItemVendor doesn't exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resp;
        }

        private async Task<bool> CheckIfVendorExists(long id)
        {
            try
            {
                return await _itemVendorRepository.ExistAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async Task<bool> CheckIfItemExists(long id)
        {
            try
            {
                var x = await _itemRepository.ExistAsync(id);
                return x;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async Task<bool> CheckIfPharmacyExists(long id)
        {
            try
            {
                return await _pharmacyRepository.ExistAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<ItemVendorTable> GetVendorTableById(long id)
        {
            try
            {
                return await _itemVendorRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async Task<HospitalTable> GetHospitalTableById(long id)
        {
            try
            {
                return await _hospitalRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<PharmacyTable> GetPharmacyTableById(long id)
        {
            try
            {
                return await _pharmacyRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async Task<ItemTable> GetItemTableById(long id)
        {
            try
            {
                return await _itemRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<PharmacyInventoryTable> GetPharmacyInventoryTableById(long id)
        {
            try
            {
                return await _pharmacyInventoryRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<long> CreateItemTable(ItemTable itemTable)
        {
            try
            {
                return await _itemRepository.CreateAsync(itemTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<long> CreatePharmacyInventoryTable(PharmacyInventoryTable pharmacyInventoryTableTable)
        {
            try
            {
                return await _pharmacyInventoryRepository.CreateAsync(pharmacyInventoryTableTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> UpdateItemTable(ItemTable itemTable)
        {
            try
            {
                return await _itemRepository.UpdateAsync(itemTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async Task<bool> UpdatePharmacyInventoryTable(PharmacyInventoryTable pharmacyInventoryTable)
        {
            try
            {
                return await _pharmacyInventoryRepository.UpdateAsync(pharmacyInventoryTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> DeletePharmacyInventoryTable(long id)
        {
            try
            {
                return await _pharmacyInventoryRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
