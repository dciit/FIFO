
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_PARTFORECAST
{
    public class VenderPartService
    {
        private ConnectDB oConn = new ConnectDB("DBBCS");
        private ConnectDB oConnSCM = new ConnectDB("DBSCM");
        
        
        
        public List<PartOrderAmountInfo> GetPUPartAmountList(string fisy, string rev, string partno, string route, string catmat, string vender, string ordertype)
        {
            if (partno == "")
            {
                partno = "%";
            }

            if (route == "")
            {
                route = "%";
            }

            if (catmat == "")
            {
                catmat = "%";
            }

            if (vender == "")
            {
                vender = "%";
            }

            if (ordertype == "")
            {
                ordertype = "%";
            }
            

            List<PartOrderAmountInfo> puPartList = new List<PartOrderAmountInfo>();

            SqlCommand sqlSelect = new SqlCommand();
            sqlSelect.CommandText = @"SELECT PUP.FISY
              ,PUP.REV
              ,PUP.PARTNO
              ,PUP.CM, PT.PARTDESC, PUP.ORDER_TYPE
              ,PUP.VENDER, VD.VENDERNAME, PUP.VDRATIO
              ,PUP.VDRATIO
              ,PUP.ROUTE
              ,PUP.CATMAT
              ,PUP.LPRICE
              ,PUP.CURR, ISNULL(RATE.RATE,0) AS EXRATE
              ,PUP.IVUNIT
              ,PUP.APR_QTY
              ,PUP.MAY_QTY
              ,PUP.JUN_QTY
              ,PUP.JUL_QTY
              ,PUP.AUG_QTY
              ,PUP.SEP_QTY
              ,PUP.OCT_QTY
              ,PUP.NOV_QTY
              ,PUP.DEC_QTY
              ,PUP.JAN_QTY
              ,PUP.FEB_QTY
              ,PUP.MAR_QTY
               
              ,PR.CON_CODE
			  ,PR.CON_WEIGHT
			  ,PR.WHUNIT

              ,PUP.CREATE_DATE
              ,PUP.CREATE_BY, PUP.NONEED_BIT, PUP.NONEED_REASON, PUP.NONEED_DATE, PUP.NONEED_BY
              FROM dbBCS.dbo.STD_PART_USAGE AS PUP
              LEFT JOIN CST_PART_MASTER AS PT ON PUP.PARTNO = PT.PARTNO
              LEFT JOIN dbSCM.dbo.AL_Vendor AS VD ON PUP.VENDER = VD.VENDER
              LEFT JOIN dbBCS.dbo.STD_BUDGET_RATE AS RATE ON PUP.CURR = RATE.CURR AND PUP.FISY = RATE.FISY AND PUP.REV = RATE.REV
              LEFT JOIN STD_PART_PRICE AS PR ON PUP.FISY = PR.FISY AND PUP.REV = PR.REV AND PUP.PARTNO = PR.PARTNO AND PUP.VENDER = PR.VENDER AND PUP.CM = PR.CM
              WHERE PUP.FISY = @FISY AND PUP.REV = @REV
                AND PUP.PARTNO LIKE @PARTNO
                AND PUP.ROUTE LIKE @ROUTE
                AND PUP.CATMAT LIKE @CATMAT
                AND PUP.VENDER LIKE @VENDER 
                AND PUP.ORDER_TYPE LIKE @ORDERTYPE 
              ORDER BY PARTDESC, PARTNO, CM, VENDER ASC";
            sqlSelect.Parameters.Add(new SqlParameter("@FISY", fisy));
            sqlSelect.Parameters.Add(new SqlParameter("@REV", rev));
            sqlSelect.Parameters.Add(new SqlParameter("@PARTNO", partno));
            sqlSelect.Parameters.Add(new SqlParameter("@ROUTE", route));
            sqlSelect.Parameters.Add(new SqlParameter("@CATMAT", catmat));
            sqlSelect.Parameters.Add(new SqlParameter("@VENDER", vender));
            sqlSelect.Parameters.Add(new SqlParameter("@ORDERTYPE", ordertype));
            sqlSelect.CommandTimeout = 180;
            DataTable dtPuPart = oConn.Query(sqlSelect);
            if (dtPuPart.Rows.Count > 0)
            {
                foreach (DataRow drow in dtPuPart.Rows)
                {
                    PartOrderAmountInfo pupart = new PartOrderAmountInfo();
                    pupart.P_FISY = drow["FISY"].ToString();
                    pupart.P_REV = drow["REV"].ToString();
                    pupart.P_PARTNO = drow["PARTNO"].ToString();
                    pupart.P_CM = drow["CM"].ToString();
                    pupart.P_PARTNAME = drow["PARTDESC"].ToString();
                    pupart.P_ROUTE = drow["ROUTE"].ToString();
                    pupart.P_CATMAT = drow["CATMAT"].ToString();
                    pupart.P_VENDER = drow["VENDER"].ToString();
                    pupart.P_VDNAME = drow["VENDERNAME"].ToString();
                    pupart.P_PRICE = Convert.ToDouble(drow["LPRICE"].ToString());
                    pupart.P_CURRENCY = drow["CURR"].ToString();
                    pupart.P_EXRATE = Convert.ToDouble(drow["EXRATE"].ToString());
                    pupart.P_IVUNIT = drow["IVUNIT"].ToString();
                    pupart.P_ORDER_TYPE = drow["ORDER_TYPE"].ToString();
                    pupart.P_ORDER_RATIO = Convert.ToDouble(drow["VDRATIO"].ToString());

                    

                    double weight = 0;
                    try{
                        weight = Convert.ToDouble(drow["CON_WEIGHT"].ToString());
                    }catch { }

                    pupart.P_APR_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["APR_QTY"].ToString()) * weight : Convert.ToDouble(drow["APR_QTY"].ToString());
                    pupart.P_MAY_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["MAY_QTY"].ToString()) * weight : Convert.ToDouble(drow["MAY_QTY"].ToString());
                    pupart.P_JUN_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["JUN_QTY"].ToString()) * weight : Convert.ToDouble(drow["JUN_QTY"].ToString());
                    pupart.P_FEB_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["FEB_QTY"].ToString()) * weight : Convert.ToDouble(drow["FEB_QTY"].ToString());
                    pupart.P_JUL_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["JUL_QTY"].ToString()) * weight : Convert.ToDouble(drow["JUL_QTY"].ToString());
                    pupart.P_AUG_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["AUG_QTY"].ToString()) * weight : Convert.ToDouble(drow["AUG_QTY"].ToString());
                    pupart.P_SEP_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["SEP_QTY"].ToString()) * weight : Convert.ToDouble(drow["SEP_QTY"].ToString());
                    pupart.P_OCT_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["OCT_QTY"].ToString()) * weight : Convert.ToDouble(drow["OCT_QTY"].ToString());
                    pupart.P_NOV_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["NOV_QTY"].ToString()) * weight : Convert.ToDouble(drow["NOV_QTY"].ToString());
                    pupart.P_DEC_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["DEC_QTY"].ToString()) * weight : Convert.ToDouble(drow["DEC_QTY"].ToString());
                    pupart.P_JAN_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["JAN_QTY"].ToString()) * weight : Convert.ToDouble(drow["JAN_QTY"].ToString());
                    pupart.P_MAR_IV_QTY = (drow["CON_CODE"].ToString() == "4") ? Convert.ToDouble(drow["MAR_QTY"].ToString()) * weight : Convert.ToDouble(drow["MAR_QTY"].ToString());

                    if (pupart.P_ORDER_TYPE == "1")
                    {
                        pupart.P_APR_AMT = pupart.P_APR_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_MAY_AMT = pupart.P_MAY_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_JUN_AMT = pupart.P_JUN_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_JUL_AMT = pupart.P_JUL_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_AUG_AMT = pupart.P_AUG_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_SEP_AMT = pupart.P_SEP_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_OCT_AMT = pupart.P_OCT_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_NOV_AMT = pupart.P_NOV_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_DEC_AMT = pupart.P_DEC_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_JAN_AMT = pupart.P_JAN_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_FEB_AMT = pupart.P_FEB_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                        pupart.P_MAR_AMT = pupart.P_MAR_IV_QTY * pupart.P_PRICE * pupart.P_EXRATE;
                    }

                    pupart.P_CREATE_BY = drow["CREATE_BY"].ToString();
                    pupart.P_CREAET_DATE = Convert.ToDateTime(drow["CREATE_DATE"].ToString());
                    //pupart.P_NONEED_BIT = drow["NONEED_BIT"].ToString();
                    //pupart.P_NONEED_BY = drow["NONEED_BY"].ToString();
                    //pupart.P_NONEED_REASON = drow["NONEED_REASON"].ToString();
                    //try { pupart.P_NONEED_DATE = Convert.ToDateTime(drow["NONEED_DATE"].ToString()); } catch { }

                    puPartList.Add(pupart);
                }
            }

            return puPartList;
        }


    }
}
