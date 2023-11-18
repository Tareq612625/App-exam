using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model.Authorization
{
    public class ViewAppMenu
    {
        public int MODULE_ID { get; set; }
        public string MODULE_NAME_EN { get; set; }
        public string MODULE_NAME_BN { get; set; }
        public string MODULE_ICON { get; set; }
        public int MODULE_ORDER { get; set; }
        public int PARENT_ID { get; set; }
        public string PARENT_NAME_EN { get; set; }
        public string PARENT_NAME_BN { get; set; }
        public string PARENT_ICON { get; set; }
        public int PARENT_ORDER { get; set; }
        public int MENU_ID { get; set; }
        public string MENU_NAME_EN { get; set; }
        public string MENU_NAME_BN { get; set; }
        public string MENU_ICON { get; set; }
        public string AREA_NAME { get; set; }
        public string CONTROLLER_NAME { get; set; }
        public string ACTION_NAME { get; set; }
        public int MENU_ORDER { get; set; }

        [Display(Name = "Insert Access")]
        public bool Insert { get; set; } = false;
        [Display(Name = "Update Access")]
        public bool Update { get; set; } = false;
        [Display(Name = "Delete Access")]
        public bool Delete { get; set; } = false;
        [Display(Name = "View Access")]
        public bool View { get; set; } = true;
        public virtual List<A_USER_MENU> UserList { get; set; } = new List<A_USER_MENU>();
    }
}
