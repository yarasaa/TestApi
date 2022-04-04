using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoAddController : ControllerBase
    {
        IUserInfoService _userInfoService;
        public UserInfoAddController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;

        }


        [HttpPost]
        public IActionResult Post(UserInfo userInfo)
        {

            //var userName = HttpContext.User.Identity.Name;
            
            var result = _userInfoService.Add(userInfo);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
        }




        [HttpGet]

        public IActionResult Get(string sicilNo)
        {
            var result=_userInfoService.GetAll(sicilNo);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
