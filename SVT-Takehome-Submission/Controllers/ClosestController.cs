using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SVT_Takehome_Submission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVT_Takehome_Submission.Controllers
{
    [Route("api/robots/[controller]")]
    [ApiController]
    public class ClosestController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(Load load)
        {
            return Ok(load);
        }
    }
}
