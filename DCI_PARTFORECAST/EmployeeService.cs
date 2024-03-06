using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_PARTFORECAST
{
    public class EmployeeService
    {
        private ConnectDB oConn = new ConnectDB("DBDCI");
        public EmployeeInfo GetEmployeeData(string code)
        {
            EmployeeInfo empInfo = new EmployeeInfo();

            SqlCommand sqlSelect = new SqlCommand();
            sqlSelect.CommandText = @"SELECT EMP.CODE, EMP.NAME, EMP.SURN, EMP.RSTYPE, EMP.POSIT, EMP.TELEPHONE, EMP.MAIL, EMP.COSTCENTER, DVCD.DV_ENAME 
                FROM Employee EMP 
                  INNER JOIN DVCD_Master DVCD
                  ON EMP.DVCD = DVCD.DV_CD
                  WHERE EMP.CODE = @CODE AND RSTYPE = ''";
            sqlSelect.Parameters.Add(new SqlParameter("@CODE", code));
            sqlSelect.CommandTimeout = 180;
            DataTable dtEmp = oConn.Query(sqlSelect);
            if (dtEmp.Rows.Count > 0)
            {
                empInfo.Emp_Code = dtEmp.Rows[0]["CODE"].ToString();
                empInfo.Emp_Name = dtEmp.Rows[0]["NAME"].ToString();
                empInfo.Emp_LastName = dtEmp.Rows[0]["SURN"].ToString();
                empInfo.Emp_CostCenter = dtEmp.Rows[0]["COSTCENTER"].ToString();
                empInfo.Emp_Dept = dtEmp.Rows[0]["DV_ENAME"].ToString();
                empInfo.Emp_Tel = dtEmp.Rows[0]["TELEPHONE"].ToString();
                empInfo.Emp_Email = dtEmp.Rows[0]["MAIL"].ToString();
                empInfo.Emp_Position = dtEmp.Rows[0]["POSIT"].ToString();
                empInfo.FullName = empInfo.Emp_Name + " " + empInfo.Emp_LastName;
            }
            else
            {
                empInfo = null;
            }

            return empInfo;
        }
    }
}
