using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp2022.Models
{
    public class Employee
    {
        [Key]
        public int empid { get; set; }
        public string ename { get; set; }
        public string location { get; set; }
        public string emailid { get; set; }
    }
}
