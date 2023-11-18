using App_Infrastructure;
using App_Model;
using App_Model.PIEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.PIService
{
    public class PIRepo: GenericRepository<App_Model.PIEntity.PIMaster>, IPIRepo
    {
        public PIRepo(GimsDbcontext context) : base(context)
        {

        }

        public PIMaster GetByIdPIDetails(string PIcode)
        {
           // return context.PIMaster.Where(c => c.PICode == PIcode).Include(c=>c.CustomerMaster).Include(c=>c.ShipToId).Include(c=>c.BuyerMaster).Include(c => c.PIDetails)
           //.ThenInclude(d => d.ProductMaster).FirstOrDefault();

            var piMaster = context.PIMaster.Where(c => c.PICode == PIcode).FirstOrDefault();
            var details=context.PIDetails.Where(c=>c.PIMasterCode == PIcode).Include(c=>c.ProductMaster).ToList();
            //piMaster.PIDetails.AddRange(details);
            return piMaster;
        }

        public ProductMaster ProductDetails(int Id)
        {
            return context.ProductMaster.Where(c => c.Id == Id).FirstOrDefault();
        }

        public IEnumerable<BuyerMaster> SelectAllBuyer()
        {
            return (IEnumerable<BuyerMaster>)context.BuyerMaster.ToList();
        }

        public IEnumerable<CustomerMaster> SelectAllCustomer()
        {
            
            return (IEnumerable<CustomerMaster>)context.CustomerMaster.ToList();
        }

        public IEnumerable<CustomerLocation> SelectAllCustomerLocation()
        {
            return (IEnumerable<CustomerLocation>)context.CustomerLocation.ToList();
        }

        public IEnumerable<ProductMaster> SelectAllProduct()
        {
            return (IEnumerable<ProductMaster>)context.ProductMaster.ToList();
        }
    }
}
