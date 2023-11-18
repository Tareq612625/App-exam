using App_Model.App_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model.UserInfo
{
    [Table("UserInfo")]
    public class UserInfo:COMMON
    {
        [Key]
        [Display(Name = "User Id")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? UserId { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 30, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? UserPassword { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? UserName { get; set; }

        [Display(Name = "Designation")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string ? Designation { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "{0} is required")]
        public string? DepartmentId { get; set; }

        [Display(Name = "Mobile")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 9)]
        public string? Mobile { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string? Email { get; set; }

        [NotMapped]
        public string EncryptedUserId
        {
            get
            {
                return EncryptionHelper.Encrypt(UserId.ToString());
            }
            set
            {
                UserId = EncryptionHelper.Decrypt(value);
            }
        }

    }
}
