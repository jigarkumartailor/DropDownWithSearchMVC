using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DropDownWithSearch.Models.ViewModel
{
    public class ViewModel
    {
        public IEnumerable<Department> department { get; set; }
        public IEnumerable<Institution> institution { get; set; }
        public IEnumerable<EmployeeList> employeeList { get; set; }

    }
}
