using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedisMasterSlave.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisMasterSlave.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CacheController : ControllerBase
    {
      
        private readonly ICacheService _cacheService;

        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("cache/{key}")]
        public async Task<IActionResult> GetCacheValue([FromRoute] string key)
        {
            var value = await _cacheService.GetCacheValueAsync(key);
            return string.IsNullOrEmpty(value) ? (IActionResult) NotFound() : Ok(value);
           
        }
        [HttpPost ("cache")]
        public async Task<IActionResult> SetCacheValue([FromBody] NewCacheRequest request)
        {
            await _cacheService.SetCacheValueAsync(request.key,request.value);
            return Ok();
        }
    }

    public class NewCacheRequest
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
