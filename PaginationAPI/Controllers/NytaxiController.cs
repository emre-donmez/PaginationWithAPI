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
        public IActionResult GetPaged(int pageIndex, int pageSize, string sortOrder)  
        {
            var query = from d in context.NyTaxis select d;

            return Ok(new PagedResponse<NyTaxi>(query, pageIndex, pageSize, sortOrder));
        }

        [HttpGet]
        public IActionResult SearchWithPagedByMedallion(int pageIndex, int pageSize, string searchParameter, string? sortOrder)
        {
            var query = from d in context.NyTaxis
                        where d.Medallion.Contains(searchParameter)
                        select d;
            
            return Ok(new PagedResponse<NyTaxi>(query, pageIndex, pageSize, sortOrder));
        }
    }
}
