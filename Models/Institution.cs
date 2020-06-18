using System;
using System.Collections.Generic;

namespace DropDownWithSearch.Models
{
    public partial class Institution
    {
        public Institution()
        {
            Department = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string InsName { get; set; }

        public virtual ICollection<Department> Department { get; set; }
    }
}
