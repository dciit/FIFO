using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH_MODELPALLET_REPORT.Model;
using WH_OBSOLETEREPORT.Model;

namespace WH_OBSOLETEREPORT.Service
{
    internal class ObsoleteService
    {
        private ClsOraConnection oConOracle = new ClsOraConnection("ALPHAPD");
        private List<ObsoleteInfo> obsoList = new List<ObsoleteInfo>();
        private List<ObsoletePDTInfo> obsoPDTList = new List<ObsoletePDTInfo>();
        private List<FIFOInfo> fifoList = new List<FIFOInfo>();

        public List<ObsoleteInfo> GetObsoleteExcelList(string date, string nwc)
        {
            List<ObsoleteInfo> obsoleteExcelDate = new List<ObsoleteInfo>();

            if (nwc == "ALL")
            {
                nwc = "'DCI','SKO','PDT','UNW','RPK'";


                OracleCommand sqlobsoleteExcel = new OracleCommand();
                sqlobsoleteExcel.CommandText = @"SELECT F.MODEL, F.SERIAL, F.PLNO, F.PLTYPE, F.AREA, nwc WC , whcode WH, TO_CHAR(F.CDATE , 'dd/MM/yyyy') AS FG_DATE , TO_CHAR(add_months(F.CDATE,12) , 'dd/MM/yyyy') AS SLOW_DATE , TO_CHAR(add_months(F.CDATE, 24) , 'dd/MM/yyyy') AS OBSOLETE_DATE  ,(SELECT COUNT(SERIAL) FROM FH001 WHERE PLNO = F.PLNO AND NWC = 'DCI' ) PL_QTY 
                                        ,CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + @"','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END STS  
                                        FROM SE.FH001 F
                                        WHERE nwc IN (" + nwc + ") and PRDTYPE ='COM' and  add_months(F.CDATE,12) < to_date('" + date + @"', 'yyyy-MM-dd')
                                        ORDER BY MODEL ASC, CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + "','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END ASC, PLNO ASC";
                DataTable dtObsoleteexcel = oConOracle.Query(sqlobsoleteExcel);
                if (dtObsoleteexcel.Rows.Count > 0)
                {
                    int sumunit = 0;
                    foreach (DataRow item in dtObsoleteexcel.Rows)
                    {
                        ObsoleteInfo dataObsolete = new ObsoleteInfo();
                        dataObsolete.MODEL = item["MODEL"].ToString();
                        dataObsolete.SERIAL = "'" + item["SERIAL"].ToString();
                        dataObsolete.PALLETNO = "'" + item["PLNO"].ToString();
                        dataObsolete.PALLET_TYPE = item["PLTYPE"].ToString();
                        dataObsolete.FGDATE = "'" + item["FG_DATE"].ToString();
                        dataObsolete.SLOWDATE = "'" + item["SLOW_DATE"].ToString();
                        dataObsolete.OBSOLETEDATE = "'" + item["OBSOLETE_DATE"].ToString();
                        dataObsolete.UNIT = "'" + item["PL_QTY"].ToString();
                        dataObsolete.AREA = item["AREA"].ToString();
                        dataObsolete.CURRENT_WC = item["WC"].ToString();
                        dataObsolete.WAREHOUSECODE = item["WH"].ToString();
                        dataObsolete.STATUS = item["STS"].ToString();

                        sumunit += Convert.ToInt16(item["PL_QTY"].ToString());

                        obsoleteExcelDate.Add(dataObsolete);
                    }
                }
            }
            else
            {

                OracleCommand sqlobsoleteExcel = new OracleCommand();
                sqlobsoleteExcel.CommandText = @"SELECT F.MODEL, F.SERIAL, F.PLNO, F.PLTYPE, F.AREA, nwc WC , whcode WH, TO_CHAR(F.CDATE , 'dd/MM/yyyy') AS FG_DATE , TO_CHAR(add_months(F.CDATE,12) , 'dd/MM/yyyy') AS SLOW_DATE , TO_CHAR(add_months(F.CDATE, 24) , 'dd/MM/yyyy') AS OBSOLETE_DATE  ,(SELECT COUNT(SERIAL) FROM FH001 WHERE PLNO = F.PLNO AND NWC = 'DCI' ) PL_QTY 
                                        ,CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + @"','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END STS  
                                        FROM SE.FH001 F
                                        WHERE nwc IN ('" + nwc + "') and PRDTYPE ='COM' and  add_months(F.CDATE,12) < to_date('" + date + @"', 'yyyy-MM-dd')
                                        ORDER BY MODEL ASC, CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + "','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END ASC, PLNO ASC";
                DataTable dtObsoleteexcel = oConOracle.Query(sqlobsoleteExcel);
                if (dtObsoleteexcel.Rows.Count > 0)
                {
                    int sumunit = 0;
                    foreach (DataRow item in dtObsoleteexcel.Rows)
                    {
                        ObsoleteInfo dataObsolete = new ObsoleteInfo();
                        dataObsolete.MODEL = item["MODEL"].ToString();
                        dataObsolete.SERIAL = "'" + item["SERIAL"].ToString();
                        dataObsolete.PALLETNO = "'" + item["PLNO"].ToString();
                        dataObsolete.PALLET_TYPE = item["PLTYPE"].ToString();
                        dataObsolete.FGDATE = "'" + item["FG_DATE"].ToString();
                        dataObsolete.SLOWDATE = "'" + item["SLOW_DATE"].ToString();
                        dataObsolete.OBSOLETEDATE = "'" + item["OBSOLETE_DATE"].ToString();
                        dataObsolete.UNIT = "'" + item["PL_QTY"].ToString();
                        dataObsolete.AREA = item["AREA"].ToString();
                        dataObsolete.CURRENT_WC = item["WC"].ToString();
                        dataObsolete.WAREHOUSECODE = item["WH"].ToString();
                        dataObsolete.STATUS = item["STS"].ToString();

                        sumunit += Convert.ToInt16(item["PL_QTY"].ToString());

                        obsoleteExcelDate.Add(dataObsolete);
                    }
                }
            }



            return obsoleteExcelDate;
        }

