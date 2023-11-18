using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model.Common
{
    public class TheamColor
    {
        [Key]
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
