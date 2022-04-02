using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserTestController : ControllerBase
    {
        private readonly ILogger<UserTestController> _logger;
        IUserTestService _userTestService;



        public UserTestController(IUserTestService userTestService, ILogger<UserTestController> logger)
        {
           
            _userTestService = userTestService;
            _logger = logger;

        }




        //public ActionResult GetUser()
        //{
        //    var userName = User.Identity.Name;




        [HttpPost]
        public IActionResult Post(UserTest userTest)
        {


            var userName = HttpContext.User.Identity.Name;
            userTest.Department = userName;

            //var userName=User.Identity?.Name;

            var result = _userTestService.Add(userTest);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
        }


        [HttpPut]

        public IActionResult Put(UserTest userTest)
        {
            var result = _userTestService.Update(userTest);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet]
        public IActionResult Get()
        {


            var result = _userTestService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
