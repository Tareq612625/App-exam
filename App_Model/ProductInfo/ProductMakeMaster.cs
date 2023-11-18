using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Model.App_Service;

namespace App_Model.ProductInfo
{
    [Table("ProductMaster")]
    public class ProductMakeMaster : COMMON
    {
        [Key]
        [Display(Name = "Product Id")]
        [Required(ErrorMessage = "{0} is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? ProductName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? Description { get; set; }
        [Display(Name = "Product Image")]
        [StringLength(maximumLength: 500, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? ProductUrl { get; set; }

        [Display(Name = "Make Date")]
        [DataType(DataType.Date)]
        public DateTime MakeDate { get; set; }

        [Display(Name = "Order No")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? OrderNo { get; set; }

        [Display(Name = "Order From")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? OrderFrom { get; set; }


        [Display(Name = "Order Receive Date")]
        [DataType(DataType.Date)]
        public DateTime OrderReceiveDate { get; set; }

        public virtual List<ProductMakeDetails> ProductMakeDetails { get; set; }


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
