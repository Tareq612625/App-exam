using App_Model.App_Service;
using App_Model.ProductInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model.PIEntity
{
    public class PIMaster : COMMON
    {
        [Key]
        [Display(Name = "Product Id")]
        [Required(ErrorMessage = "{0} is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PIMasterId { get; set; }

        public string? PICode { get; set; }


        [Display(Name = "Customer")]
        [Required(ErrorMessage = "{0} is required")]
        public int CustomerId { get; set; }


        [Display(Name = "Ship-To")]
        [Required(ErrorMessage = "{0} is required")]
        public int ShipToId { get; set; }

        [Display(Name = "Buyer")]
        [Required(ErrorMessage = "{0} is required")]
        public int BuyerId { get; set; }

        [Display(Name = "Dyecond")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? Dyecond { get; set; }
        
        [Display(Name = "Order Type")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? OrderType { get; set; }


        [Display(Name = "Tracking Number")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? TrackingNumber { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 500, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? Description { get; set; }

        [Display(Name = "Order No")]
        [Required(ErrorMessage = "{0} is required")]
        public int OrderNo { get; set; }
        [Display(Name = "Customer PO")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 30, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? CustomerPO { get; set; }



        [ForeignKey("CustomerId")]
        public virtual CustomerMaster? CustomerMaster { get; set; }
        [ForeignKey("ShipToId")]
        public virtual CustomerLocation? CustomerLocation { get; set; }
        [ForeignKey("BuyerId")]
        public virtual BuyerMaster? BuyerMaster { get; set; }


        public virtual List<PIDetails>? PIDetails { get; set; }


        [NotMapped]
        public string EncryptedId
        {
            get
            {
                return EncryptionHelper.Encrypt(PIMasterId.ToString());
            }
            set
            {
                PIMasterId = int.Parse(EncryptionHelper.Decrypt(value));
            }
        }
    }
}
