using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH_OBSOLETEREPORT_ODM.Model;

namespace WH_OBSOLETEREPORT_ODM.Service
{
    internal class ObsoleteService
    {
        private ClsOraConnection oConOracle = new ClsOraConnection("ALPHAPD");
        private List<ObsoleteInfo> obsoList = new List<ObsoleteInfo>();

        public List<ObsoleteInfo> GetObsoleteODMList (string date,string nwc)
        {
            List<ObsoleteInfo> obsoleteODM = new List<ObsoleteInfo>();

            if (nwc == "ALL")
            {
                nwc = "'DCI','SKO','PDT','UNW','HWH','RPK','RWD','RWE','RWQ'";

                OracleCommand cmdObsoleteODM = new OracleCommand();
                cmdObsoleteODM.CommandText = @"SELECT F.MODEL, F.SERIAL, F.PLNO, F.PLTYPE, F.AREA, nwc WC , whcode WH, TO_CHAR(F.CDATE , 'dd/MM/yyyy') AS FG_DATE 
                                        , TO_CHAR(add_months(F.CDATE,12) , 'dd/MM/yyyy') AS SLOW_DATE 
                                        ,TO_CHAR(add_months(F.CDATE, 24) , 'dd/MM/yyyy') AS OBSOLETE_DATE  
                                        ,(SELECT COUNT(SERIAL) FROM FH001 WHERE PLNO = F.PLNO AND NWC = 'DCI' ) PL_QTY 
                                        ,CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + @"','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END STS  
                                         FROM SE.FH001 F
                                         WHERE nwc IN ("+ nwc + ") and PRDTYPE ='ODM' and  add_months(F.CDATE,12) < to_date('" + date + @"', 'yyyy-MM-dd')
                                         ORDER BY MODEL ASC, CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + "','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END ASC, PLNO ASC";
                DataTable dtObsolODM = oConOracle.Query(cmdObsoleteODM);
                if (dtObsolODM.Rows.Count > 0)
                {
                    foreach (DataRow item in dtObsolODM.Rows)
                    {
                        ObsoleteInfo dataObsoleteODM = new ObsoleteInfo();
                        dataObsoleteODM.MODEL = item["MODEL"].ToString();
                        dataObsoleteODM.SERIAL = item["SERIAL"].ToString();
                        dataObsoleteODM.PALLETNO = item["PLNO"].ToString();
                        dataObsoleteODM.PALLET_TYPE = item["PLTYPE"].ToString();
                        dataObsoleteODM.FGDATE = item["FG_DATE"].ToString();
                        dataObsoleteODM.SLOWDATE = item["SLOW_DATE"].ToString();
                        dataObsoleteODM.OBSOLETEDATE = item["OBSOLETE_DATE"].ToString();
                        dataObsoleteODM.UNIT = item["PL_QTY"].ToString();
                        dataObsoleteODM.AREA = item["AREA"].ToString();
                        dataObsoleteODM.CURRENT_WC = item["WC"].ToString();
                        dataObsoleteODM.WAREHOUSECODE = item["WH"].ToString();
                        dataObsoleteODM.STATUS = item["STS"].ToString();

                        obsoleteODM.Add(dataObsoleteODM);
                    }
                }
            }
            else
            {
                OracleCommand cmdObsoleteODM = new OracleCommand();
                cmdObsoleteODM.CommandText = @"SELECT F.MODEL, F.SERIAL, F.PLNO, F.PLTYPE, F.AREA, nwc WC , whcode WH, TO_CHAR(F.CDATE , 'dd/MM/yyyy') AS FG_DATE 
                                        , TO_CHAR(add_months(F.CDATE,12) , 'dd/MM/yyyy') AS SLOW_DATE 
                                        ,TO_CHAR(add_months(F.CDATE, 24) , 'dd/MM/yyyy') AS OBSOLETE_DATE  
                                        ,(SELECT COUNT(SERIAL) FROM FH001 WHERE PLNO = F.PLNO AND NWC = 'DCI' ) PL_QTY 
                                        ,CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + @"','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END STS  
                                         FROM SE.FH001 F
                                         WHERE nwc IN ('"+ nwc + "') and PRDTYPE ='ODM' and  add_months(F.CDATE,12) < to_date('" + date + @"', 'yyyy-MM-dd')
                                         ORDER BY MODEL ASC, CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + "','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END ASC, PLNO ASC";
                DataTable dtObsolODM = oConOracle.Query(cmdObsoleteODM);
                if (dtObsolODM.Rows.Count > 0)
                {
                    foreach (DataRow item in dtObsolODM.Rows)
                    {
                        ObsoleteInfo dataObsoleteODM = new ObsoleteInfo();
                        dataObsoleteODM.MODEL = item["MODEL"].ToString();
                        dataObsoleteODM.SERIAL = item["SERIAL"].ToString();
                        dataObsoleteODM.PALLETNO = item["PLNO"].ToString();
                        dataObsoleteODM.PALLET_TYPE = item["PLTYPE"].ToString();
                        dataObsoleteODM.FGDATE = item["FG_DATE"].ToString();
                        dataObsoleteODM.SLOWDATE = item["SLOW_DATE"].ToString();
                        dataObsoleteODM.OBSOLETEDATE = item["OBSOLETE_DATE"].ToString();
                        dataObsoleteODM.UNIT = item["PL_QTY"].ToString();
                        dataObsoleteODM.AREA = item["AREA"].ToString();
                        dataObsoleteODM.CURRENT_WC = item["WC"].ToString();
                        dataObsoleteODM.WAREHOUSECODE = item["WH"].ToString();
                        dataObsoleteODM.STATUS = item["STS"].ToString();

                        obsoleteODM.Add(dataObsoleteODM);
                    }
                }
            }


            return obsoleteODM;
        }

