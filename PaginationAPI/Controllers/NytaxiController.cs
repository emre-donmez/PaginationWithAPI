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
        private readonly NycTaxiContext _context;

        public NytaxiController(NycTaxiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.NyTaxis.ToList();
            return Ok(data.Count);
        }

        [HttpGet]
        public IActionResult GetPaged(int pageIndex, int pageSize, string sortOrder)
        {
            var query = from d in _context.NyTaxis select d;

            return Ok(new PagedResponse<NyTaxi>(query, pageIndex, pageSize, sortOrder));
        }

        [HttpGet]
        public IActionResult SearchWithPagedByMedallion(int pageIndex, int pageSize, string searchParameter, string? sortOrder)
        {
            var query = from d in _context.NyTaxis
                        where d.Medallion.Contains(searchParameter)
                        select d;

            return Ok(new PagedResponse<NyTaxi>(query, pageIndex, pageSize, sortOrder));
        }
    }
}