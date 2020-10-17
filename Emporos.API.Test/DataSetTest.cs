using Emporos.API.Pharmacy.Controllers.ModelView;
using Emporos.API.Pharmacy.Domain.UserAggregate;
using Emporos.API.Pharmacy.Infraestructure.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emporos.API.Test
{
    public class DataSetTest
    {
        public CreatePharmacyInventoryRequest GetFakeCreatePharmacyInventoryRequest_QuantityOnHandNonZero()
        {
            var fake = new CreatePharmacyInventoryRequest()
            {
                IdItem = 1,
                IdPharmacy = 1,
                QuantityOnHand = 5,
                UnitPrice = 15.62M,
                ReorderQuantity = 12,
                SellingUnitOfMeasure = "KG"
            };

            return fake;
        }
        public CreatePharmacyInventoryResponse GetFakeCreatePharmacyInventoryResponse_QuantityOnHandNonZero()
        {
            var fake = new CreatePharmacyInventoryResponse()
            {
                QuantityOnHand = 5,
                UnitPrice = 15.62M,
                ReorderQuantity = 12,
                SellingUnitOfMeasure = "KG",
                UPC = "125698652100",
                VendorName = "VENDOR2",
                PharmacyName = "PHARMACY1",
                HospitalName = "HOSPITAL1"
            };
            return fake;
        }

        public PharmacyInventoryEntity GetFakePharmacyInventoryEntity_QuantityOnHandNonZero()
        {
            var fake = new PharmacyInventoryEntity()
            {
                Id=1,
                QuantityOnHand = 5,
                UnitPrice = 15.62M,
                ReorderQuantity = 12,
                SellingUnitOfMeasure = "KG",
                Item = new ItemEntity()
                {
                    Id = 1,
                    ItemNumber = 24156,
                    Vendor = new ItemVendorEntity()
                    {
                        Id = 2,
                        Name = "VENDOR2",
                        Address = "ADDRESSVENDOR2"
                    },
                    UPC= "125698652100",
                    ItemDescription = "NewItem1",
                    MinimumOrderQuantity = 10,
                    PurchaseUnitOfMeasure = "M3",
                    ItemCost = 10.34M,
                },
                Pharmacy = new PharmacyEntity()
                {
                    Id = 1,
                    Hospital = new HospitalEntity()
                    {
                        Id = 1,
                        Name = "HOSPITAL1",
                        Address = "HOSPITALADDRESS1"
                    },
                    Name = "PHARMACY1",
                    Address = "PHARMACYADDRESS1"
                }
            };

            return fake;
        }

        public UpdatePharmacyInventoryRequest GetFakeUpdatePharmacyInventoryRequest_QuantityOnHandNonZero()
        {
            var fake = new UpdatePharmacyInventoryRequest()
            {
                IdItem = 1,
                IdPharmacy = 1,
                QuantityOnHand = 10,
                UnitPrice = 65.62M,
                ReorderQuantity = 10,
                SellingUnitOfMeasure = "M3"
            };

            return fake;
        }

        public UpdatePharmacyInventoryResponse GetFakeUpdatePharmacyInventoryResponse_QuantityOnHandNonZero()
        {
            var fake = new UpdatePharmacyInventoryResponse()
            {
                Message = $"Record with Id: 1 sucessfully updated."
            };

            return fake;
        }

        public CreateItemRequest GetFakeCreateItemRequest_UPC_12DigitNumber()
        {
            var fake = new CreateItemRequest()
            {
                ItemNumber = 24516,
                IdVendor = 1,
                UPC = "025698652100",
                ItemDescription = "Item1",
                MinimumOrderQuantity = 12,
                PurchaseUnitOfMeasure = "KG",
                ItemCost = 12.34M
            };

            return fake;
        }

        public ItemEntity GetFakeItemEntity_UPC_12DigitNumber()
        {
            var fake = new ItemEntity()
            {
                Id = 1,
                ItemNumber = 24516,
                UPC = "025698652100",
                ItemDescription = "Item1",
                MinimumOrderQuantity = 12,
                PurchaseUnitOfMeasure = "KG",
                ItemCost = 12.34M,
                Vendor = new ItemVendorEntity()
                {
                    Id = 1,
                    Name = "VENDOR1",
                    Address = "ADDRESSVENDOR1"
                }
            };

            return fake;
        }

        public CreateItemResponse GetFakeCreateItemResponse_UPC_12DigitNumber()
        {
            var fake = new CreateItemResponse()
            {
                ItemNumber = 24516,
                UPC = "025698652100",
                ItemDescription = "Item1",
                MinimumOrderQuantity = 12,
                PurchaseUnitOfMeasure = "KG",
                ItemCost = 12.34M,
                VendorName = "VENDOR1"
            };

            return fake;
        }

        public UpdateItemRequest GetFakeUpdateItemRequest_UPC_12DigitNumber()
        {
            var fake = new UpdateItemRequest()
            {
                ItemNumber = 24156,
                IdVendor = 2,
                UPC = "125698652100",
                ItemDescription = "NewItem1",
                MinimumOrderQuantity = 10,
                PurchaseUnitOfMeasure = "M3",
                ItemCost = 10.34M
            };

            return fake;
        }
        public UpdateItemResponse GetFakeUpdateItemResponse_UPC_12DigitNumber()
        {
            var fake = new UpdateItemResponse()
            {
                Message = $"Record with Id: 1 sucessfully updated."
            };

            return fake;
        }

        public UpdatePharmacyInventoryRequest GetFakeUpdatePharmacyInventoryRequest_OnlyIf_Item_And_Pharmacy_Exists_Success()
        {
            var fake = new UpdatePharmacyInventoryRequest()
            {
                IdPharmacy = 1,
                IdItem = 1,
                QuantityOnHand = 12,
                UnitPrice = 65.62M,
                ReorderQuantity = 10,
                SellingUnitOfMeasure = "M3"
            };

            return fake;
        }

        public CreatePharmacyInventoryRequest GetFakeCreatePharmacyInventoryRequest_OnlyIf_Item_And_Pharmacy_Exists_Success()
        {
            var fake = new CreatePharmacyInventoryRequest()
            {
                IdItem = 1,
                IdPharmacy = 1,
                QuantityOnHand = 2,
                UnitPrice = 15.62M,
                ReorderQuantity = 12,
                SellingUnitOfMeasure = "KG"
            };

            return fake;
        }

        public CreatePharmacyInventoryResponse GetFakeCreatePharmacyInventoryResponse_OnlyIf_Item_And_Pharmacy_Exists_Success()
        {
            var fake = new CreatePharmacyInventoryResponse()
            {
                QuantityOnHand = 2,
                UnitPrice = 15.62M,
                ReorderQuantity = 12,
                SellingUnitOfMeasure = "KG",
                UPC = "125698652100",
                VendorName = "VENDOR2",
                PharmacyName = "PHARMACY1",
                HospitalName = "HOSPITAL1"
            };

            return fake;
        }

        public PharmacyInventoryEntity GetFakePharmacyInventoryEntity_OnlyIf_Item_And_Pharmacy_Exists_Success()
        {
            var fake = new PharmacyInventoryEntity()
            {
                Id = 1,
                QuantityOnHand = 2,
                UnitPrice = 15.62M,
                ReorderQuantity = 12,
                SellingUnitOfMeasure = "KG",
                Item = new ItemEntity()
                {
                    Id = 1,
                    ItemNumber = 24156,
                    Vendor = new ItemVendorEntity()
                    {
                        Id = 2,
                        Name = "VENDOR2",
                        Address = "ADDRESSVENDOR2"
                    },
                    UPC = "125698652100",
                    ItemDescription = "NewItem1",
                    MinimumOrderQuantity = 10,
                    PurchaseUnitOfMeasure = "M3",
                    ItemCost = 10.34M,
                },
                Pharmacy = new PharmacyEntity()
                {
                    Id = 1,
                    Hospital = new HospitalEntity()
                    {
                        Id = 1,
                        Name = "HOSPITAL1",
                        Address = "HOSPITALADDRESS1"
                    },
                    Name = "PHARMACY1",
                    Address = "PHARMACYADDRESS1"
                }
            };

            return fake;
        }

        public PharmacyTable FakePharmacyTable1()
        {
            var fake = new PharmacyTable()
            {
                Id = 1,
                IdHospital = 1,
                Address = "PHARMACYADDRESS1",
                Name = "PHARMACY1"
            };

            return fake;
        }

        public ItemTable FakeItemTable1()
        {
            var fake = new ItemTable()
            {
                Id = 1,
                IdVendor = 1,
                ItemCost = 10.34M,
                ItemDescription = "NewItem1",
                ItemNumber = 24156,
                UPC = "125698652100",
                MinimumOrderQuantity = 10,
                PurchaseUnitOfMeasure = "M3"
            };
            return fake;
        }

        public ItemVendorTable FakeItemVendorTable1()
        {
            var fake = new ItemVendorTable()
            {
                Id = 1,
                Name = "VENDOR1",
                Address = "ADDRESSVENDOR1"
            };

            return fake;
        }

        public ItemVendorTable FakeItemVendorTable2()
        {
            var fake = new ItemVendorTable()
            {
                Id = 2,
                Name = "VENDOR2",
                Address = "ADDRESSVENDOR2"
            };

            return fake;
        }

        public HospitalTable FakeHospitalTable1()
        {
            var fake = new HospitalTable()
            {
                Id = 1,
                Name = "HOSPITAL1",
                Address = "HOSPITALADDRESS1"
            };

            return fake;
        }

        public PharmacyInventoryTable FakePharmacyInventoryTable1()
        {
            var fake = new PharmacyInventoryTable()
            {
                Id = 1,
                IdItem = 1,
                IdPharmacy = 1,
                QuantityOnHand = 2,
                UnitPrice = 15.62M,
                ReorderQuantity = 12,
                SellingUnitOfMeasure = "KG"
            };
            return fake;
        }
    }
}
