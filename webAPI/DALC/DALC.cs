using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Entities.Entities;

namespace DALC
{
    public class DALC
    {
        public string connStr;
        public List<Employee> GetAllEmployees()
        {
            List<Employee> oList = new List<Employee>();



            // 2. Create Sql Connection Object
            using (SqlConnection oConn = new SqlConnection(connStr))
            {
                // 3. Open the Connection
                oConn.Open();

                //4 . Prepare Sql Command Object
                using (SqlCommand command = new SqlCommand("UP_GET_EMPLOYEES"))
                {
                    //5. Set the Command Type to Stored Procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //6. Inform the Command on Wich connection it should work
                    command.Connection = oConn;

                    // 7. Execute the Command (ExecuteReader)
                    // 8. The Reader is a kind of Hand/Cursor pointing to data retrieved by the Command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Employee oEmployee = new Employee();
                                oEmployee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                                oEmployee.EmployeeName = Convert.ToString(reader["EmployeeName"]);
                                oEmployee.Department = Convert.ToString(reader["Department"]);
                                oEmployee.DateOfJoining= Convert.ToDateTime(reader["DateOfJoining"]);
                                oEmployee.PhotoFileName = Convert.ToString(reader["PhotoFileName"]);
                                oList.Add(oEmployee);
                            }
                        }
                    }
                }
            }



            return oList;
        }


        public void Delete_Employee(Params_Delete_Employee i_Params_Delete_Employee)
        {
            // You should Always create a complex type (Class) which has properties matching parameters

            // 1. Define Your Connection String


            // 2. Create Sql Connection Object
            using (SqlConnection oConn = new SqlConnection(connStr))
            {
                // 3. Open the Connection
                oConn.Open();

                //4 . Prepare Sql Command Object
                using (SqlCommand command = new SqlCommand("UP_DELETE_EMPLOYEE"))
                {
                    //5. Set the Command Type to Stored Procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //6. Inform the Command on Wich connection it should work
                    command.Connection = oConn;

                    command.Parameters.Add(new SqlParameter() { ParameterName = "EmployeeId", Value = i_Params_Delete_Employee.EmployeeId });

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit_Employee(Employee i_Employee)
        {
            // You should Always create a complex type (Class) which has properties matching parameters

            // 2. Create Sql Connection Object
            using (SqlConnection oConn = new SqlConnection(connStr))
            {
                // 3. Open the Connection
                oConn.Open();

                //4 . Prepare Sql Command Object
                using (SqlCommand command = new SqlCommand("UP_EDIT_EMPLOyEE"))
                {
                    //5. Set the Command Type to Stored Procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //6. Inform the Command on Wich connection it should work
                    command.Connection = oConn;

                    command.Parameters.Add(new SqlParameter() { ParameterName = "EmployeeId", Value = i_Employee.EmployeeId});
                    command.Parameters.Add(new SqlParameter() { ParameterName = "EmployeeName", Value = i_Employee.EmployeeName });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "Department", Value = i_Employee.Department });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "DateOfJoining", Value = i_Employee.DateOfJoining });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "PhotoFileName", Value = i_Employee.PhotoFileName });

                    command.ExecuteNonQuery();
                }
            }
        }

        
        //------------------------------------------

        public List<Department> GetAllDepartments()
        {
            List<Department> oList = new List<Department>();



            // 2. Create Sql Connection Object
            using (SqlConnection oConn = new SqlConnection(connStr))
            {
                // 3. Open the Connection
                oConn.Open();

                //4 . Prepare Sql Command Object
                using (SqlCommand command = new SqlCommand("UP_GET_DEPARTMENTS"))
                {
                    //5. Set the Command Type to Stored Procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //6. Inform the Command on Wich connection it should work
                    command.Connection = oConn;

                    // 7. Execute the Command (ExecuteReader)
                    // 8. The Reader is a kind of Hand/Cursor pointing to data retrieved by the Command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Department oDepartment = new Department();
                                oDepartment.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                                oDepartment.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                                oList.Add(oDepartment);
                            }
                        }
                    }
                }
            }



            return oList;
        }

        public List<Department> GetAllDepartmentsName() {
            List<Department> oList = new List<Department>();

            // 2. Create Sql Connection Object
            using (SqlConnection oConn = new SqlConnection(connStr))
            {
                // 3. Open the Connection
                oConn.Open();

                //4 . Prepare Sql Command Object
                using (SqlCommand command = new SqlCommand("UP_GET_EMP_DEPARTMENTS"))
                {
                    //5. Set the Command Type to Stored Procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //6. Inform the Command on Wich connection it should work
                    command.Connection = oConn;

                    // 7. Execute the Command (ExecuteReader)
                    // 8. The Reader is a kind of Hand/Cursor pointing to data retrieved by the Command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Department oDepartment = new Department();
                                oDepartment.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                                oList.Add(oDepartment);
                            }
                        }
                    }
                }
            }

            return oList;
        }
        public void Delete_Department(Params_Delete_Department i_Params_Delete_Department)
        {
            // You should Always create a complex type (Class) which has properties matching parameters

            // 1. Define Your Connection String


            // 2. Create Sql Connection Object
            using (SqlConnection oConn = new SqlConnection(connStr))
            {
                // 3. Open the Connection
                oConn.Open();

                //4 . Prepare Sql Command Object
                using (SqlCommand command = new SqlCommand("UP_DELETE_DEPARTMENT"))
                {
                    //5. Set the Command Type to Stored Procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //6. Inform the Command on Wich connection it should work
                    command.Connection = oConn;

                    command.Parameters.Add(new SqlParameter() { ParameterName = "DepartmentId", Value = i_Params_Delete_Department.DepartmentID});

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Department> GetDepartmentsByWhere(Department i_Department)
        {
            List<Department> oList = new List<Department>();



            // 2. Create Sql Connection Object
            using (SqlConnection oConn = new SqlConnection(connStr))
            {
                // 3. Open the Connection
                oConn.Open();

                //4 . Prepare Sql Command Object
                using (SqlCommand command = new SqlCommand("UP_GET_DEPARTMENT_BY_WHERE"))
                {
                    //5. Set the Command Type to Stored Procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //6. Inform the Command on Wich connection it should work
                    command.Connection = oConn;

                    // 7. Execute the Command (ExecuteReader)
                    // 8. The Reader is a kind of Hand/Cursor pointing to data retrieved by the Command

                    command.Parameters.Add(new SqlParameter() { ParameterName = "DepartmentId", Value = i_Department.DepartmentID });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "DepartmentName", Value = i_Department.DepartmentName });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Department oDepartment = new Department();
                                oDepartment.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                                oDepartment.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                                oList.Add(oDepartment);
                            }
                        }
                    }
                }
            }



            return oList;
        }
        public void Edit_Department(Department i_Department)
        {
            // You should Always create a complex type (Class) which has properties matching parameters

            // 2. Create Sql Connection Object
            using (SqlConnection oConn = new SqlConnection(connStr))
            {
                // 3. Open the Connection
                oConn.Open();

                //4 . Prepare Sql Command Object
                using (SqlCommand command = new SqlCommand("UP_EDIT_DEPARTMENT"))
                {
                    //5. Set the Command Type to Stored Procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //6. Inform the Command on Wich connection it should work
                    command.Connection = oConn;

                    command.Parameters.Add(new SqlParameter() { ParameterName = "DepartmentId", Value = i_Department.DepartmentID});
                    command.Parameters.Add(new SqlParameter() { ParameterName = "DepartmentName", Value = i_Department.DepartmentName });
                  
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
