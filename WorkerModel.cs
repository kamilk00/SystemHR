using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHR
{

    public class Worker
    {

        [Key]
        public int WorkerID { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string PESEL { get; set; }
        public string BankAccountNumber { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public float? Salary { get; set; }
        public string? TypeOfContract { get; set; }
        public string? StartOfContract { get; set; }
        public string? EndOfContract { get; set;}
        public int? ContractID { get; set; }

    }

}
