using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH_OBSOLETEREPORT_ODM.Model
{
    public class EmployeeInfo
    {
        private string emp_Code = "";
        private string emp_Name = "";
        private string emp_LastName = "";
        private string emp_CostCenter = "";
        private string emp_Tel = "";
        private string emp_Dept = "";
        private string emp_Email = "";
        private string emp_Position = "";
        private string dvcd_Head = "";
        private string dvcd_GM = "";
        private string fullName = "";

        public string Emp_Code { get => emp_Code; set => emp_Code = value; }
        public string Emp_Name { get => emp_Name; set => emp_Name = value; }
        public string Emp_LastName { get => emp_LastName; set => emp_LastName = value; }
        public string Emp_CostCenter { get => emp_CostCenter; set => emp_CostCenter = value; }
        public string Emp_Tel { get => emp_Tel; set => emp_Tel = value; }
        public string Emp_Dept { get => emp_Dept; set => emp_Dept = value; }
        public string Emp_Email { get => emp_Email; set => emp_Email = value; }
        public string Emp_Position { get => emp_Position; set => emp_Position = value; }
        public string Dvcd_Head { get => dvcd_Head; set => dvcd_Head = value; }
        public string Dvcd_GM { get => dvcd_GM; set => dvcd_GM = value; }
        public string FullName { get => fullName; set => fullName = value; }
    }
}
