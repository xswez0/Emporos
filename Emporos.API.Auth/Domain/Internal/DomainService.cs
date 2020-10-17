using AutoMapper;
using Emporos.API.Auth.Common.Settings;
using Emporos.API.Auth.Domain.Contracts;
using Emporos.API.Auth.Domain.UserAggregate;
using Emporos.API.Auth.Infraestructure.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Domain.Internal
{
    public class DomainService : IDomainService
    {
        private readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IRoleRepository _roleRepository;

        public DomainService(IMapper mapper, IOptions<AppSettings> appSettings, IUserRepository userRepository, ITokenRepository tokenRepository, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _appSettings = appSettings;
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _roleRepository = roleRepository;
        }
        public async Task<AuthenticationToken> GenerateJWToken(string Login, string Password)
        {
            AuthenticationToken authenticationToken = null;
            try
            {
                var user = await QueryUser(Login);

                if (user != null)
                {
                    if (EncryptPassword(Password).Equals(user.Password))
                    {
                        var tokenString = JWTTokenGenerator.GenerateToken(user, _appSettings);

                        TokenTable tokenTable = new TokenTable()
                        {
                            CreatedOn = DateTime.Now,
                            ExpiresOn = DateTime.Now.AddMinutes(30),
                            Guid = Guid.NewGuid().ToString().Trim(),
                            IdUser = user.Id,
                            AccessToken = tokenString
                        };

                        var id = await _tokenRepository.CreateAsync(tokenTable);

                        if (id > 0)
                        {
                            authenticationToken = new AuthenticationToken()
                            {
                                AccessToken = tokenString,
                                ExpiresOn = tokenTable.ExpiresOn
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return authenticationToken;
        }

        public async Task<UserEntity> QueryUser(string Login)
        {
            try
            {
                var data = await _userRepository.GetByLoginAsync(Login);
                var roles = await _roleRepository.GetByLoginAsync(Login);
                data.UserRoles = roles.ToList();
                var users = _mapper.Map<UserEntity>(data);

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        private string EncryptPassword(string Password) => Password; //TODO: implement algorithm
    }
}
