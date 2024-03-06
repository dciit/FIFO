using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_PARTFORECAST
{
    public class PartPurchaseDataService
    {
        private ConnectDB oConn = new ConnectDB("DBBCS");

        public PartPurchaseDataInfo GetPartPurchaseInfo(string fisy, string rev, string partno, string cm, string vender)
        {
            PartPurchaseDataInfo pupartinfo = new PartPurchaseDataInfo();

            SqlCommand sqlSelect = new SqlCommand();
            sqlSelect.CommandText = @" SELECT PUP.FISY, PUP.REV, PUP.PARTNO, PUP.CM, PT.PARTDESC, PT.UNIT WHUNIT, PUP.VENDER, VD.VENDERNAME, PUP.ROUTE, PUP.CATMAT, PUP.ORDER_TYPE, PUP.LPRICE, PUP.CURR, 
	        PUP.IVUNIT, PUP.NONEED_BIT, PUP.NONEED_BY, PUP.NONEED_DATE, PUP.NONEED_REASON
            FROM STD_PART_USAGE PUP
            LEFT JOIN CST_PART_MASTER PT ON PUP.PARTNO = PT.PARTNO
            LEFT JOIN dbSCM.dbo.AL_VENDOR VD ON PUP.VENDER = VD.VENDER
            WHERE PUP.FISY = @FISY AND PUP.REV = @REV AND PUP.PARTNO = @PARTNO AND PUP.CM = @CM AND PUP.VENDER = @VENDER";
            sqlSelect.Parameters.Add(new SqlParameter("@FISY", fisy));
            sqlSelect.Parameters.Add(new SqlParameter("@REV", rev));
            sqlSelect.Parameters.Add(new SqlParameter("@PARTNO", partno));
            sqlSelect.Parameters.Add(new SqlParameter("@CM", cm));
            sqlSelect.Parameters.Add(new SqlParameter("@VENDER", vender));
            sqlSelect.CommandTimeout = 180;
            DataTable dtPart = oConn.Query(sqlSelect);
            if (dtPart.Rows.Count > 0)
            {
                foreach (DataRow drow in dtPart.Rows)
                {
                    pupartinfo.P_FISY = drow["FISY"].ToString();
                    pupartinfo.P_REV = drow["REV"].ToString();
                    pupartinfo.P_PARTNO = drow["PARTNO"].ToString();
                    pupartinfo.P_CM = drow["CM"].ToString();
                    pupartinfo.P_PARTNAME = drow["PARTDESC"].ToString();
                    pupartinfo.P_WHUNIT = drow["WHUNIT"].ToString();
                    pupartinfo.P_VENDER = drow["VENDER"].ToString();
                    pupartinfo.P_VDNAME = drow["VENDERNAME"].ToString();
                    pupartinfo.P_ROUTE = drow["ROUTE"].ToString();
                    pupartinfo.P_CATMAT = drow["CATMAT"].ToString();
                    pupartinfo.P_ORDER_TYPE = drow["ORDER_TYPE"].ToString();
                    pupartinfo.P_UNIT_PRICE = Convert.ToDouble(drow["LPRICE"].ToString());
                    pupartinfo.P_CURRENCY = drow["CURR"].ToString();
                    pupartinfo.P_IVUNIT = drow["IVUNIT"].ToString();
                    pupartinfo.P_NONEED = drow["NONEED_BIT"].ToString();
                    pupartinfo.P_NONEED_REASON = drow["NONEED_REASON"].ToString();
                }
            }

            return pupartinfo;
        }

        public void SetPartNoNeedData(PartPurchaseDataInfo partpu)
        {
            SqlCommand sqlUpdate = new SqlCommand();
            sqlUpdate.CommandText = @"UPDATE STD_PART_USAGE 
                SET NONEED_BIT = @NONEED_BIT, NONEED_BY = @NONEED_BY, NONEED_DATE = @NONEED_DATE, NONEED_REASON = @NONEED_REASON, CURR = @CURR,
                    ORDER_TYPE = @ORDER_TYPE, LPRICE = @LPRICE
                WHERE FISY = @FISY AND REV = @REV AND PARTNO = @PARTNO AND CM = @CM AND VENDER = @VENDER";
            sqlUpdate.Parameters.Add(new SqlParameter("@NONEED_BIT", partpu.P_NONEED));
            sqlUpdate.Parameters.Add(new SqlParameter("@NONEED_BY", partpu.P_NONEED_BY));
            sqlUpdate.Parameters.Add(new SqlParameter("@NONEED_DATE", DateTime.Now));
            sqlUpdate.Parameters.Add(new SqlParameter("@NONEED_REASON", partpu.P_NONEED_REASON));
            sqlUpdate.Parameters.Add(new SqlParameter("@ORDER_TYPE", partpu.P_ORDER_TYPE));
            sqlUpdate.Parameters.Add(new SqlParameter("@CURR", partpu.P_CURRENCY));
            sqlUpdate.Parameters.Add(new SqlParameter("@LPRICE", partpu.P_UNIT_PRICE));
            sqlUpdate.Parameters.Add(new SqlParameter("@FISY", partpu.P_FISY));
            sqlUpdate.Parameters.Add(new SqlParameter("@REV", partpu.P_REV));
            sqlUpdate.Parameters.Add(new SqlParameter("@PARTNO", partpu.P_PARTNO));
            sqlUpdate.Parameters.Add(new SqlParameter("@CM", partpu.P_CM));
            sqlUpdate.Parameters.Add(new SqlParameter("@VENDER", partpu.P_VENDER));
            oConn.ExecuteCommand(sqlUpdate);
        }
    }
}
