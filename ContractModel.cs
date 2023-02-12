using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHR
{

    public class Contract
    {

        [Key]
        public int ContractID { get; set; }
        public string Name { get; set; }
        public string TypeOfContract { get; set; }
        public float Salary { get; set; }
        public string StartOfContract { get; set; }
        public string EndOfContract { get; set;}
        
    }

}
