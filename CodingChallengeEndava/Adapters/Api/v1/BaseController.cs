using Microsoft.AspNetCore.Mvc;

namespace CodingChallengeEndava.Adapters.Api.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}
