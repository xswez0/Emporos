using AutoMapper;
using Emporos.API.Pharmacy.Controllers.ModelView;
using Emporos.API.Pharmacy.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Controllers.Mappings
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ItemEntity, CreateItemResponse>()
                .ForMember(dest => dest.ItemCost, act => act.MapFrom(src => src.ItemCost))
                .ForMember(dest => dest.ItemDescription, act => act.MapFrom(src => src.ItemDescription))
                .ForMember(dest => dest.ItemNumber, act => act.MapFrom(src => src.ItemNumber))
                .ForMember(dest => dest.MinimumOrderQuantity, act => act.MapFrom(src => src.MinimumOrderQuantity))
                .ForMember(dest => dest.PurchaseUnitOfMeasure, act => act.MapFrom(src => src.PurchaseUnitOfMeasure))
                .ForMember(dest => dest.UPC, act => act.MapFrom(src => src.UPC))
                .ForMember(dest => dest.VendorName, act => act.MapFrom(src => src.Vendor.Name));

            CreateMap<PharmacyInventoryEntity, CreatePharmacyInventoryResponse>()
                .ForMember(dest => dest.HospitalName, act => act.MapFrom(src => src.Pharmacy.Hospital.Name))
                .ForMember(dest => dest.PharmacyName, act => act.MapFrom(src => src.Pharmacy.Name))
                .ForMember(dest => dest.QuantityOnHand, act => act.MapFrom(src => src.QuantityOnHand))
                .ForMember(dest => dest.ReorderQuantity, act => act.MapFrom(src => src.ReorderQuantity))
                .ForMember(dest => dest.UnitPrice, act => act.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.SellingUnitOfMeasure, act => act.MapFrom(src => src.SellingUnitOfMeasure))
                .ForMember(dest => dest.UPC, act => act.MapFrom(src => src.Item.UPC))
                .ForMember(dest => dest.VendorName, act => act.MapFrom(src => src.Item.Vendor.Name));
        }
    }
}
