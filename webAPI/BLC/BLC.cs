using System;
using System.Collections.Generic;
using System.Linq;
using static Entities.Entities;

namespace BLC
{
    public class BLC
    {
        public string connStr = "";
        public List<Employee> GetAllEmployees()
        {
            DALC.DALC oDALC = new DALC.DALC();
            oDALC.connStr = this.connStr;
            List<Employee> oList = oDALC.GetAllEmployees();
            oList = oList.OrderBy(x => x.EmployeeName).ToList();
            // oList.RemoveAll(x => x.ADDRESS == "Tripoli");
            return oList;
        }


        public void Delete_Employee(Params_Delete_Employee i_Params_Delete_Employee)
        {
            DALC.DALC oDALC = new DALC.DALC();
            oDALC.connStr = this.connStr;
            oDALC.Delete_Employee(i_Params_Delete_Employee);
        }


        public void Edit_Employee(Employee i_Employee)
        {
            DALC.DALC oDALC = new DALC.DALC();
            oDALC.connStr = this.connStr;
            oDALC.Edit_Employee(i_Employee);
        }


        //----------------------------------------------
        public List<Department> GetAllDepartments()
        {
            DALC.DALC oDALC = new DALC.DALC();
            oDALC.connStr = this.connStr;
            List<Department> oList = oDALC.GetAllDepartments();
            oList = oList.OrderBy(x => x.DepartmentName).ToList();
            // oList.RemoveAll(x => x.ADDRESS == "Tripoli");
            return oList;
        }

        public List<Department> GetAllDepartmentsName()
        {

            DALC.DALC oDALC = new DALC.DALC();
            oDALC.connStr = this.connStr;
            List<Department> oList = oDALC.GetAllDepartmentsName();
           // oList = oList.OrderBy(x => x.DepartmentName).ToList();
            // oList.RemoveAll(x => x.ADDRESS == "Tripoli");
            return oList;
        }

        public void Delete_Department(Params_Delete_Department i_Params_Delete_Department)
        {
            DALC.DALC oDALC = new DALC.DALC();
            oDALC.connStr = this.connStr;
            oDALC.Delete_Department(i_Params_Delete_Department);
        }

        public List<Department> GetDepartmentsByWhere(Department i_Department)
        {
            DALC.DALC oDALC = new DALC.DALC();
            oDALC.connStr = this.connStr;
            List<Department> oList = oDALC.GetDepartmentsByWhere(i_Department);
           // oList = oList.OrderBy(x => x.DepartmentName).ToList();
            // oList.RemoveAll(x => x.ADDRESS == "Tripoli");
            return oList;
        }


        public void Edit_Department(Department i_Department)
        {
            DALC.DALC oDALC = new DALC.DALC();
            oDALC.connStr = this.connStr;
            oDALC.Edit_Department(i_Department);
        }

    }
}
