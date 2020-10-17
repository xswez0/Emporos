using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Emporos.API.Pharmacy.Controllers.ModelView;
using Emporos.API.Pharmacy.Domain.Contracts;
using FluentValidation.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Emporos.API.Pharmacy.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "USER")]
    public class ItemController : Controller
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IDomainService _domainService;
        private readonly IMapper _mapper;

        public ItemController(ILogger<ItemController> logger, IDomainService domainService, IMapper mapper)
        {
            _logger = logger;
            _domainService = domainService;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a item of given vendor.
        /// </summary>
        /// <param name="request">Information to create item</param>
        /// <remarks>
        /// More elaborate description
        /// </remarks>
        /// <returns>
        /// Returns status request 201 created.
        /// </returns>
        /// <response code="201">Returns the status created</response>
        /// <response code="204">If the response is null.</response>
        /// <response code="400">If there is any rule validation</response>
        /// <response code="500">If there is any exception type generated</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateItemResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CreateItemResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateItemResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CreateItemResponse))]
        [HttpPost]
        public async Task<CreateItemResponse> Post([FromBody] CreateItemRequest request)
        {
            CreateItemResponse createItemResponse = null;
            var pattern = @"^(?:\d{12})$";
            try
            {
                if (!Regex.IsMatch(request.UPC, pattern))
                {
                    throw new Exception("UPC must be 12 digit number.");
                }

                var item = await _domainService.CreateItem(request);

                if (item != null)
                {
                    createItemResponse = _mapper.Map<CreateItemResponse>(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return createItemResponse;
        }

        /// <summary>
        /// Updates a item of given vendor.
        /// </summary>
        /// <param name="request">Information to update item</param>
        /// <param name="id">Id from the item</param>
        /// <remarks>
        /// More elaborate description
        /// </remarks>
        /// <returns>
        /// Returns status request 200 ok.
        /// </returns>
        /// <response code="200">Returns the status updated ok</response>
        /// <response code="400">If there is any rule validation</response>
        /// <response code="404">If the item id is not found</response>
        /// <response code="500">If there is any exception type generated</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateItemResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdateItemResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(UpdateItemResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(UpdateItemResponse))]
        [Route("{id:long}")]
        [HttpPut]
        public async Task<UpdateItemResponse> Put([FromBody] UpdateItemRequest request, long id = 0)
        {
            UpdateItemResponse updateItemResponse;
            var pattern = @"^(?:\d{12})$";
            try
            {
                if (!Regex.IsMatch(request.UPC, pattern))
                {
                    throw new Exception("UPC must be 12 digit number.");
                }

                var resp = await _domainService.UpdateItem(id, request);

                if (resp)
                {
                    updateItemResponse = new UpdateItemResponse()
                    {
                        Message = $"Record with Id: {id} sucessfully updated."
                    };
                }
                else
                {
                    updateItemResponse = new UpdateItemResponse()
                    {
                        Message = $"Record with Id: {id} does not exist."
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return updateItemResponse;
        }
    }
}