        public List<ObsoleteInfo> GetObsoleteList(string date, string nwc)
        {
            List<ObsoleteInfo> obsoleteDate = new List<ObsoleteInfo>();

            if (nwc == "ALL")
            {
                nwc = "'DCI','SKO','PDT','UNW','RPK'";

                OracleCommand sqlobsolete = new OracleCommand();
                sqlobsolete.CommandText = @"SELECT F.MODEL, F.SERIAL, F.PLNO, F.PLTYPE, F.AREA, nwc WC , whcode WH, TO_CHAR(F.CDATE , 'dd/MM/yyyy') AS FG_DATE , TO_CHAR(add_months(F.CDATE,12) , 'dd/MM/yyyy') AS SLOW_DATE , TO_CHAR(add_months(F.CDATE, 24) , 'dd/MM/yyyy') AS OBSOLETE_DATE  ,(SELECT COUNT(SERIAL) FROM FH001 WHERE PLNO = F.PLNO AND NWC = 'DCI' ) PL_QTY 
                                        ,CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + @"','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END STS  
                                        FROM SE.FH001 F
                                        WHERE nwc IN (" + nwc + ") and PRDTYPE ='COM' and  add_months(F.CDATE,12) < to_date('" + date + @"', 'yyyy-MM-dd')
                                        ORDER BY MODEL ASC, CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + "','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END ASC, PLNO ASC";
                DataTable dtObsolete = oConOracle.Query(sqlobsolete);
                if (dtObsolete.Rows.Count > 0)
                {
                    int sumunit = 0;
                    foreach (DataRow item in dtObsolete.Rows)
                    {
                        ObsoleteInfo dataObsolete = new ObsoleteInfo();
                        dataObsolete.MODEL = item["MODEL"].ToString();
                        dataObsolete.SERIAL = item["SERIAL"].ToString();
                        dataObsolete.PALLETNO = item["PLNO"].ToString();
                        dataObsolete.PALLET_TYPE = item["PLTYPE"].ToString();
                        dataObsolete.FGDATE = item["FG_DATE"].ToString();
                        dataObsolete.SLOWDATE = item["SLOW_DATE"].ToString();
                        dataObsolete.OBSOLETEDATE = item["OBSOLETE_DATE"].ToString();
                        dataObsolete.UNIT = item["PL_QTY"].ToString();
                        dataObsolete.AREA = item["AREA"].ToString();
                        dataObsolete.CURRENT_WC = item["WC"].ToString();
                        dataObsolete.WAREHOUSECODE = item["WH"].ToString();
                        dataObsolete.STATUS = item["STS"].ToString();

                        sumunit += Convert.ToInt16(item["PL_QTY"].ToString());

                        obsoleteDate.Add(dataObsolete);
                    }
                }
            }
            else
            {
                //--  List<ObsoleteInfo> obsoleteDate = new List<ObsoleteInfo>();
                OracleCommand sqlobsolete = new OracleCommand();
                sqlobsolete.CommandText = @"SELECT F.MODEL, F.SERIAL, F.PLNO, F.PLTYPE, F.AREA, nwc WC , whcode WH, TO_CHAR(F.CDATE , 'dd/MM/yyyy') AS FG_DATE , TO_CHAR(add_months(F.CDATE,12) , 'dd/MM/yyyy') AS SLOW_DATE , TO_CHAR(add_months(F.CDATE, 24) , 'dd/MM/yyyy') AS OBSOLETE_DATE  ,(SELECT COUNT(SERIAL) FROM FH001 WHERE PLNO = F.PLNO AND NWC = 'DCI' ) PL_QTY 
                                        ,CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + @"','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END STS  
                                        FROM SE.FH001 F
                                        WHERE nwc IN ('" + nwc + "') and PRDTYPE ='COM' and  add_months(F.CDATE,12) < to_date('" + date + @"', 'yyyy-MM-dd')
                                        ORDER BY MODEL ASC, CASE WHEN  add_months(F.CDATE,24) < to_date('" + date + "','yyyy-MM-dd') THEN 'OBSOLETE' ELSE 'SLOW' END ASC, PLNO ASC";
                DataTable dtObsolete = oConOracle.Query(sqlobsolete);
                if (dtObsolete.Rows.Count > 0)
                {
                    int sumunit = 0;
                    foreach (DataRow item in dtObsolete.Rows)
                    {
                        ObsoleteInfo dataObsolete = new ObsoleteInfo();
                        dataObsolete.MODEL = item["MODEL"].ToString();
                        dataObsolete.SERIAL = item["SERIAL"].ToString();
                        dataObsolete.PALLETNO = item["PLNO"].ToString();
                        dataObsolete.PALLET_TYPE = item["PLTYPE"].ToString();
                        dataObsolete.FGDATE = item["FG_DATE"].ToString();
                        dataObsolete.SLOWDATE = item["SLOW_DATE"].ToString();
                        dataObsolete.OBSOLETEDATE = item["OBSOLETE_DATE"].ToString();
                        dataObsolete.UNIT = item["PL_QTY"].ToString();
                        dataObsolete.AREA = item["AREA"].ToString();
                        dataObsolete.CURRENT_WC = item["WC"].ToString();
                        dataObsolete.WAREHOUSECODE = item["WH"].ToString();
                        dataObsolete.STATUS = item["STS"].ToString();

                        sumunit += Convert.ToInt16(item["PL_QTY"].ToString());

                        obsoleteDate.Add(dataObsolete);
                    }
                }
            }

            return obsoleteDate;
        }

