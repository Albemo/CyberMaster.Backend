using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberMaster.Backend.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[Controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}
