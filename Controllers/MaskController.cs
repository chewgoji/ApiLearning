using ApiLearning.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiLearning.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class MaskController : ControllerBase
    {
        private readonly MaskService _maskService;

        public MaskController(MaskService maskService)
        {
            _maskService = maskService;
        }

        /*public async Task<IActionResult> Get()
        {
            try
            {
                var maskCount = await _maskService.GetMaskInfo();
                return Ok(maskCount);
            }
            catch (HttpRequestException ex)
            {
                return Problem(ex.Message);
            }
        }*/

        [Route("[controller]/{address}")]
        public async Task<IActionResult> Search(string address)
        {
            var maskCount = await _maskService.GetMaskInfo();

            if (!string.IsNullOrEmpty(address))
            {
                maskCount = maskCount.Where(x => x.醫事機構地址.Contains(address));
            }

            return Ok(maskCount);
        }
    }
}
