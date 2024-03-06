using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCI_PARTFORECAST
{
    public partial class Home : Form
    {
        private string p_FISY = "";
        private string p_ROUTE = "";
        private string p_PARTNO = "";
        private string p_CATMAT = "";
        private string p_REV = "";
        private string p_VENDER = "";
        private string p_ORDER_TYPE = "";

        private string p_MenuId = "";
        private string p_USERNAME = "";

        
        private VenderPartService svrVenderPart = new VenderPartService();
        private List<PartOrderAmountInfo> puPartList = new List<PartOrderAmountInfo>();        
        private EmployeeService svrEmp = new EmployeeService();

        public Home(string empCode, string menuId)
        {
            EmployeeInfo empInfo = svrEmp.GetEmployeeData(empCode);
            if (empInfo.FullName != "")
            {
                InitializeComponent();
                this.kryptonHeaderGroup1.ValuesPrimary.Description = empInfo.FullName;
                this.kryptonHeaderGroup1.ValuesPrimary.Heading = menuId.ToUpper() + " " + kryptonHeaderGroup1.ValuesPrimary.Heading;
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

        private void Home_Load(object sender, EventArgs e)
        {
            Type dgvType = dgvPartList.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgvPartList, true, null);
        }
        
       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFISY.Text.Trim() != "" && txtREV.Text.Trim() != "")
            {
                p_FISY = txtFISY.Text.Trim();
                p_CATMAT = txtCATMAT.Text.Trim();
                p_REV = txtREV.Text.Trim();
                p_PARTNO = txtPARTNO.Text.Trim();
                p_ROUTE = txtROUTE.Text.Trim();
                p_VENDER = txtVENDER.Text.Trim();
                p_ORDER_TYPE = txtOrderType.Text.Trim();

                if (!bgLoadData.IsBusy)
                {
                    btnSearch.Enabled = false;
                    txtFISY.Enabled = false;
                    txtCATMAT.Enabled = false;
                    txtREV.Enabled = false;
                    txtPARTNO.Enabled = false;
                    txtROUTE.Enabled = false;
                    txtVENDER.Enabled = false;
                    txtOrderType.Enabled = false;

                    picStatusLoading.Visible = true;

                    bgLoadData.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Please input FISY !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtFISY.Focus();
                return;
            }
        }

        private void bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            puPartList = svrVenderPart.GetPUPartAmountList(p_FISY, p_REV, p_PARTNO, p_ROUTE, p_CATMAT, p_VENDER, p_ORDER_TYPE );
        }

        private void bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            txtFISY.Enabled = true;
            txtCATMAT.Enabled = true;
            txtREV.Enabled = true;
            txtPARTNO.Enabled = true;
            txtROUTE.Enabled = true;
            txtVENDER.Enabled = true;
            txtOrderType.Enabled = true;

            picStatusLoading.Visible = false;

            dgvPartList.Rows.Clear();

            if (puPartList.Count > 0)
            {
                foreach (PartOrderAmountInfo item in puPartList)
                {
                    string strREV = "";
                    if (item.P_REV == "01") { strREV = "OB"; }
                    else if (item.P_REV == "02") { strREV = "RB"; }
                    else if (item.P_REV == "03") { strREV = "FB"; }

                    dgvPartList.Rows.Add(
                        item.P_FISY, strREV, item.P_VENDER, item.P_VDNAME, item.P_PARTNO, item.P_CM, item.P_PARTNAME, item.P_ROUTE, 
                        item.P_CATMAT, item.P_ORDER_TYPE, item.P_ORDER_RATIO,
                        item.P_APR_IV_QTY, item.P_MAY_IV_QTY, item.P_JUN_IV_QTY, item.P_JUL_IV_QTY, item.P_AUG_IV_QTY, item.P_SEP_IV_QTY,
                        item.P_OCT_IV_QTY, item.P_NOV_IV_QTY, item.P_DEC_IV_QTY, item.P_JAN_IV_QTY, item.P_FEB_IV_QTY, item.P_MAR_IV_QTY,
                        item.P_TOTAL_IV_QTY, item.P_IVUNIT,
                        item.P_CREAET_DATE, item.P_CREATE_BY);
                }
            }

            kryptonHeaderGroup1.ValuesSecondary.Heading = "Found " + puPartList.Count.ToString("N0") + " Records.";
        }

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFISY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPartList.Rows.Count > 0)
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

                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    ExcelPackage excel = new ExcelPackage(fileInfo);
                    var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
                    workSheet.TabColor = System.Drawing.Color.Red;
                    workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Row(1).Style.Font.Bold = true;

                    workSheet.Cells[1, 1].Value = "FY" + puPartList[0].P_FISY+" PART MASTER PLAN";

                    workSheet.Cells[3, 1].Value = "NO";
                    workSheet.Cells[3, 2].Value = "YEAR";
                    workSheet.Cells[3, 3].Value = "VENDER";
                    workSheet.Cells[3, 4].Value = "VDNAME";
                    workSheet.Cells[3, 5].Value = "PARTNO";
                    workSheet.Cells[3, 6].Value = "CM";
                    workSheet.Cells[3, 7].Value = "PARTNAME";
                    workSheet.Cells[3, 8].Value = "APR_QTY";
                    workSheet.Cells[3, 9].Value = "MAY_QTY";
                    workSheet.Cells[3, 10].Value = "JUN_QTY";
                    workSheet.Cells[3, 11].Value = "JUL_QTY";
                    workSheet.Cells[3, 12].Value = "AUG_QTY";
                    workSheet.Cells[3, 13].Value = "SEP_QTY";
                    workSheet.Cells[3, 14].Value = "OCT_QTY";
                    workSheet.Cells[3, 15].Value = "NOV_QTY";
                    workSheet.Cells[3, 16].Value = "DEC_QTY";
                    workSheet.Cells[3, 17].Value = "JAN_QTY";
                    workSheet.Cells[3, 18].Value = "FEB_QTY";
                    workSheet.Cells[3, 19].Value = "MAR_QTY";
                    workSheet.Cells[3, 20].Value = "TOTAL_QTY";
                    workSheet.Cells[3, 21].Value = "UNIT";
                    

                    int recordIndex = 4;
                    int rwd = 1;
                    foreach (PartOrderAmountInfo item in puPartList)
                    {
                        workSheet.Cells[recordIndex, 1].Value = rwd.ToString("N0");
                        workSheet.Cells[recordIndex, 2].Value = item.P_FISY;
                        workSheet.Cells[recordIndex, 3].Value = item.P_VENDER;
                        workSheet.Cells[recordIndex, 4].Value = item.P_VDNAME;
                        workSheet.Cells[recordIndex, 5].Value = item.P_PARTNO;
                        workSheet.Cells[recordIndex, 6].Value = item.P_CM;
                        workSheet.Cells[recordIndex, 7].Value = item.P_PARTNAME;
                        
                        workSheet.Cells[recordIndex, 8].Value = item.P_APR_IV_QTY;
                        workSheet.Cells[recordIndex, 9].Value = item.P_MAY_IV_QTY;
                        workSheet.Cells[recordIndex, 10].Value = item.P_JUN_IV_QTY;
                        workSheet.Cells[recordIndex, 11].Value = item.P_JUL_IV_QTY;
                        workSheet.Cells[recordIndex, 12].Value = item.P_AUG_IV_QTY;
                        workSheet.Cells[recordIndex, 13].Value = item.P_SEP_IV_QTY;
                        workSheet.Cells[recordIndex, 14].Value = item.P_OCT_IV_QTY;
                        workSheet.Cells[recordIndex, 15].Value = item.P_NOV_IV_QTY;
                        workSheet.Cells[recordIndex, 16].Value = item.P_DEC_IV_QTY;
                        workSheet.Cells[recordIndex, 17].Value = item.P_JAN_IV_QTY;
                        workSheet.Cells[recordIndex, 18].Value = item.P_FEB_IV_QTY;
                        workSheet.Cells[recordIndex, 19].Value = item.P_MAR_IV_QTY;
                        workSheet.Cells[recordIndex, 20].Value = item.P_TOTAL_IV_QTY;

                        workSheet.Cells[recordIndex, 21].Value = item.P_IVUNIT;

                        for (int i = 8; i <= 20; i++)
                        {
                            workSheet.Cells[recordIndex, i].Style.Numberformat.Format = "_(* #,##0.00_);_(* (#,##0.00);_(* \" -\"??_);_(@_)";
                        }

                        rwd++;
                        recordIndex++;
                    }

                    for (int i = 1; i <= 21; i++)
                    {
                        workSheet.Column(i).AutoFit();

                    }

                    excel.Save();

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Export data complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void dgvPartList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);

            
        }

        private void txtFISY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        

        

        
    }
}
