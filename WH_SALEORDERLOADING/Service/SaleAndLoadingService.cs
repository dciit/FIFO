using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH_SALEORDERLOADING.Model;

namespace WH_SALEORDERLOADING.Service
{
    internal class SaleAndLoadingService
    {
        private EmployeeService svrEmp = new EmployeeService();
        private List<SaleAndLoadinginfo> pusaleList = new List<SaleAndLoadinginfo>();
        private ClsOraConnection oConOracle = new ClsOraConnection("ALPHAPD");

        public List<SaleAndLoadinginfo> searchsaleorder(string subStartdate, string subenddate , string model , string customer)
        {
            if (model == "")
            {
                model = "%";
            }


            List<SaleAndLoadinginfo> saleorderData = new List<SaleAndLoadinginfo>();
            OracleCommand sqlselect = new OracleCommand();
            sqlselect.CommandText = @"SELECT W.CUSTCODE, C.CUSTNAME, W.DELSTS,  D.DONO, D.IVNO, D.MODEL, D.DELWH, D.TRUCKNO, D.PLNO, D.PLTYPE, H.CTNO, H.ETD, H.ORDTYPE,
                                        TO_CHAR(H.LOADDATE, 'dd/MM/yyyy')  AS LOADDATE , H.DELBIT, COUNT(SERIAL) CNT
                                        FROM SE.WMS_DELSER D
                                        LEFT JOIN SE.WMS_DELCTD H ON H.DONO = D.DONO AND H.IVNO = D.IVNO AND H.COMID = 'DCI'
                                        LEFT JOIN SE.WMS_DELCTL W ON W.DONO = D.DONO AND W.IVNO = D.IVNO AND W.COMID = 'DCI' 
                                        LEFT JOIN SE.WMS_MSTCUS C ON C.CUSTCODE = W.CUSTCODE AND C.COMID = 'DCI' AND LREV = '999'  
                                        WHERE D.COMID = 'DCI' AND (MODEL LIKE '1Y%' OR MODEL LIKE '2Y%' OR MODEL LIKE 'J%')
                                        AND TO_CHAR(H.LOADDATE, 'YYYY-MM-DD') BETWEEN :SDATE AND :EDATE   AND  D.MODEL LIKE :MODEL  AND C.CUSTCODE LIKE :CUSTOMER
                                        GROUP BY W.CUSTCODE, W.DELSTS, C.CUSTNAME, D.DONO, D.IVNO, D.MODEL, D.DELWH, D.TRUCKNO, D.PLNO, D.PLTYPE, H.CTNO, H.ETD, H.ORDTYPE, LOADDATE , H.DELBIT    
                                        ORDER BY LOADDATE  ASC";
            sqlselect.Parameters.Add(new OracleParameter(":SDATE", subStartdate));
            sqlselect.Parameters.Add(new OracleParameter(":EDATE", subenddate));
            sqlselect.Parameters.Add(new OracleParameter(":MODEL", model));
            sqlselect.Parameters.Add(new OracleParameter(":CUSTOMER", customer));
            DataTable dtWIPStock = oConOracle.Query(sqlselect);

            if (dtWIPStock.Rows.Count > 0)
            {
                foreach (DataRow item in dtWIPStock.Rows)
                {
                    SaleAndLoadinginfo dtSaleorder = new SaleAndLoadinginfo();
                    dtSaleorder.DOC_NO = item["DONO"].ToString();
                    dtSaleorder.INVOICE_NO = item["IVNO"].ToString();
                    dtSaleorder.MODEL = item["MODEL"].ToString();
                    dtSaleorder.CUSTOMER_CODE = item["CUSTCODE"].ToString();
                    dtSaleorder.CUSTOMER_NAME = item["CUSTNAME"].ToString();
                    dtSaleorder.TRUCK_NO = item["TRUCKNO"].ToString();
                    dtSaleorder.PALLET_NO = item["PLNO"].ToString();
                    dtSaleorder.PALLET_TYPE = item["PLTYPE"].ToString();
                    dtSaleorder.WAREHOUSE = item["DELWH"].ToString();
                    dtSaleorder.CTNO = item["CTNO"].ToString();
                    dtSaleorder.ETD = item["ETD"].ToString();
                    dtSaleorder.ORDER_TYPE = item["ORDTYPE"].ToString();
                    dtSaleorder.LOADDATE = item["LOADDATE"].ToString(); 
                    dtSaleorder.DELBIT = item["DELBIT"].ToString();

                    saleorderData.Add(dtSaleorder);
                }
            }

            return saleorderData;
        }


