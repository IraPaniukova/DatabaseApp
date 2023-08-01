using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProjectPaniukova.DB;

namespace ProjectPaniukova.DB
{
    public class EmployeeData
    {
        public int EmployeeId { get; set; }
        
        public string EmployeeName { get; set; } = null!;

        public string EmployeePhone { get; set; } = null!;

        public string OfficeAddress { get; set; } = null!;
        public string PhoneExtentshion { get; set; } = null!;

      
    }
}
