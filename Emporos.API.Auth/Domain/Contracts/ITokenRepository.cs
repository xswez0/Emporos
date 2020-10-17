using Emporos.API.Auth.Domain.Internal;
using Emporos.API.Auth.Infraestructure.DataModel;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Domain.Contracts
{
    public interface ITokenRepository : IRepository<TokenTable>
    {
        
    }
}
