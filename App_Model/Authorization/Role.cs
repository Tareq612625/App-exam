using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Model.App_Service;
using Microsoft.Extensions.Primitives;
using System.Runtime.InteropServices;

namespace App_Model.Authorization
{
    public class Role:COMMON
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Role Id")]
        public System.Int32 Id { get; set; }

        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 30, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? RoleName { get; set; }

        [Display(Name = "Role Description")]
        [StringLength(maximumLength: 30, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? RoleDescription { get; set; }
        [Display(Name = "Role Catagory")]
        [StringLength(maximumLength: 30, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? RoleCatagory { get; set; }

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
