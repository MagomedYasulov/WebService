using Microsoft.AspNetCore.Mvc;
using WebService.Filters;

namespace WebService.Controllers
{
    [TypeFilter<ApiExceptionFilter>]
    public class BaseController : ControllerBase
    {

    }
}