        public List<FIFOInfo> GetFIFOList(string model, string nwc)
        {
            if (nwc == "ALL")
            {
                nwc = "%";
            }


            List<FIFOInfo> fifo = new List<FIFOInfo>();
            OracleCommand oracelfifo = new OracleCommand();
            oracelfifo.CommandText = @"SELECT  TO_CHAR(WDATE,'DD/MM/YYYY') AS  WHDate ,  WTIME WHTime , CASE WHEN LENGTH(SERIAL) = 11 THEN SUBSTR(1,4) WHEN LENGTH(SERIAL) = 15 THEN SUBSTR(SERIAL, 4,4) END MODEL_CODE ,MODEL, PLNO,  PLTYPE, AREA, LINE,  COUNT(SERIAL) QTY
                                        FROM FH001 
                                        WHERE COMID='DCI' AND NWC LIKE  '" + nwc + "'  AND MODEL LIKE '" + model + @"'
                                        GROUP BY MODEL, TO_CHAR(WDATE,'DD/MM/YYYY')  , WTIME , PLNO, PLTYPE, AREA, LINE, CASE WHEN LENGTH(SERIAL) = 11 THEN SUBSTR(1,4) WHEN LENGTH(SERIAL) = 15 THEN SUBSTR(SERIAL, 4,4) END  
                                        ORDER BY TO_CHAR(WDATE,'DD/MM/YYYY') ASC, WTIME ASC";
            DataTable dtfifo = oConOracle.Query(oracelfifo);
            if (dtfifo.Rows.Count > 0)
            {
                foreach (DataRow itemfifo in dtfifo.Rows)
                {
                    FIFOInfo datafifo = new FIFOInfo();
                    datafifo.WHDATE = itemfifo["WHDate"].ToString();
                    datafifo.WHTIME = itemfifo["WHTime"].ToString();
                    datafifo.MODEL_CODE = itemfifo["MODEL_CODE"].ToString();
                    datafifo.MODEL = itemfifo["MODEL"].ToString();
                    datafifo.PALLET_NO = itemfifo["PLNO"].ToString();
                    datafifo.PALLET_TYPE = itemfifo["PLTYPE"].ToString();
                    datafifo.AREA = itemfifo["AREA"].ToString();
                    datafifo.LINE = itemfifo["LINE"].ToString();
                    datafifo.QTY = itemfifo["QTY"].ToString();



                    fifo.Add(datafifo);
                }
            }

            return fifo;
        }

