using System;
using System.Collections.Generic;

// ADDED
using System.ComponentModel.DataAnnotations;
//

#nullable disable

namespace API_Core.Models
{
    public partial class Student
    {       
        public int StId { get; set; }
        public string FullName { get; set; }
        public string StLname { get; set; }
        public string StAddress { get; set; }
        public int? StAge { get; set; }
        public int? DeptId { get; set; }
        public int? StSuper { get; set; }

        public virtual Department Dept { get; set; }
    }
}
