using System;
using System.Collections.Generic;

namespace DropDownWithSearch.Models
{
    public partial class Department
    {
        public string DeptName { get; set; }
        public int InsId { get; set; }
        public int Id { get; set; }

        public virtual Institution Ins { get; set; }
    }
}
