using App_Model;
using App_Service.LoginService;
using App_Service.PIService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Collections.Specialized.BitVector32;

namespace App_Service
{
    public class UnitOfWork:IUnitOfWork
    {
        private GimsDbcontext context;
        public UnitOfWork(GimsDbcontext context)
        {
            this.context = context;
            PIRepo = new PIRepo(context);
            LoginRepo = new LoginRepo(context);
        }
        public IPIRepo PIRepo { get; private set; }
        public ILoginRepo LoginRepo { get; private set; }

        EQResult IUnitOfWork.Commit()
        {
            EQResult eQ = new EQResult();
            try
            {
                context.Database.BeginTransaction();
                eQ.ROWS = context.SaveChanges();
                context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
                eQ.SUCCESS = false;
                eQ.MESSAGES = ex.Message.Contains("See the inner exception for details") ? ex.InnerException?.Message : ex.Message;
                eQ.ROWS = 0;
            }
            return eQ;
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
