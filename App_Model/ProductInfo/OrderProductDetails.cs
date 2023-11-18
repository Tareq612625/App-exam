using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Model.Authorization;
using Microsoft.AspNetCore.Http;
using App_Model.App_Service;

namespace App_Model.ProductInfo
{
    [Table("OrderProductDetails")]
    public class OrderProductDetails : COMMON
    {
        [Key]
        [Display(Name = "Details Id")]
        [Required(ErrorMessage = "{0} is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductDetailsId { get; set; }

        [Display(Name = "Product Code")]
        public string? ProductCode { get; set; }


        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "{0} is required")]
        public int SupplierId { get; set; }

        [Display(Name = "Unit Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? UnitName { get; set; }

        [Display(Name = "Product Type")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? ProductType { get; set; }

        [Display(Name = "Material Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? MaterialName { get; set; }

        [Display(Name = "Material Description")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? MaterialDescription { get; set; }

        [Display(Name = "Details Image")]
        [StringLength(maximumLength: 500, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? DetailsProductUrl { get; set; }

        [Display(Name = "Sub Product Make Date")]
        [DataType(DataType.Date)]
        public DateTime? SubProductMakeDate { get; set; }



        [Display(Name = "Sub Product Cotton")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? SubProductCotton { get; set; }

        [Display(Name = "Shipping Type")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? ShipmentType { get; set; }

      //  public IFormFile? DetailsFile { get; set; } // Property for file upload


        //Foreign Key
        //[ForeignKey("ProductMakeMasterId")]
        //public virtual ProductMakeMaster? ProductMakeMaster { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierInfo? SupplierInfo { get; set; }

        [NotMapped]
        public IFormFile? DetailsFileName { get; set; }

        [NotMapped]
        public string EncryptedId
        {
            get
            {
                return EncryptionHelper.Encrypt(ProductDetailsId.ToString());
            }
            set
            {
                ProductDetailsId = int.Parse(EncryptionHelper.Decrypt(value));
            }
        }

    }
}
