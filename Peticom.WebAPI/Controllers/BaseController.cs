using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    /// <summary>
    /// This method is not an endpoint.
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public IActionResult CreateActionResult<T>(Response<T> response)
    {
        if (response.StatusCode == 204)
        {
            return new ObjectResult(null)
            {
                StatusCode = response.StatusCode
            };
        }

        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}