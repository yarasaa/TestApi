using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class IKDbController : ControllerBase
    {
        IUserService _userService;
        

        public IKDbController(IUserService userService)
        {
            _userService = userService;
        }


        
        [HttpGet]
        //[Produces("application/json")]
        public IActionResult Get(string sicilNo)
        {


            var result = _userService.GetAll(sicilNo);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
