using System;
using System.Collections.Generic;

namespace DropDownWithSearch.Models
{
    public partial class EmpDeptIns
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public int InsId { get; set; }

        public virtual Institution Ins { get; set; }
    }
}
