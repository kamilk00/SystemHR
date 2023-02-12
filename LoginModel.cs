using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHR
{

    public class User
    {

        [Key]
        public int WorkerID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

    }

}
