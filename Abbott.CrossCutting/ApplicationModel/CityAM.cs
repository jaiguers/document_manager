using System;
using System.Collections.Generic;
using System.Text;

namespace Abbott.CrossCutting.ApplicationModel
{
    public class CityAM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long IdDepartment { get; set; }
        public long IdState { get; set; }
        public DepartmentAM Department { get; set; }
        public StatesAM States { get; set; }
    }
}
