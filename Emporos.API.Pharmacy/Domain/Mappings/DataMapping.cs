using AutoMapper;
using Emporos.API.Pharmacy.Controllers.ModelView;
using Emporos.API.Pharmacy.Domain.UserAggregate;
using Emporos.API.Pharmacy.Infraestructure.DataModel;

namespace Emporos.API.Pharmacy.Domain.Mappings
{
    public class DataMapping : Profile
    {
        public DataMapping()
        {
            CreateMap<CreateItemRequest, ItemTable>().ReverseMap();
            CreateMap<ItemVendorTable, ItemVendorEntity>().ReverseMap();
            CreateMap<ItemTable, ItemEntity>().ReverseMap();
            CreateMap<UpdateItemRequest, ItemTable>().ReverseMap();
            CreateMap<CreatePharmacyInventoryRequest, PharmacyInventoryTable>().ReverseMap();
            CreateMap<PharmacyInventoryTable, PharmacyInventoryEntity>().ReverseMap();
            CreateMap<PharmacyTable, PharmacyEntity>().ReverseMap();
            CreateMap<HospitalTable, HospitalEntity>().ReverseMap();
            CreateMap<UpdatePharmacyInventoryRequest, PharmacyInventoryTable>().ReverseMap();
        }
    }
}
