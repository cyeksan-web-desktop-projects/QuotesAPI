using CansuAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserDataAccess;
using System.Data;
namespace CansuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /*public List<User> users = new List<User>() {
            

            new User { Name = "Cansu Aktas", Email = "cansu.aktas@huawei.com", Password = "123456" }

        };*/

        public List<User> users = new List<User>();

        [HttpGet]
        public ActionResult<List<User>> GetAllList()
        {
            using (MVVMDemoEntities entities = new MVVMDemoEntities()) {
                users = entities.Users.ToList();
                return users;
            };

        }

        /*[HttpGet("{id}")]
        public ActionResult<User> GetPerson(int id)
        {

            var user = users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }*/

        [HttpPost]
        public ActionResult<LoginResult> Post([FromForm] User user)
        {
            using (MVVMDemoEntities entities = new MVVMDemoEntities())
            {
                users = entities.Users.ToList();
            };

            var loginResult = new LoginResult();
            var mUser = users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (mUser != null)
            {
                loginResult.IsSuccess = true;
                loginResult.Message = "Success";
                loginResult.User = mUser;
                return loginResult;

            }
            else
            {
                loginResult.IsSuccess = false;
                loginResult.Message = "Invalid e-mail or password";
                Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                return loginResult;
            }

        }

    }
}
