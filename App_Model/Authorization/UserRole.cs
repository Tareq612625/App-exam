using App_Model.App_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model.Authorization
{
    public class UserRole : COMMON
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public System.Int32 Id { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "{0} is required")]
        public string? UserId { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "{0} is required")]
        public System.Int32 RoleId { get; set; }

        //Foreign Key
        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
        [ForeignKey("UserId")]
        public virtual App_Model.UserInfo.UserInfo? UserInfo { get; set; }
    }
}
