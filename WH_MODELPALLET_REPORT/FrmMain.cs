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
using WH_MODELPALLET_REPORT.Model;
using WH_OBSOLETEREPORT;
using WH_OBSOLETEREPORT.Model;
using WH_OBSOLETEREPORT.Service;


namespace WH_OBSOLETEREPORT
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Code ทำให้ DatagridView ทำงานได้เร็วไม่กระตุก
            Type dgvType = dgvDetailList.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgvDetailList, true, null);
            // Code ทำให้ DatagridView ทำงานได้เร็วไม่กระตุก

            pictureLoading.Visible = false;
            cbNWC.Text = "ALL";
            ddlPalletType.Text = "ALL";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            nwc = cbNWC.Text;


            if (!bgLoadData.IsBusy)   // เช็คว่า BackgroundWorker  ทำงานอยู่หรือไม่ ถ้าไม่ให้ทำงาน
            {
                btnSearch.Enabled = false;
                btnClear.Enabled = false;
                pictureLoading.Visible = true;
                cbNWC.Enabled = false;
                bgLoadData.RunWorkerAsync();
            }



        }

        private void bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            obsoleteList = svrObsolete.GetObsoleteList(subsumdate, nwc);
        }

        private void bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            dgvDetailList.Rows.Clear();
            pictureLoading.Visible = false;
            cbNWC.Enabled = true;
            btnSearch.Enabled = true;
            btnClear.Enabled = true;

            obsoleteList = svrObsolete.GetObsoleteList(subsumdate, nwc);

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

                Header.ValuesSecondary.Heading = "จำนวน " + dgvDetailList.Rows.Count.ToString("N0") + " ข้อมูล";
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    //ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    //ExcelPackage excel = new ExcelPackage(fileInfo);
                    //var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
                    //workSheet.TabColor = System.Drawing.Color.Red;
                    //workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    //workSheet.Row(1).Style.Font.Bold = true;

                    //workSheet.Cells[1, 1].Value = "OBSOLETE REPORT";

                    //workSheet.Cells[3, 1].Value = "NO";
                    //workSheet.Cells[3, 2].Value = "MODEL";
                    //workSheet.Cells[3, 3].Value = "SERIAL";
                    //workSheet.Cells[3, 4].Value = "PALLET NO";
                    //workSheet.Cells[3, 5].Value = "FG_DATE";
                    //workSheet.Cells[3, 6].Value = "SLOW_DATE";S
                    //workSheet.Cells[3, 7].Value = "OBSOLETE_DATE";
                    //workSheet.Cells[3, 8].Value = "PALLET QTY";
                    //workSheet.Cells[3, 9].Value = "AREA";
                    //workSheet.Cells[3, 10].Value = "STATUS";



                    //int recordIndex = 4;
                    //int rwd = 1;

                    //List<SaleAndLoadinginfo> saleList = new List<SaleAndLoadinginfo>();
                    obsoleteList = svrObsolete.GetObsoleteExcelList(subsumdate, nwc);

                    // เขียนไฟล์.
                    using (var writer = new StreamWriter(saveFileDialog1.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(obsoleteList);
                    }
                    // เขียนไฟล์.


                    //foreach (ObsoleteInfo item in obsoleteList)
                    //{
                    //    workSheet.Cells[recordIndex, 1].Value = rwd.ToString("N0");
                    //    workSheet.Cells[recordIndex, 2].Value = item.Model;
                    //    workSheet.Cells[recordIndex, 3].Value = item.Serial;
                    //    workSheet.Cells[recordIndex, 4].Value = item.PalletNo;
                    //    workSheet.Cells[recordIndex, 5].Value = item.FgDate.ToString("dd/MM/yyyy");
                    //    workSheet.Cells[recordIndex, 6].Value = item.SlowDate.ToString("dd/MM/yyyy");
                    //    workSheet.Cells[recordIndex, 7].Value = item.ObsoleteDate.ToString("dd/MM/yyyy");
                    //    workSheet.Cells[recordIndex, 8].Value = item.PalletQTY;
                    //    workSheet.Cells[recordIndex, 9].Value = item.Area;
                    //    workSheet.Cells[recordIndex, 10].Value = item.Status;


                    //    for (int i = 8; i <= 20; i++)
                    //    {
                    //        workSheet.Cells[recordIndex, i].Style.Numberformat.Format = "_(* #,##0.00_);_(* (#,##0.00);_(* \" -\"??_);_(@_)";
                    //    }

                    //    rwd++;
                    //    recordIndex++;
                    //}

                    //for (int i = 1; i <= 21; i++)
                    //{
                    //    workSheet.Column(i).AutoFit();

                    //}

                    //excel.Save();

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
            cbNWC.Text = "ALL";
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // กรอกได้เแพาะตัวเลข
            if (!char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }


    }

}
