using CsvHelper;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Oracle.ManagedDataAccess.Client;
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
using WH_SALEORDERLOADING.Model;
using WH_SALEORDERLOADING.Service;

namespace WH_SALEORDERLOADING
{
    public partial class frmMain : Form
    {
        private EmployeeService svrEmp = new EmployeeService();
        private ClsOraConnection oConOracle = new ClsOraConnection("ALPHAPD");
        private SaleAndLoadingService svrsale = new SaleAndLoadingService();
        private List<SaleAndLoadinginfo> saleList = new List<SaleAndLoadinginfo>();

        private string p_MenuId = "";
        private string p_USERNAME = "";
        private string subStartdate = "";
        private string subenddate = "";
        private string textstartdate = "";
        private string subsy = "";
        private string subsm = "";
        private string subsd = "";
        private string textendDate = "";
        private string subey = "";
        private string subem = "";
        private string subed = "";
        private string model = "";
        private string customer = "";




        public frmMain(string empCode, string menuId)
        {
            EmployeeInfo empInfo = svrEmp.GetEmployeeData(empCode);
            if (empInfo.FullName != "")
            {
                InitializeComponent();
                this.pnDateDetail.ValuesPrimary.Description = empInfo.FullName;
                this.pnDateDetail.ValuesPrimary.Heading = menuId.ToUpper() + " " + pnDateDetail.ValuesPrimary.Heading;
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


            saleList = svrsale.CustomerList();

            cbCustomer.DataSource = saleList;
            cbCustomer.ValueMember = "CUSTOMER_CODE";
            cbCustomer.DisplayMember = "CUSTOMER_NAME";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtStartDate.Text.Trim() != "" && txtEndDate.Text.Trim() != "")
            {
                model = txtModel.Text;
                customer = cbCustomer.SelectedValue.ToString();


                textstartdate = txtStartDate.Text;
                subsy = textstartdate.Substring(0, 4);   // ปี  string
                subsm = textstartdate.Substring(4, 2);   // เดือน  string
                subsd = textstartdate.Substring(6, 2);   // วัน   string
                subStartdate = subsy + "-" + subsm + "-" + subsd;

                textendDate = txtEndDate.Text;
                subey = textendDate.Substring(0, 4);   // ปี   string
                subem = textendDate.Substring(4, 2);   // เดือน   string
                subed = textendDate.Substring(6, 2);    // วัน   string
                subenddate = subey + "-" + subem + "-" + subed;



                int Startyear = int.Parse(subsy);
                int Endyear = int.Parse(subey);
                int Startmonth = int.Parse(subsm);
                int Endymonth = int.Parse(subem);
                int Startdate = int.Parse(subsd);
                int Enddate = int.Parse(subed);


                DateTime dateStart = new DateTime(2000, 1, 1);  // set วันที่เริ่มต้น
                DateTime dateEnd = new DateTime(2000, 1, 1);   // set วันที่เริ่มต้น



                try
                {
                    dateStart = new DateTime(Startyear, Startmonth, Startdate);
                }
                catch
                {
                    MessageBox.Show("กรอกข้อมูลวันที่ไม่ถูกต้อง (YYYYMMDD)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtStartDate.SelectAll();
                    txtStartDate.Focus();
                    dgvDetailList.Rows.Clear();
                    return;
                }


                try
                {
                    dateEnd = new DateTime(Endyear, Endymonth, Enddate);
                }
                catch
                {
                    MessageBox.Show("กรอกข้อมูลวันที่ไม่ถูกต้อง (YYYYMMDD)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtEndDate.SelectAll();
                    txtEndDate.Focus();
                    dgvDetailList.Rows.Clear();
                    return;
                }



                if (dateStart <= dateEnd)   //  Start ต้องน้อยกว่า End
                {
                    TimeSpan sum = dateEnd.ToLocalTime() - dateStart.ToLocalTime();
                    int totalMonth = Convert.ToInt32(sum.TotalDays);


                    if ((totalMonth) < 31)   // วันที่ในการค้นหาระหว่าง Start Date >> End Date  ต้องไม่มากกว่า 1 เดือน 
                    {
                        if (!bgLoadData.IsBusy)   // เช็คว่า BackgroundWorker  ทำงานอยู่หรือไม่ ถ้าไม่ให้ทำงาน
                        {
                            txtStartDate.Enabled = false;
                            txtEndDate.Enabled = false;
                            txtModel.Enabled = false;
                            cbCustomer.Enabled = false;
                            pictureLoading.Visible = true;
                            btnSearch.Enabled = false;
                            btnClear.Enabled = false;
                            bgLoadData.RunWorkerAsync();
                        }

                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถค้นหาได้มากกว่า 1 เดือน", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEndDate.SelectAll();
                        txtEndDate.Focus();
                        dgvDetailList.Rows.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("วันที่ Start Date ต้องไม่มากกว่าวันที่ End Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEndDate.SelectAll();
                    txtEndDate.Focus();
                    dgvDetailList.Rows.Clear();
                    return;
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกวันที่", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEndDate.SelectAll();
                txtEndDate.Focus();
                dgvDetailList.Rows.Clear();
                return;
            }

        }

        private void bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            saleList = svrsale.searchsaleorder(subStartdate, subenddate, model, customer);
        }

        private void bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtStartDate.Enabled = true;
            txtEndDate.Enabled = true;
            txtModel.Enabled = true;
            cbCustomer.Enabled = true;
            pictureLoading.Visible = false;
            btnSearch.Enabled = true;
            btnClear.Enabled = true;
            dgvDetailList.Rows.Clear();


            saleList = svrsale.searchsaleorder(subStartdate, subenddate, model, customer);

            if (saleList.Count > 0)
            {
                foreach (SaleAndLoadinginfo sale in saleList)
                {
                    dgvDetailList.Rows.Add(
                        sale.DOC_NO,
                        sale.INVOICE_NO,
                        sale.MODEL,
                        sale.CUSTOMER_NAME,
                        sale.TRUCK_NO,
                        sale.PALLET_NO,
                        sale.PALLET_TYPE,
                        sale.WAREHOUSE,
                        sale.CTNO,
                        sale.ETD,
                        sale.ORDER_TYPE,
                        sale.LOADDATE,
                        sale.DELBIT
                      );
                }

                pnDateDetail.ValuesSecondary.Heading = "จำนวน " + dgvDetailList.Rows.Count.ToString("N0") + " ข้อมูล";
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEndDate.SelectAll();
                txtEndDate.Focus();
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
                    //var workSheet = excel.Workbook.Worksheets.Add("Sheet1");   // ชื่อ sheet


                    //workSheet.TabColor = System.Drawing.Color.Red;
                    //workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    //workSheet.Row(1).Style.Font.Bold = true;


                    //// Header เริ่มที่ บรรทัดที่ 3 
                    //workSheet.Cells[3, 1].Value = "NO";
                    //workSheet.Cells[3, 2].Value = "DOC_NO";
                    //workSheet.Cells[3, 3].Value = "INVOICE _NO";
                    //workSheet.Cells[3, 4].Value = "MODEL";
                    //workSheet.Cells[3, 5].Value = "CUSTOMER";
                    //workSheet.Cells[3, 6].Value = "TRUCK_NO";
                    //workSheet.Cells[3, 7].Value = "PALLET_NO";
                    //workSheet.Cells[3, 8].Value = "PALLET_TYPE";
                    //workSheet.Cells[3, 9].Value = "WAREHOUSE";
                    //workSheet.Cells[3, 10].Value = "CTNO";
                    //workSheet.Cells[3, 11].Value = "ETD";
                    //workSheet.Cells[3, 12].Value = "ORDER_TYPE";
                    //workSheet.Cells[3, 13].Value = "LOADDATE";
                    //workSheet.Cells[3, 14].Value = "DELBIT";
                    //// Header เริ่มที่ บรรทัดที่ 3 

                    //int recordIndex = 4;  // ข้อมูลเริ่มบรรทัดที่ 4
                    //int rwd = 1;
                    //int rowCount = 1;


                    saleList = svrsale.saleorderExportForExcel(subStartdate, subenddate, model, customer);

                    // เขียนไฟล์.
                    using (var writer = new StreamWriter(saveFileDialog1.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(saleList);
                    }
                    // เขียนไฟล์.


                  //  // วนข้อมูล
                  //  foreach (SaleAndLoadinginfo item in saleList)
                  //  {
                  //      workSheet.Cells[recordIndex, 1].Value = rwd.ToString("N0");
                  //      workSheet.Cells[recordIndex, 2].Value = item.D_DONO;
                  //      workSheet.Cells[recordIndex, 3].Value = item.D_IVNO;
                  //      workSheet.Cells[recordIndex, 4].Value = item.D_MODEL;
                  //      workSheet.Cells[recordIndex, 5].Value = item.C_CUSTOMER_NAME;
                  //      workSheet.Cells[recordIndex, 6].Value = item.D_TRUCKNO;
                  //      workSheet.Cells[recordIndex, 7].Value = item.D_PLNO;
                  //      workSheet.Cells[recordIndex, 8].Value = item.D_PLTYPE;
                  //      workSheet.Cells[recordIndex, 9].Value = item.H_DELWH;
                  //      workSheet.Cells[recordIndex, 10].Value = item.H_CTNO;
                  //      workSheet.Cells[recordIndex, 11].Value = item.H_ETD;
                  //      workSheet.Cells[recordIndex, 12].Value = item.H_ORDTYPE;
                  //      workSheet.Cells[recordIndex, 13].Value = item.H_LOADDATE.ToString("dd/MM/yyyy");
                  //      workSheet.Cells[recordIndex, 14].Value = item.H_DELBIT;


                  //      for (int i = 1; i <= 14; i++)
                  //      {
                  //          workSheet.Cells[recordIndex, i].Style.Numberformat.Format = "_(* #,##0.00_);_(* (#,##0.00);_(* \" -\"??_);_(@_)";
                  //      }


                  //      rwd++;
                  //      recordIndex++;
                  //  }
                  ////  วนข้อมูล


                  //  for (int i = 1; i <= 15; i++)      // Column for Loop
                  //  {
                  //      workSheet.Column(i).AutoFit();
                  //  }


                   // excel.Save();


                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Export data complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEndDate_KeyDown(object sender, KeyEventArgs e)
        {// กด Enter 
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtStartDate_KeyPress(object sender, KeyPressEventArgs e)
        { // กรอกได้เฉพาะตัวเลข
            if (!char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void txtEndDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // กรอกได้เฉพาะตัวเลข
            if (!char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvDetailList.Rows.Clear();
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            txtModel.Text = "";
            cbCustomer.SelectedIndex = 0;
        }

        private void txtModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }

}
