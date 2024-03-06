using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WH_OBSOLETEREPORT_ODM.Model;
using WH_OBSOLETEREPORT_ODM.Service;

namespace WH_OBSOLETEREPORT_ODM
{
    public partial class FrmMain : Form
    {
        private EmployeeService svrEmp = new EmployeeService();
        private ClsOraConnection oConOracle = new ClsOraConnection("ALPHAPD");
        private ObsoleteService svrObsolete = new ObsoleteService();
        private List<ObsoleteInfo> obsoleteList = new List<ObsoleteInfo>();


        private string p_MenuId = "";
        private string p_USERNAME = "";
        private string subsumdate = "";
        private string nwc = "";

        public FrmMain(string empCode, string menuId)
        {
            EmployeeInfo empInfo = svrEmp.GetEmployeeData(empCode);
            if (empInfo.FullName != "")
            {
                InitializeComponent();
                //this.Header.ValuesPrimary.Description = empInfo.FullName;
                this.Header.ValuesPrimary.Description = empInfo.Emp_Code + " : " + empInfo.FullName;
                this.Header.ValuesPrimary.Heading = menuId.ToUpper() + " " + Header.ValuesPrimary.Heading;
                this.Text = menuId.ToUpper() + " " + this.Text;

                p_MenuId = menuId.ToUpper();
                p_USERNAME = empInfo.FullName.ToUpper();
            }
            else
            {
                MessageBox.Show("Employee Code is invalid, please check again.");
                this.Close();
                Application.Exit();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Code ทำให้ DatagridView ทำงานได้เร็วไม่กระตุก
            Type dgvType = dgvDetailList.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgvDetailList, true, null);
            // Code ทำให้ DatagridView ทำงานได้เร็วไม่กระตุก

            pictureLoading.Visible = false;
            txtDate.Text = DateTime.Now.ToString("yyyyMMdd");
            cbNWC.Text = "ALL";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtDate.Text.Trim() != "")
            {
                nwc =  cbNWC.Text;
                DateTime datesearch = new DateTime(2000, 1, 1);  // set วันที่เริ่มต้น

                try
                {
                    string strdate = txtDate.Text;
                    string subsy = strdate.Substring(0, 4);// ปี  string
                    string subsm = strdate.Substring(4, 2);// เดือน  string
                    string subsd = strdate.Substring(6, 2);// วัน   string
                    subsumdate = subsy + "-" + subsm + "-" + subsd;
                    datesearch = Convert.ToDateTime(subsumdate);
                }
                catch
                {
                    MessageBox.Show("กรอกข้อมูลวันที่ไม่ถูกต้อง (YYYYMMDD)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtDate.SelectAll();
                    txtDate.Focus();
                    dgvDetailList.Rows.Clear();
                    return;
                }


                if (datesearch > DateTime.Now.AddDays(-1))   //  datesearch ต้องไม่น้อยกว่าวันที่ปัจจุบัน
                {
                    if (!bgLoadData.IsBusy)   // เช็คว่า BackgroundWorker  ทำงานอยู่หรือไม่ ถ้าไม่ให้ทำงาน
                    {
                        txtDate.Enabled = false;
                        btnSearch.Enabled = false;
                        btnClear.Enabled = false;
                        cbNWC.Enabled = false;
                        pictureLoading.Visible = true;

                        bgLoadData.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("วันที่ต้องไม่น้อยกว่าวันที่ ปัจจุบัน", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDate.SelectAll();
                    txtDate.Focus();
                    dgvDetailList.Rows.Clear();
                    return;
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกวันที่", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDate.SelectAll();
                txtDate.Focus();
                dgvDetailList.Rows.Clear();
                return;
            }
        }

        private void bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            obsoleteList = svrObsolete.GetObsoleteODMList(subsumdate ,nwc);
        }

        private void bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvDetailList.Rows.Clear();
            cbNWC.Enabled = true;
            pictureLoading.Visible = false;
            txtDate.Enabled = true;
            btnSearch.Enabled = true;
            btnClear.Enabled = true;

            obsoleteList = svrObsolete.GetObsoleteODMList(subsumdate,nwc);

            if (obsoleteList.Count > 0)
            {
                foreach (ObsoleteInfo obsolete in obsoleteList)
                {
                    dgvDetailList.Rows.Add(
                        obsolete.MODEL,
                        obsolete.SERIAL,
                        obsolete.PALLETNO,
                        obsolete.PALLET_TYPE,
                        obsolete.FGDATE,
                        obsolete.SLOWDATE,
                        obsolete.OBSOLETEDATE,
                        obsolete.UNIT,
                        obsolete.AREA,
                        obsolete.CURRENT_WC,
                        obsolete.WAREHOUSECODE,
                        obsolete.STATUS
                      );
                }

                GroupDeTail.ValuesSecondary.Heading = "จำนวน " + dgvDetailList.Rows.Count.ToString("N0") + " ข้อมูล";
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDate.SelectAll();
                txtDate.Focus();
                dgvDetailList.Rows.Clear();
                return;
            }





        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetailList.Rows.Count > 0)
            {
                saveFileDialog1.FileName = "";

                DialogResult dlg = saveFileDialog1.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    if (File.Exists(saveFileDialog1.FileName))
                    {
                        File.Delete(saveFileDialog1.FileName);
                    }

                    FileInfo fileInfo = new FileInfo(saveFileDialog1.FileName);

                    obsoleteList = svrObsolete.GetObsoleteODMExcelList(subsumdate,nwc);

                    // เขียนไฟล์.
                    using (var writer = new StreamWriter(saveFileDialog1.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(obsoleteList);
                    }
                    // เขียนไฟล์.


                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Export data complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvDetailList.Rows.Clear();
            txtDate.Text = "";
            cbNWC.Text = "ALL";
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
