using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Common;
using NewsApi.Dapper.Entities;
using NewsApi.Dapper.IRepository;

namespace NewsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    //[ApiController]
    public class UsersController : Controller
    {

        private readonly IUserRepository userRepository;
        public UsersController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<JsonResult> GetUsers()
        {
            List<Users> list = await userRepository.GetUsers();
            return Json(list);
        }
    }

}