using App_Infrastructure;
using App_Model.UseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.LoginService
{
    public interface ILoginRepo : IGenericRepository<App_Model.UseEntity.User>
    {
        User Login(string userId,string password);

    }
}
