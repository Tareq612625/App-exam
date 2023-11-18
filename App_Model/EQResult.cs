using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model
{
    public class EQResult
    {
        public bool SUCCESS { get; set; }
        public string MESSAGES { get; set; }
        public int ROWS { get; set; }
        public EQResult()
        {
            SUCCESS = true;
            MESSAGES = "SUCCEEDED";
            ROWS = 0;
        }
    }
}
