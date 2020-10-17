using Emporos.API.Auth.Domain.Internal;
using Emporos.API.Auth.Domain.UserAggregate;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Domain.Contracts
{
    public interface IDomainService
    {
        public Task<UserEntity> QueryUser(string Login);
        public Task<AuthenticationToken> GenerateJWToken(string Login, string Password);
    }
}
