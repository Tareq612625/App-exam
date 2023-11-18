using App_Infrastructure;
using App_Model;
using App_Model.UseEntity;
using App_Service.PIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.LoginService
{
    public class LoginRepo : GenericRepository<App_Model.UseEntity.User>, ILoginRepo
    {
        public LoginRepo(GimsDbcontext context) : base(context)
        {

        }

        public User Login(string userId, string password)
        {
            return context.User.Where(c => c.UserId.ToLower() == userId && c.UserPassword.ToLower() == password).FirstOrDefault();
        }
    }
}
