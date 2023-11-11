using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaginationAPI.Models;
using PaginationAPI.Models.Dto;
using PaginationAPI.Models.Entities;

namespace PaginationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NytaxiController : ControllerBase
    {
        private readonly NycTaxiContext context;

        public NytaxiController(NycTaxiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = context.NyTaxis.ToList();
            return Ok(data.Count);
        }

        [HttpGet]
        public IActionResult GetPaged([FromBody] PagedRequest request)  
        {
            var quary = from d in context.NyTaxis select d;

            return Ok(new PagedResponse<NyTaxi>(quary, request.PageIndex, request.PageSize, request.SortOrder));
        }
    }
}