        public List<SaleAndLoadinginfo> saleorderExportForExcel(string subStartdate, string subenddate, string model, string customer)
        {
            if (model == "")
            {
                model = "%";
            }


            List<SaleAndLoadinginfo> saleorderData = new List<SaleAndLoadinginfo>();
            OracleCommand sqlselect = new OracleCommand();
            sqlselect.CommandText = @"SELECT W.CUSTCODE, C.CUSTNAME, W.DELSTS,  D.DONO, D.IVNO, D.MODEL, D.DELWH, D.TRUCKNO, D.PLNO, D.PLTYPE, H.CTNO, H.ETD, H.ORDTYPE,
                                        TO_CHAR(H.LOADDATE, 'dd/MM/yyyy')  AS LOADDATE , H.DELBIT, COUNT(SERIAL) CNT
                                        FROM SE.WMS_DELSER D
                                        LEFT JOIN SE.WMS_DELCTD H ON H.DONO = D.DONO AND H.IVNO = D.IVNO AND H.COMID = 'DCI'
                                        LEFT JOIN SE.WMS_DELCTL W ON W.DONO = D.DONO AND W.IVNO = D.IVNO AND W.COMID = 'DCI' 
                                        LEFT JOIN SE.WMS_MSTCUS C ON C.CUSTCODE = W.CUSTCODE AND C.COMID = 'DCI' AND LREV = '999'  
                                        WHERE D.COMID = 'DCI' AND (MODEL LIKE '1Y%' OR MODEL LIKE '2Y%' OR MODEL LIKE 'J%')
                                        AND TO_CHAR(H.LOADDATE, 'YYYY-MM-DD') BETWEEN :SDATE AND :EDATE   AND  D.MODEL LIKE :MODEL  AND C.CUSTCODE LIKE :CUSTOMER
                                        GROUP BY W.CUSTCODE, W.DELSTS, C.CUSTNAME, D.DONO, D.IVNO, D.MODEL, D.DELWH, D.TRUCKNO, D.PLNO, D.PLTYPE, H.CTNO, H.ETD, H.ORDTYPE, LOADDATE , H.DELBIT    
                                        ORDER BY LOADDATE  ASC";
            sqlselect.Parameters.Add(new OracleParameter(":SDATE", subStartdate));
            sqlselect.Parameters.Add(new OracleParameter(":EDATE", subenddate));
            sqlselect.Parameters.Add(new OracleParameter(":MODEL", model));
            sqlselect.Parameters.Add(new OracleParameter(":CUSTOMER", customer));
            DataTable dtWIPStock = oConOracle.Query(sqlselect);

            if (dtWIPStock.Rows.Count > 0)
            {
                foreach (DataRow item in dtWIPStock.Rows)
                {
                    SaleAndLoadinginfo dtSaleorder = new SaleAndLoadinginfo();
                    dtSaleorder.DOC_NO = "'" + item["DONO"].ToString();
                    dtSaleorder.INVOICE_NO = item["IVNO"].ToString();
                    dtSaleorder.MODEL = item["MODEL"].ToString();
                    dtSaleorder.CUSTOMER_CODE = "'" + item["CUSTCODE"].ToString();
                    dtSaleorder.CUSTOMER_NAME = item["CUSTNAME"].ToString();
                    dtSaleorder.TRUCK_NO = "'" + item["TRUCKNO"].ToString();
                    /* dtSaleorder.D_PLNO = "'" + item["PLNO"].ToString(); */ // กรณีมี 0 นำหน้าพอ Export เป็น Excel 0 จะหาย จึงต้องใส่ " ' "  "singercode"
                    dtSaleorder.PALLET_NO = "'" + item["PLNO"].ToString();
                    dtSaleorder.PALLET_TYPE = item["PLTYPE"].ToString();
                    dtSaleorder.WAREHOUSE = item["DELWH"].ToString();
                    dtSaleorder.CTNO = "'" + item["CTNO"].ToString();
                    dtSaleorder.ETD = item["ETD"].ToString();
                    dtSaleorder.ORDER_TYPE = item["ORDTYPE"].ToString();
                    dtSaleorder.LOADDATE = "'" +  item["LOADDATE"].ToString();
                    dtSaleorder.DELBIT = item["DELBIT"].ToString();

                    saleorderData.Add(dtSaleorder);
                }
            }

            return saleorderData;
        }

        public List<SaleAndLoadinginfo> CustomerList()
        {

            List<SaleAndLoadinginfo> customerdata = new List<SaleAndLoadinginfo>();

            SaleAndLoadinginfo drowcustomerALL = new SaleAndLoadinginfo();
            drowcustomerALL.CUSTOMER_CODE = "%";
            drowcustomerALL.CUSTOMER_NAME = "ALL";

            customerdata.Add(drowcustomerALL);



            OracleCommand sqlcustomer = new OracleCommand();
            sqlcustomer.CommandText = @"select C.CUSTCODE, C.CUSTNAME FROM SE.WMS_MSTCUS C WHERE C.COMID = 'DCI' AND LREV = '999'";
            DataTable dtcustomer = oConOracle.Query(sqlcustomer);

            if (dtcustomer.Rows.Count > 0)
            {
                foreach (DataRow item in dtcustomer.Rows)
                {
                    SaleAndLoadinginfo drowcustomer = new SaleAndLoadinginfo();
                    drowcustomer.CUSTOMER_CODE = item["CUSTCODE"].ToString();
                    drowcustomer.CUSTOMER_NAME = item["CUSTCODE"].ToString() + " : " + item["CUSTNAME"].ToString();

                    customerdata.Add(drowcustomer);
                }
            }

            return customerdata;
        }
    }
}
