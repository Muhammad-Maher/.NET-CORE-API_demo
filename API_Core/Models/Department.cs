using System;
using System.Collections.Generic;

// ADDED
using System.ComponentModel.DataAnnotations;
//

#nullable disable

namespace API_Core.Models
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
        }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptDesc { get; set; }
        public string DeptLocation { get; set; }
        public int? DeptManager { get; set; }
        public DateTime? ManagerHiredate { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
