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
    public class UserGetUserForId
    {
        public int id { get; set; }

        public Response<User> GetUserForId(UserDao userDao)
        {
            User user = userDao.GetUserForId(id);
            if(user == null)
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
                Message = "user found successfully",
                Data = user
            };
        }
    }
}
