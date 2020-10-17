using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Emporos.API.Auth.Controllers.ModelView;
using Emporos.API.Auth.Domain.Contracts;
using FluentValidation.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Emporos.API.Auth.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IDomainService _domainService;
        private readonly IMapper _mapper;

        public AuthenticationController(ILogger<AuthenticationController> logger, IDomainService domainService, IMapper mapper)
        {
            _logger = logger;
            _domainService = domainService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a token for the user.
        /// </summary>
        /// <param name="request">Request with login and password of the user</param>
        /// <remarks>
        /// More elaborate description
        /// </remarks>
        /// <returns>
        /// Returns a token for the user.
        /// </returns>
        /// <response code="201">Returns the newly created token</response>
        /// <response code="204">If the response is null.</response>
        /// <response code="400">If there is any rule validation</response>
        /// <response code="500">If there is any exception type generated</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AuthenticationResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(AuthenticationResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AuthenticationResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(AuthenticationResponse))]
        [HttpPost("auth")]
        [AllowAnonymous]
        public async Task<AuthenticationResponse> Authenticate([FromBody]AuthenticationRequest request)
        {
            try
            {
                var data = await _domainService.GenerateJWToken(request.Login, request.Password);
                var result = _mapper.Map<AuthenticationResponse>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
