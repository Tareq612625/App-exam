using App_Model.App_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model.ProductInfo
{
    public class SupplierInfo : COMMON
    {
        [Key]
        [Display(Name = "Supplier Id")]
        [Required(ErrorMessage = "{0} is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Supplier Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string SupplierName { get; set; }
        [Display(Name = "Supplier Description")]
        [StringLength(maximumLength: 500, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string SupplierDescription { get; set;}
        [Display(Name = "Supplier Id")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string SupplierCompanyName { get;  set; }
        [Display(Name = "Supplier Address")]
        [StringLength(maximumLength: 500, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string SupplierAdddress { get;set; }
        [Display(Name = "Supplier Certificate")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string SupplierCertificate { get;set; }

        [Display(Name = "Lat")]
        [Required(ErrorMessage = "{0} is required")]
        public string? Lat { get; set; }

        [Display(Name = "Lng")]
        [Required(ErrorMessage = "{0} is required")]
        public string? Lng { get; set; }

        [Display(Name = "Location title")]
        [Required(ErrorMessage = "{0} is required")]
        public string? Loctitle { get; set; }
        [NotMapped]
        public string EncryptedId
        {
            get
            {
                return EncryptionHelper.Encrypt(Id.ToString());
            }
            set
            {
                Id = int.Parse(EncryptionHelper.Decrypt(value));
            }
        }
    }
}
