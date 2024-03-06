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
using WH_OBSOLETEREPORT.Model;
using WH_OBSOLETEREPORT.Service;

namespace WH_OBSOLETEREPORT
{
    public partial class FrmFIFO : Form
    {
        private EmployeeService svrEmp = new EmployeeService();
        private ClsOraConnection oConOracle = new ClsOraConnection("ALPHAPD");
        private ObsoleteService svrObsolete = new ObsoleteService();
        private List<ObsoleteInfo> obsoleteList = new List<ObsoleteInfo>();
        private List<FIFOInfo> mFifoList = new List<FIFOInfo>();

        private string p_MenuId = "";
        private string p_USERNAME = "";
        private string fgType = "";
        private bool MType = true;
        private string model = "";
        private string modelcode = "";
        private string wc = "";
        private string palletType = "";

        public FrmFIFO(string empCode, string menuId)
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

        private void FrmFIFO_Load(object sender, EventArgs e)
        {
            // Code ทำให้ DatagridView ทำงานได้เร็วไม่กระตุก
            Type dgvType = dgvDetailList.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgvDetailList, true, null);
            // Code ทำให้ DatagridView ทำงานได้เร็วไม่กระตุก

            pictureLoading.Visible = false;
            cbModelType.Text = "1YC";
            cbNWC.Text = "ALL";
            //cbModelType.Text = "ALL";

            ckModelCode_CheckedChanged(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            fgType = cbModelType.Text;
            model = cbModel.Text;
            wc = cbNWC.Text;
            palletType = cbPalletType.Text;
            modelcode = txtModelCode.Text;
            MType = ckModelCode.Checked;

            //if (txtModelCode.Text != "")
            //{
                if (!bgLoadData.IsBusy)   // เช็คว่า BackgroundWorker  ทำงานอยู่หรือไม่ ถ้าไม่ให้ทำงาน
                {
                    cbModelType.Enabled = false;
                    cbModel.Enabled = false;
                    cbNWC.Enabled = false;
                    pictureLoading.Visible = true;
                    cbPalletType.Enabled = false;
                    btnSearch.Enabled = false;
                    btnClear.Enabled = false;
                    txtModelCode.Enabled = false;
                    bgLoadData.RunWorkerAsync();
                }
            //}
            //else
            //{
            //    MessageBox.Show("กรุณากรอก Model Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}


        }

        private void bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            mFifoList = svrObsolete.GetFIFOList(MType, model, modelcode, wc, palletType);
        }

        private void bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvDetailList.Rows.Clear();
            pictureLoading.Visible = false;

            cbModelType.Enabled = true;
            cbModel.Enabled = true;
            cbNWC.Enabled = true;
            cbPalletType.Enabled = true;
            btnSearch.Enabled = true;
            btnClear.Enabled = true;
            txtModelCode.Enabled = true;

            mFifoList = svrObsolete.GetFIFOList(MType, model, modelcode, wc, palletType);

            if (mFifoList.Count > 0)
            {
                foreach (FIFOInfo fifo in mFifoList)
                {
                    dgvDetailList.Rows.Add(
                        fifo.MODEL_NAME,
                        fifo.MODEL_CODE,
                        fifo.PALLET_NO,
                        fifo.PALLET_TYPE,
                        fifo.QTY_IN_PALLET,
                        fifo.LOCATION_CODE,
                        fifo.FINISHED_GOODS_DATE.ToString(),
                        fifo.WAREHOUSE_DATE,
                        fifo.WAREHOUSE_CODE,
                        fifo.LINE,
                        fifo.CurrnetWCDate,
                        fifo.PreviousWC
                      );
                    ;
                }

                Header.ValuesSecondary.Heading = "จำนวน " + dgvDetailList.Rows.Count.ToString("N0") + " ข้อมูล";
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvDetailList.Rows.Clear();
                Header.ValuesSecondary.Heading = "จำนวน " + dgvDetailList.Rows.Count.ToString("N0") + " ข้อมูล";
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


                    mFifoList = svrObsolete.GetFIFOForExcelList(MType, model, modelcode, wc, palletType);

                    // เขียนไฟล์.
                    using (var writer = new StreamWriter(saveFileDialog1.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(mFifoList);
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

        private void txtModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbNWC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbModelType.Text = "ALL";
            cbModel.Text = "ALL";
            cbNWC.Text = "ALL";
            cbPalletType.Text = "ALL";
            dgvDetailList.Rows.Clear();
        }

        private void dgvDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<FIFOInfo> modelList = new List<FIFOInfo>();

            string model = cbModel.Text;

            modelList = svrObsolete.GetPalletType(model);

            cbPalletType.DataSource = modelList;
            cbPalletType.ValueMember = "PALLET_TYPE";
            cbPalletType.DisplayMember = "PALLET_TYPE";

            btnSearch.Enabled = true;
        }

        private void cbModelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<FIFOInfo> modelList = new List<FIFOInfo>();

            string typeModel = cbModelType.Text;

            modelList = svrObsolete.Getmodel(typeModel);

            cbModel.DataSource = modelList;
            cbModel.ValueMember = "MODEL_NAME";
            cbModel.DisplayMember = "MODEL_NAME";

            btnSearch.Enabled = true;
        }

        private void ckModelCode_CheckedChanged(object sender, EventArgs e)
        {
            if (ckModelCode.Checked)
            {
                txtModelCode.Enabled = true;
                txtModelCode.Visible = true;
                cbModel.Enabled = false;
                pnModel.Visible = false;
            }
            else
            {
                txtModelCode.Enabled = false;
                txtModelCode.Visible = false;
                cbModel.Enabled = true;
                pnModel.Visible = true;
            }
        }
    }
}
