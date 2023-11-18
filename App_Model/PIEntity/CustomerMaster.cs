using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Model.App_Service;

namespace App_Model.PIEntity
{
    public class CustomerMaster: COMMON
    {
        [Key]
        [Display(Name = "Customer Id")]
        [Required(ErrorMessage = "{0} is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "{0} is required")]
        public string? CustomerCode { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? CustomerName { get; set; }
        [Display(Name = "Customer Description")]
        [StringLength(maximumLength: 500, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? CustomerDetails { get; set; }
    }
    public class CustomerLocation: COMMON
    {
        [Key]
        [Display(Name = " Id")]
        [Required(ErrorMessage = "{0} is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = " Id")]
        [Required(ErrorMessage = "{0} is required")]
        public int CustomerId { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? CustomerShipLocation { get; set; }
    }
    public class BuyerMaster :COMMON
    {
        [Key]
        [Display(Name = " Id")]
        [Required(ErrorMessage = "{0} is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "{0} is required")]
        public string? BuyerCode { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? BuyerName { get; set; }
    }
    public class ProductMaster : COMMON
    {
        [Key]
        [Display(Name = " Id")]
        [Required(ErrorMessage = "{0} is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "{0} is required")]
        public string? ProductCode { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? ProductName { get; set; }

        [Display(Name = "Location")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? ProductDetails { get; set; }

        [Display(Name = "Unit")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        [Required(ErrorMessage = "{0} is required")]
        public string? Unit { get; set; }

        [Display(Name = "Unit Price")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal UnitPrice { get; set; } = 0;

    }
}
