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
    public class UserGetListUsers
    {
        public Response<List<User>> GetListUsers(UserDao userDao)
        {
            List<User> users = userDao.GetListUsers();
            return new Response<List<User>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = users
            };
        }
    }
}
