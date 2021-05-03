using System;

namespace Entities
{
    public class Entities
    {
        public class Employee
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public string Department { get; set; }
            public DateTime DateOfJoining { get; set; }
            public string PhotoFileName { get; set; }
        }
        public class Params_Delete_Employee
        {
            public int EmployeeId { get; set; }
        }

        public class Department
        {
            public int? DepartmentID { get; set; }
            public string DepartmentName { get; set; }
        }
        public class Params_Delete_Department
        {
            public int DepartmentID{ get; set; }
        }
    }
}
