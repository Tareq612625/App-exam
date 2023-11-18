using App_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Service.PIService;
using App_Service.LoginService;

namespace App_Service
{
    public interface IUnitOfWork: IDisposable
    {
        IPIRepo PIRepo { get; }
        ILoginRepo LoginRepo { get; }
        EQResult Commit();
    }
}
