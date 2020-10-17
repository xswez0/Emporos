using AutoMapper;
using Emporos.API.Auth.Domain.UserAggregate;
using Emporos.API.Auth.Infraestructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Domain.Mappings
{
    public class DataMapping : Profile
    {
        public DataMapping()
        {
            CreateMap<UserEntity, UserTable>().ReverseMap();
            CreateMap<RoleEntity, RoleTable>().ReverseMap();
        }
    }
}
