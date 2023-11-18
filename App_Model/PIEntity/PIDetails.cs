using App_Model.App_Service;
using App_Model.ProductInfo;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model.PIEntity
{
    public class PIDetails : COMMON
    {
        [Key]
        [Display(Name = "Details Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PIDetailsId { get; set; }

        [Display(Name = "PIMasterCode")]
        public string? PIMasterCode { get; set; }


        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductMaster? ProductMaster { get; set; }

        [Display(Name = "UnitPrice")]
        public decimal UnitPrice { get; set; } = 0;

        [Display(Name = "Order Qty")]
        public int OrderQty { get; set; }

        [Display(Name = "ExpShipmentDate")]
        [DataType(DataType.Date)]
        public DateTime? ExpShipmentDate { get; set; }


        [NotMapped]
        public string EncryptedId
        {
            get
            {
                return EncryptionHelper.Encrypt(PIDetailsId.ToString());
            }
            set
            {
                PIDetailsId = int.Parse(EncryptionHelper.Decrypt(value));
            }
        }
    }
}
