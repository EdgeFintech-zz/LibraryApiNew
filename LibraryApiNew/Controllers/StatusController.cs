using Microsoft.AspNetCore.Mvc;

namespace LibraryApiNew.Controllers
{
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet("/")]
        public ActionResult Get()
        {
            return Ok(new {status = "Ok"});
        }
    }
}