        public List<FIFOInfo> GetFIFOForExcelList(string model, string nwc)
        {
            if (nwc == "ALL")
            {
                nwc = "%";
            }


            List<FIFOInfo> fifoforExcel = new List<FIFOInfo>();
            OracleCommand oracelfifoForExcel = new OracleCommand();
            oracelfifoForExcel.CommandText = @"SELECT  TO_CHAR(WDATE,'DD/MM/YYYY') AS  WHDate ,  WTIME WHTime , CASE WHEN LENGTH(SERIAL) = 11 THEN SUBSTR(1,4) WHEN LENGTH(SERIAL) = 15 THEN SUBSTR(SERIAL, 4,4) END MODEL_CODE ,MODEL, PLNO,  PLTYPE, AREA, LINE,  COUNT(SERIAL) QTY
                                                FROM FH001 
                                                WHERE COMID='DCI' AND NWC LIKE  '" + nwc + "'  AND MODEL LIKE '" + model + @"'
                                                GROUP BY MODEL, TO_CHAR(WDATE,'DD/MM/YYYY')  , WTIME , PLNO, PLTYPE, AREA, LINE, CASE WHEN LENGTH(SERIAL) = 11 THEN SUBSTR(1,4) WHEN LENGTH(SERIAL) = 15 THEN SUBSTR(SERIAL, 4,4) END  
                                                ORDER BY TO_CHAR(WDATE,'DD/MM/YYYY') ASC, WTIME ASC";
            DataTable dtfifoForExcel = oConOracle.Query(oracelfifoForExcel);
            if (dtfifoForExcel.Rows.Count > 0)
            {
                foreach (DataRow itemfifo in dtfifoForExcel.Rows)
                {
                    FIFOInfo datafifoForExcel = new FIFOInfo();
                    datafifoForExcel.WHDATE = itemfifo["WHDate"].ToString();
                    datafifoForExcel.WHTIME = "'" + itemfifo["WHTime"].ToString();
                    datafifoForExcel.MODEL_CODE = "'" + itemfifo["MODEL_CODE"].ToString();
                    datafifoForExcel.MODEL = itemfifo["MODEL"].ToString();
                    datafifoForExcel.PALLET_NO = "'" + itemfifo["PLNO"].ToString();
                    datafifoForExcel.PALLET_TYPE = itemfifo["PLTYPE"].ToString();
                    datafifoForExcel.AREA = itemfifo["AREA"].ToString();
                    datafifoForExcel.LINE = "'" + itemfifo["LINE"].ToString();
                    datafifoForExcel.QTY = "'" + itemfifo["QTY"].ToString();


                    fifoforExcel.Add(datafifoForExcel);
                }
            }

            return fifoforExcel;
        }

