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
    public class DeleteUser
    {
        public int id { get; set; }

        public Response<List<User>> Delete(UserDao userDao)
        {
            bool success = userDao.DeleteUser(id);
            if (success)
            {
                List<User> users = userDao.GetListUsers();
                return new Response<List<User>>
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "User deleted successfully",
                    Data = users
                };
            }
            return new Response<List<User>>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "Error deleting user"
            };
        }
    }
}
