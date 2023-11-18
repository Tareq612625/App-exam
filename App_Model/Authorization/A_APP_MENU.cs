using App_Model.App_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model.Authorization
{
    public class A_APP_MENU:COMMON
    {
        [Display(Name = "Main Menu Id")]
        [Required(ErrorMessage = "{0} is Required")]
        public int MENU_ID { get; set; }

        [Display(Name = "Menu Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? MENU_NAME_EN { get; set; }
        [Display(Name = "Menu Name Bangla")]

        [StringLength(100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? MENU_NAME_BN { get; set; }
        [Display(Name = "Menu Icon")]

        [StringLength(100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? MENU_ICON { get; set; }


        [Display(Name = "Area")]
        //[StringLength(100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? AREA_NAME { get; set; }


        [Display(Name = "Controller Name")]
        //[Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string? CONTROLLER_NAME { get; set; }

        [Display(Name = "Action/Method")]
        [StringLength(100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        //[Required(ErrorMessage = "{0} is Required")]
        public string? ACTION_NAME { get; set; }

        [Display(Name = "Menu Order")]
        [Required(ErrorMessage = "{0} is Required")]
        public int VIEW_ORDER { get; set; }

        [Display(Name = "Parent Menu Id")]
        [Required(ErrorMessage = "{0} is Required")]
        public int PARENT_ID { get; set; }
    }
}
