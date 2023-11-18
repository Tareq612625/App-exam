using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Model.App_Service;

namespace App_Model.Authorization
{
    public class RoleMenu:COMMON
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public System.Int32 Id { get; set; }

        [Display(Name = "Menu Name")]
        [Required(ErrorMessage = "{0} is required")]
        public int MenuId { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "{0} is required")]
        public System.Int32 RoleId { get; set; }

        //Foreign Key
        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
        [ForeignKey("MenuId")]
        public virtual A_APP_MENU? A_APP_MENU { get; set; }
    }
}
