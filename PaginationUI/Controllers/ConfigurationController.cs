using Microsoft.AspNetCore.Mvc;

namespace PaginationUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : Controller
    {
        private readonly IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetApiUrls")]
        public IActionResult GetApiUrls()
        {
            var apiUrls = new
            {
                GetPaged = _configuration["ApiUrls:GetPaged"],
                SearchWithPagedByMedallion = _configuration["ApiUrls:SearchWithPagedByMedallion"]
            };

            return Ok(apiUrls);
        }
    }
}