        public List<ObsoletePDTInfo> GetObsoletePDTExcelList(string model, string nwc, string date)
        {
            List<ObsoletePDTInfo> obsoletePDTExcelDate = new List<ObsoletePDTInfo>();

            if (model == "")
            {
                model = "%";
            }


            if (nwc == "ALL")
            {
                nwc = "'PDT','UNW'";

                OracleCommand sqlobsoletPDTeExcel = new OracleCommand();
                sqlobsoletPDTeExcel.CommandText = @"SELECT MODEL, SERIAL, NWC, LINE, CDATE, 
                                                    MONTHS_BETWEEN(CDATE, TO_DATE('" + date + @"','DD-MM-YYYY'))   AS TotalMonth
                                                    FROM FH001 
                                                    WHERE NWC IN (" + nwc + @") AND PRDTYPE = 'COM' AND LINE IN ('1')
                                                    AND MODEL LIKE '" + model + "'";
                DataTable dtObsoletePDTexcel = oConOracle.Query(sqlobsoletPDTeExcel);
                if (dtObsoletePDTexcel.Rows.Count > 0)
                {
                    int sumunit = 0;
                    foreach (DataRow item in dtObsoletePDTexcel.Rows)
                    {
                        ObsoletePDTInfo dataObsoletePDT = new ObsoletePDTInfo();
                        dataObsoletePDT.MODEL = item["MODEL"].ToString();
                        dataObsoletePDT.SERIAL = "'" + item["SERIAL"].ToString();
                        dataObsoletePDT.FGDATE = "'" + item["FG_DATE"].ToString();
                        dataObsoletePDT.SLOWDATE = "'" + item["SLOW_DATE"].ToString();
                        dataObsoletePDT.OBSOLETEDATE = "'" + item["OBSOLETE_DATE"].ToString();
                        dataObsoletePDT.UNIT = "'" + item["PL_QTY"].ToString();
                        dataObsoletePDT.AREA = item["AREA"].ToString();
                        dataObsoletePDT.STATUS = item["STS"].ToString();

                        sumunit += Convert.ToInt16(item["PL_QTY"].ToString());

                        obsoletePDTExcelDate.Add(dataObsoletePDT);
                    }
                }
            }
            else
            {
                OracleCommand sqlobsoletPDTeExcel = new OracleCommand();
                sqlobsoletPDTeExcel.CommandText = @"SELECT MODEL, SERIAL, NWC, LINE, CDATE, 
                                                    MONTHS_BETWEEN(CDATE, TO_DATE('" + date + @"','DD-MM-YYYY'))   AS TotalMonth
                                                    FROM FH001 
                                                    WHERE NWC IN ('" + nwc + @"') AND PRDTYPE = 'COM' AND LINE IN ('1')
                                                    AND MODEL LIKE '" + model + "'";
                DataTable dtObsoletePDTexcel = oConOracle.Query(sqlobsoletPDTeExcel);
                if (dtObsoletePDTexcel.Rows.Count > 0)
                {
                    int sumunit = 0;
                    foreach (DataRow item in dtObsoletePDTexcel.Rows)
                    {
                        ObsoletePDTInfo dataObsoletePDT = new ObsoletePDTInfo();
                        dataObsoletePDT.MODEL = item["MODEL"].ToString();
                        dataObsoletePDT.SERIAL = "'" + item["SERIAL"].ToString();
                        dataObsoletePDT.FGDATE = "'" + item["FG_DATE"].ToString();
                        dataObsoletePDT.SLOWDATE = "'" + item["SLOW_DATE"].ToString();
                        dataObsoletePDT.OBSOLETEDATE = "'" + item["OBSOLETE_DATE"].ToString();
                        dataObsoletePDT.UNIT = "'" + item["PL_QTY"].ToString();
                        dataObsoletePDT.AREA = item["AREA"].ToString();
                        dataObsoletePDT.STATUS = item["STS"].ToString();

                        sumunit += Convert.ToInt16(item["PL_QTY"].ToString());

                        obsoletePDTExcelDate.Add(dataObsoletePDT);
                    }
                }
            }


            return obsoletePDTExcelDate;
        }

