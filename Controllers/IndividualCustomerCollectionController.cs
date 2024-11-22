using Electrolux.Api.ODataApi.Enum;
using Electrolux.Api.ODataApi.Model.Customer;
using Electrolux.Api.ODataApi.OData;
using Electrolux.Api.ODataApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Options;
using Microsoft.OData.UriParser;

namespace Electrolux.Api.ODataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IndividualCustomerCollectionController : ControllerBase
    {
        private readonly IIndividualCustomerService _individualCustomerService;
        public IndividualCustomerCollectionController(IIndividualCustomerService individualCustomerService)
        {
            _individualCustomerService = individualCustomerService;
        }


        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<IndividualCustomer>>> GetIndividualCustomerCollection(ODataQueryOptions<IndividualCustomer> queryOptions)
        {
            var filter = queryOptions.Filter?.RawValue;
            if (string.IsNullOrEmpty(filter))
            {
                return BadRequest("No filter provided");
            }

            try
            {
                var result = await _individualCustomerService.GetIndividualCustomerCollectionByFilter(queryOptions);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }



        
    }
}
