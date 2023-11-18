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
    public class A_USER_MENU:COMMON
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Role Id")]
        public System.Int32 Id { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "{0} is Required")]
        public string? UserId { get; set; }


        [Display(Name = "Menu Name")]
        [Required(ErrorMessage = "{0} is Required")]
        public int MenuId { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "{0} is Required")]
        public int RoleId { get; set; }

        [Display(Name = "Insert Access")]
        [Required(ErrorMessage = "{0} is Required")]
        public bool Insert { get; set; } = false;
        [Display(Name = "Update Access")]
        [Required(ErrorMessage = "{0} is Required")]
        public bool Update { get; set; }=false;
         [Display(Name = "Delete Access")]
        [Required(ErrorMessage = "{0} is Required")]
        public bool Delete { get; set; }=false;
        [Display(Name = "View Access")]
        [Required(ErrorMessage = "{0} is Required")]
        public bool View { get; set; }=true;

    }
}
