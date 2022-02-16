using DAO.UserModule;
using Model;
using Model.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.UserModule
{
    public class UserLogin
    {
        public string username { get; set; }

        public string password { get; set; }

        public Response<User> Login(UserDao userDao)
        {
            User user = userDao.UserLogin(username, password);
            if (user == null)
            {
                return new Response<User>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "User not exist"
                };
            }
            return new Response<User>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "User logged successfully",
                Data = user
            };
        }
    }
}