        public List<ObsoleteInfo> GetObsoleteODMExcelList(string date,string nwc)
        {
            List<ObsoleteInfo> obsoleteODMExcel = new List<ObsoleteInfo>();

            if (nwc == "ALL")
            {
                nwc = "'DCI','SKO','PDT','UNW','HWH','RPK','RWD','RWE','RWQ'";


                OracleCommand cmdObsoleteODMExcel = new OracleCommand();
                cmdObsoleteODMExcel.CommandText = @"SELECT F.MODEL, F.SERIAL, F.PLNO, F.PLTYPE, F.AREA, nwc WC , whcode WH, TO_CHAR(F.CDATE , 'dd/MM/yyyy') AS FG_DATE 
                                        , TO_CHAR(add_months(F.CDATE,12) , 'dd/MM/yyyy') AS SLOW_DATE 
                                        ,TO_CHAR(add_months(F.CDATE, 24) , 'dd/MM/yyyy') AS OBSOLETE_DATE  
                                        ,(SELECT COUNT(SERIAL) FROM FH001 WHERE PLNO = F.PLNO AND NWC = 'DCI' ) PL_QTY 
                                        ,CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + @"','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END STS  
                                         FROM SE.FH001 F
                                         WHERE nwc IN (" + nwc + ") and PRDTYPE ='ODM' and  add_months(F.CDATE,12) < to_date('" + date + @"', 'yyyy-MM-dd')
                                         ORDER BY MODEL ASC, CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + "','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END ASC, PLNO ASC";
                DataTable dtObsolODMExcel = oConOracle.Query(cmdObsoleteODMExcel);
                if (dtObsolODMExcel.Rows.Count > 0)
                {
                    foreach (DataRow item in dtObsolODMExcel.Rows)
                    {
                        ObsoleteInfo dataObsoleteODM = new ObsoleteInfo();
                        dataObsoleteODM.MODEL = item["MODEL"].ToString();
                        dataObsoleteODM.SERIAL = "'" + item["SERIAL"].ToString();
                        dataObsoleteODM.PALLETNO = "'" + item["PLNO"].ToString();
                        dataObsoleteODM.PALLET_TYPE = item["PLTYPE"].ToString();
                        dataObsoleteODM.FGDATE = "'" + item["FG_DATE"].ToString();
                        dataObsoleteODM.SLOWDATE = "'" + item["SLOW_DATE"].ToString();
                        dataObsoleteODM.OBSOLETEDATE = "'" + item["OBSOLETE_DATE"].ToString();
                        dataObsoleteODM.UNIT = "'" + item["PL_QTY"].ToString();
                        dataObsoleteODM.AREA = item["AREA"].ToString();
                        dataObsoleteODM.CURRENT_WC = item["WC"].ToString();
                        dataObsoleteODM.WAREHOUSECODE = item["WH"].ToString();
                        dataObsoleteODM.STATUS = item["STS"].ToString();

                        obsoleteODMExcel.Add(dataObsoleteODM);
                    }
                }
            }
            else
            {
                OracleCommand cmdObsoleteODMExcel = new OracleCommand();
                cmdObsoleteODMExcel.CommandText = @"SELECT F.MODEL, F.SERIAL, F.PLNO, F.PLTYPE, F.AREA, nwc WC , whcode WH, TO_CHAR(F.CDATE , 'dd/MM/yyyy') AS FG_DATE 
                                        , TO_CHAR(add_months(F.CDATE,12) , 'dd/MM/yyyy') AS SLOW_DATE 
                                        ,TO_CHAR(add_months(F.CDATE, 24) , 'dd/MM/yyyy') AS OBSOLETE_DATE  
                                        ,(SELECT COUNT(SERIAL) FROM FH001 WHERE PLNO = F.PLNO AND NWC = 'DCI' ) PL_QTY 
                                        ,CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + @"','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END STS  
                                         FROM SE.FH001 F
                                         WHERE nwc IN ('" + nwc + "') and PRDTYPE ='ODM' and  add_months(F.CDATE,12) < to_date('" + date + @"', 'yyyy-MM-dd')
                                         ORDER BY MODEL ASC, CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + "','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END ASC, PLNO ASC";
                DataTable dtObsolODMExcel = oConOracle.Query(cmdObsoleteODMExcel);
                if (dtObsolODMExcel.Rows.Count > 0)
                {
                    foreach (DataRow item in dtObsolODMExcel.Rows)
                    {
                        ObsoleteInfo dataObsoleteODM = new ObsoleteInfo();
                        dataObsoleteODM.MODEL = item["MODEL"].ToString();
                        dataObsoleteODM.SERIAL = "'" + item["SERIAL"].ToString();
                        dataObsoleteODM.PALLETNO = "'" + item["PLNO"].ToString();
                        dataObsoleteODM.PALLET_TYPE = item["PLTYPE"].ToString();
                        dataObsoleteODM.FGDATE = "'" + item["FG_DATE"].ToString();
                        dataObsoleteODM.SLOWDATE = "'" + item["SLOW_DATE"].ToString();
                        dataObsoleteODM.OBSOLETEDATE = "'" + item["OBSOLETE_DATE"].ToString();
                        dataObsoleteODM.UNIT = "'" + item["PL_QTY"].ToString();
                        dataObsoleteODM.AREA = item["AREA"].ToString();
                        dataObsoleteODM.CURRENT_WC = item["WC"].ToString();
                        dataObsoleteODM.WAREHOUSECODE = item["WH"].ToString();
                        dataObsoleteODM.STATUS = item["STS"].ToString();

                        obsoleteODMExcel.Add(dataObsoleteODM);
                    }
                }
            }


            return obsoleteODMExcel;
        }
    }
}
