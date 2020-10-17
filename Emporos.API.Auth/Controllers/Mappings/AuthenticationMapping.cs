using AutoMapper;
using Emporos.API.Auth.Controllers.ModelView;
using Emporos.API.Auth.Domain.Internal;

namespace Emporos.API.Auth.Controllers.Mappings
{
    public class AuthenticationMapping : Profile
    {
        public AuthenticationMapping()
        {
            CreateMap<AuthenticationToken, AuthenticationResponse>().ReverseMap();
        }
    }
}
