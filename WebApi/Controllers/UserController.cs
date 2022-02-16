using BusinessLogic.UserModule;
using DAO.UserModule;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly UserDao _userDao;

        public UserController(UserDao userDao)
        {
            _userDao = userDao ?? throw new ArgumentNullException(nameof(userDao));
        }

        [HttpPost]
        public Response<List<User>> InsertUser(User user)
        {
            InsertUser insertUser = new InsertUser { user = user };
            return insertUser.InsertNewUser(_userDao);
        }

        [HttpPut("updateUser")]
        public Response<List<User>> UpdateUser(User user)
        {
            UpdateUser updateUser = new UpdateUser { user = user };
            return updateUser.Update(_userDao);
        }

        [HttpDelete("deleteUser")]
        public Response<List<User>> DeleteUser([FromQuery] int id)
        {
            DeleteUser deleteUser = new DeleteUser { id = id };
            return deleteUser.Delete(_userDao);
        }

        [HttpGet("login")]
        public Response<User> Login([FromQuery] string username, [FromQuery] string password)
        {
            UserLogin userLogin = new UserLogin { username = username, password = password };
            return userLogin.Login(_userDao);
        }

        [HttpGet]
        public Response<List<User>> GetListUsers()
        {
            UserGetListUsers userGetListUsers = new UserGetListUsers();
            return userGetListUsers.GetListUsers(_userDao);
        }

        [HttpGet("getUserForId")]
        public Response<User> GetUserForId([FromQuery] int id)
        {
            UserGetUserForId userGetUserForId = new UserGetUserForId { id = id };
            return userGetUserForId.GetUserForId(_userDao);
        }

    }
}