        public List<ObsoletePDTInfo> GetObsoletePDTList(string model, string nwc, string date)
        {
            List<ObsoletePDTInfo> obsoletePDTDate = new List<ObsoletePDTInfo>();


            if (model == "")
            {
                model = "%";
            }


            if (nwc == "ALL")
            {
                nwc = "'PDT','UNW'";

                OracleCommand sqlobsoletePDT = new OracleCommand();
                sqlobsoletePDT.CommandText = @"SELECT MODEL, SERIAL, NWC, LINE, CDATE, 
                                                MONTHS_BETWEEN(CDATE, TO_DATE('" + date + @"','DD-MM-YYYY'))   AS TotalMonth
                                                FROM FH001 
                                                WHERE NWC IN (" + nwc + @") AND PRDTYPE = 'COM' AND LINE IN ('1')
                                                AND MODEL LIKE '" + model + "'";
                DataTable dtObsoletePDT = oConOracle.Query(sqlobsoletePDT);
                if (dtObsoletePDT.Rows.Count > 0)
                {
                    foreach (DataRow item in dtObsoletePDT.Rows)
                    {
                        ObsoletePDTInfo dataObsoletePDT = new ObsoletePDTInfo();
                        dataObsoletePDT.MODEL = item["MODEL"].ToString();
                        dataObsoletePDT.SERIAL = item["SERIAL"].ToString();
                        dataObsoletePDT.LOCATION = item["NWC"].ToString();
                        dataObsoletePDT.AREA = item["LINE"].ToString();
                        dataObsoletePDT.FGDATE = item["CDATE"].ToString();
                        dataObsoletePDT.TOTALMONTH = item["TotalMonth"].ToString();


                        obsoletePDTDate.Add(dataObsoletePDT);
                    }
                }
            }

            else
            {
                OracleCommand sqlobsoletePDT = new OracleCommand();
                sqlobsoletePDT.CommandText = @"SELECT MODEL, SERIAL, NWC, LINE, CDATE, 
                                                MONTHS_BETWEEN(CDATE, TO_DATE('21-03-2023','DD-MM-YYYY'))   
                                                FROM FH001 
                                                WHERE NWC IN ('PDT', 'UNW') AND PRDTYPE = 'COM' AND LINE IN ('1')
                                                AND MODEL = '1Y097BKAX1N#A'";
                DataTable dtObsoletePDT = oConOracle.Query(sqlobsoletePDT);
                if (dtObsoletePDT.Rows.Count > 0)
                {
                    foreach (DataRow item in dtObsoletePDT.Rows)
                    {
                        ObsoletePDTInfo dataObsoletePDT = new ObsoletePDTInfo();
                        dataObsoletePDT.MODEL = item["MODEL"].ToString();
                        dataObsoletePDT.SERIAL = item["SERIAL"].ToString();
                        dataObsoletePDT.LOCATION = item["NWC"].ToString();
                        dataObsoletePDT.AREA = item["LINE"].ToString();
                        dataObsoletePDT.FGDATE = item["CDATE"].ToString();
                        dataObsoletePDT.TOTALMONTH = item["TotalMonth"].ToString();

                        obsoletePDTDate.Add(dataObsoletePDT);
                    }
                }
            }


            return obsoletePDTDate;
        }
    }
}
