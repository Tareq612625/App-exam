using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model.App_Service
{
    public class COMMON
    {
        public COMMON()
        {
            SingleDevice = "N";
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            CreateUser = Environment.UserName;
            UpdateUser = Environment.UserName;
            CreateDevice = Environment.MachineName;
            UpdateDevice = Environment.MachineName;
            IsActive =1;
        }
        public string? SingleDevice { get; set; }
        public Nullable<System.Int32> IsActive { get; set; } = 1;

        public DateTime CreateDate { get; set; }= DateTime.Now;

        [StringLength(100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? CreateUser { get; set; }
        [StringLength(100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? CreateDevice { get; set; }
        public DateTime? UpdateDate { get; set; }
        [StringLength(100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? UpdateUser { get; set; }
        [StringLength(100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? UpdateDevice { get; set; }
    }
}
