using System;
using System.Threading.Tasks;
using AutoMapper;
using Emporos.API.Pharmacy.Controllers.ModelView;
using Emporos.API.Pharmacy.Domain.Contracts;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Emporos.API.Pharmacy.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class PharmacyInventoryController : Controller
    {
        private readonly ILogger<PharmacyInventoryController> _logger;
        private readonly IDomainService _domainService;
        private readonly IMapper _mapper;

        public PharmacyInventoryController(ILogger<PharmacyInventoryController> logger, IDomainService domainService, IMapper mapper)
        {
            _logger = logger;
            _domainService = domainService;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a pharmacy inventory.
        /// </summary>
        /// <param name="request">Information to create pharmacy inventory</param>
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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreatePharmacyInventoryResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CreatePharmacyInventoryResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreatePharmacyInventoryResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CreatePharmacyInventoryResponse))]
        [HttpPost]
        public async Task<CreatePharmacyInventoryResponse> Post([FromBody] CreatePharmacyInventoryRequest request)
        {
            CreatePharmacyInventoryResponse createPharmacyInventoryResponse = null;
            try
            {
                if (request.QuantityOnHand <= 0)
                {
                    throw new Exception($"QuantityOnHand must be non zero.");
                }

                var item = await _domainService.CreatePharmacyInventory(request);
                if (item != null)
                {
                    createPharmacyInventoryResponse = _mapper.Map<CreatePharmacyInventoryResponse>(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return createPharmacyInventoryResponse;
        }

        /// <summary>
        /// Updates pharmacy inventory.
        /// </summary>
        /// <param name="request">Information to update pharmacy inventory</param>
        /// <param name="id">Id from the pharmacy inventory</param>
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatePharmacyInventoryResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdatePharmacyInventoryResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(UpdatePharmacyInventoryResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(UpdatePharmacyInventoryResponse))]
        [Route("{id:long}")]
        [HttpPut]
        public async Task<UpdatePharmacyInventoryResponse> Put([FromBody] UpdatePharmacyInventoryRequest request, long id = 0)
        {
            UpdatePharmacyInventoryResponse updatePharmacyInventoryResponse;
            try
            {
                if (id <= 0L)
                {
                    throw new Exception("Id of item must be greater than zero.");
                }

                if (request.QuantityOnHand <= 0)
                {
                    throw new Exception($"QuantityOnHand must be non zero.");
                }

                var resp = await _domainService.UpdatePharmacyInventory(id, request);

                if (resp)
                {
                    updatePharmacyInventoryResponse = new UpdatePharmacyInventoryResponse()
                    {
                        Message = $"Record with Id: {id} sucessfully updated."
                    };
                }
                else
                {
                    throw new ProblemDetailsException(StatusCodes.Status404NotFound, $"Record with Id: {id} does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return updatePharmacyInventoryResponse;
        }

        /// <summary>
        /// Deletes pharmacy inventory.
        /// </summary>
        /// <param name="id">Id from the pharmacy inventory</param>
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeletePharmacyInventoryResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DeletePharmacyInventoryResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DeletePharmacyInventoryResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(DeletePharmacyInventoryResponse))]
        [Route("{id:long}")]
        [HttpDelete]
        public async Task<DeletePharmacyInventoryResponse> Delete(long id = 0)
        {
            DeletePharmacyInventoryResponse deletePharmacyInventoryResponse;
            try
            {
                var resp = await _domainService.DeletePharmacyInventory(id);

                if (resp)
                {
                    deletePharmacyInventoryResponse = new DeletePharmacyInventoryResponse()
                    {
                        Message = $"Record with Id: {id} sucessfully deleted."
                    };
                }
                else
                {
                    throw new ProblemDetailsException(StatusCodes.Status404NotFound, $"Record with Id: {id} does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return deletePharmacyInventoryResponse;
        }
    }
}
