using CansuAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserDataAccess;

namespace CansuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        public List<User> users = new List<User>();

        [HttpGet]
        public ActionResult<List<User>> GetAllList()
        {
            using (MVVMDemoEntities entities = new MVVMDemoEntities())
            {
                users = entities.Users.ToList();
                return users;
            };

        }

        /*   [HttpGet("{id}")]
           public ActionResult<User> GetPerson(int id)
           {

               var user = users.FirstOrDefault(x => x.Id == id);

               if (user == null)
               {
                   return NotFound();
               }
               return user;
           }
   */
        [HttpPost]
        public ActionResult<SignupResult> Post([FromForm] User user)
        {
            using (MVVMDemoEntities entities = new MVVMDemoEntities())
            {
                users = entities.Users.ToList();
            };

            var signupResult = new SignupResult();

            var mUser = users.FirstOrDefault(x => x.Email == user.Email);
            if (mUser != null)
            {
                signupResult.IsSuccess = false;
                signupResult.Message = "The e-mail has already been taken";
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            }
            else {

                using (MVVMDemoEntities entities = new MVVMDemoEntities())
                {

                    entities.Database.ExecuteSqlCommand("INSERT INTO [User](Email, Password, Name) VALUES(@Email, @Password, @Name)",
                        new SqlParameter("@Email", user.Email),
                        new SqlParameter("@Password", user.Password),
                        new SqlParameter("@Name", user.Name));

                    users = entities.Users.ToList();
                    var newUser = users.FirstOrDefault(x => x.Email == user.Email);

                    signupResult.IsSuccess = true;
                    signupResult.Message = "User sign up sucess";
                    signupResult.User = newUser;

                };
            }
          

            return signupResult;

        }
    }
}
