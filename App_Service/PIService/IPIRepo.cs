using App_Infrastructure;
using App_Model.PIEntity;
using App_Model.ProductInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.PIService
{
    public interface IPIRepo : IGenericRepository<App_Model.PIEntity.PIMaster>
    {
        IEnumerable<CustomerMaster> SelectAllCustomer();
        IEnumerable<CustomerLocation> SelectAllCustomerLocation();
        IEnumerable<BuyerMaster> SelectAllBuyer();
        IEnumerable<ProductMaster> SelectAllProduct();
        ProductMaster ProductDetails(int Id);

        PIMaster GetByIdPIDetails(string PIcode);
    }
}
