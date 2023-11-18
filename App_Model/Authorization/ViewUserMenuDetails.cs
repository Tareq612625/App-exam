using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model.Authorization
{
    public class ViewUserMenuDetails
    {
        public string? MenuName { get; set; }
        public int MenuId { get; set; }
        public int? Status { get; set; }

        public int ParentMenuId { get; set; }
        public string? ParentMenuName { get; set; }
        public int ModuleId { get; set; }
        public string? ModuleName { get; set; }

       // public string UserName { get;set; }
        public bool? Insert { get; set; } = false;
        public bool? Update { get; set; } = false;
        public bool? Delete { get; set; } = false;
        public bool? View { get; set; } = true;
        public string? UserId { get; set; }

    }
}
