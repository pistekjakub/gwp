using gwp.Models;
using gwp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gwp.Controllers
{
    [Route("server/api/[controller]")]
    [ApiController]
    public class GwpController : Controller
    {
        private readonly IAvgService _vgService;

        public GwpController(IAvgService vgService)
        {
            _vgService = vgService;
        }

        [HttpPost("avg")]
        public ActionResult<Dictionary<string, double>> Avg([FromBody] AvgRequest request)
        {
            var result = new Dictionary<string, double>();
            foreach (var item in _vgService.GetAvgItems(request.Country, request.Lob)) 
            {
                result.Add(item.Key, item.Value);
            }
            return Ok(result);
        }
    }
}
