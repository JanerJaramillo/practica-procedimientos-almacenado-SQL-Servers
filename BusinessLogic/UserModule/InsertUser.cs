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
    public class InsertUser
    {
        public User user { get; set; }

        public Response<List<User>> InsertNewUser(UserDao userDao)
        {
            bool success = userDao.InsertUser(user);
            if (success)
            {
                List<User> users = userDao.GetListUsers();
                return new Response<List<User>>
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "User registered successfully",
                    Data = users
                };
            }
            return new Response<List<User>>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "Error inserting new user"
            };
        }
    }
}
