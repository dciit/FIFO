using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH_OBSOLETEREPORT.Model;

namespace WH_OBSOLETEREPORT.Service
{
    internal class ObsoleteService
    {
        private ClsOraConnection oConOracle = new ClsOraConnection("ALPHAPD");
        private List<ObsoleteInfo> obsoList = new List<ObsoleteInfo>();
        private List<FIFOInfo> fifoList = new List<FIFOInfo>();
        private ConnectDB oCon = new ConnectDB("DBSCM");

        public List<ObsoleteInfo> GetObsoleteExcelList(string date, string nwc)
        {
            List<ObsoleteInfo> obsoleteExcelDate = new List<ObsoleteInfo>();

            if (nwc == "ALL")
            {
                nwc = "'DCI','SKO','PDT','UNW','HWH','RPK','RWD','RWE','RWQ'";


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
                nwc = "'DCI','SKO','PDT','UNW','HWH','RPK','RWD','RWE','RWQ'";

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

        public List<FIFOInfo> GetFIFOList(bool MType, string model, string modelCode, string wc, string palletType)
        {
            string conditionPLType = " AND PLTYPE LIKE '' ";
            string conditionWC = " AND  NWC LIKE  '' ";
            string conditionModel = " AND  Model LIKE  '' ";
            

            if (palletType == "ALL") {
                conditionPLType = " AND PLTYPE LIKE '%' ";
            }
            else
            {
                conditionPLType = " AND PLTYPE LIKE '"+ palletType + "' ";
            }

            if (wc == "ALL")
            {
                conditionWC = " AND NWC IN ('DCI','PDT','SKO','RPK') ";
            }
            else
            {
                conditionWC = " AND NWC LIKE '" + wc + "' ";
            }

            if (MType) {
                conditionModel = " AND CASE WHEN LENGTH(SERIAL) = 11 THEN SUBSTR(SERIAL,1,4) WHEN LENGTH(SERIAL) = 15 THEN SUBSTR(SERIAL, 4,4) END = '" + modelCode + "' ";
            }
            else
            {
                conditionModel = " AND MODEL = '" + model + "' ";
            }


            List<FIFOInfo> fifo = new List<FIFOInfo>();
            OracleCommand oracelfifo = new OracleCommand();
            oracelfifo.CommandText = @"SELECT  TO_CHAR(WDATE,'DD/MM/YYYY') || ' ' || WTIME AS  WHDatetime,  TO_CHAR(WDATE,'DD/MM/YYYY') AS  WHDate , TO_CHAR(CDATE,'DD/MM/YYYY') AS  FGDATE, TO_CHAR(CDATE,'YYYYMMDD') Sorting,  WTIME WHTime , 
                                        CASE WHEN LENGTH(SERIAL) = 11 THEN SUBSTR(SERIAL,1,4) WHEN LENGTH(SERIAL) = 15 THEN SUBSTR(SERIAL, 4,4) END MODEL_CODE , 
                                        FWC PrevWC, TO_CHAR(NDATE,'DD/MM/YYYY') AS  CURDATE,
                                        MODEL MODEL_NAME, PLNO, LOCACODE, PLTYPE, AREA, LINE,NWC,  COUNT(SERIAL) QTY
                                        FROM FH001 
                                        WHERE COMID='DCI'  " + conditionModel + " " + conditionWC + @" " + conditionPLType + @"     
                                        GROUP BY TO_CHAR(WDATE,'DD/MM/YYYY') || ' ' || WTIME, MODEL, TO_CHAR(WDATE,'DD/MM/YYYY') , TO_CHAR(CDATE,'DD/MM/YYYY'), TO_CHAR(CDATE,'YYYYMMDD'),  WTIME , 
                                        PLNO,LOCACODE, PLTYPE, AREA, LINE,NWC, CASE WHEN LENGTH(SERIAL) = 11 THEN SUBSTR(SERIAL,1,4) WHEN LENGTH(SERIAL) = 15 THEN SUBSTR(SERIAL, 4,4) END, FWC, TO_CHAR(NDATE,'DD/MM/YYYY')  
                                        ORDER BY TO_CHAR(CDATE,'YYYYMMDD') ASC ";
            DataTable dtfifo = oConOracle.Query(oracelfifo);

            
            //LINE, WHDatetime, QTY, FGDATE
            if (dtfifo.Rows.Count > 0)
            {

                DataView dvFIFO = new DataView(dtfifo);
                DataTable distrFIFO = dvFIFO.ToTable(true, "MODEL_NAME", "MODEL_CODE", "PLNO", "PLTYPE", "LOCACODE", "NWC", "CURDATE", "PrevWC");


                foreach (DataRow itemfifo in distrFIFO.Rows)
                {
                    FIFOInfo datafifo = new FIFOInfo();
                    datafifo.MODEL_NAME = itemfifo["MODEL_NAME"].ToString();
                    datafifo.MODEL_CODE = itemfifo["MODEL_CODE"].ToString();
                    datafifo.PALLET_NO = itemfifo["PLNO"].ToString();
                    datafifo.PALLET_TYPE = itemfifo["PLTYPE"].ToString();
                    datafifo.LOCATION_CODE = itemfifo["LOCACODE"].ToString();
                    datafifo.WAREHOUSE_CODE = itemfifo["NWC"].ToString();
                    datafifo.CurrnetWCDate = itemfifo["CURDATE"].ToString();
                    datafifo.PreviousWC = itemfifo["PrevWC"].ToString();



                    DataRow[] drFIFO = dtfifo.Select(" PLNO = '"+ itemfifo["PLNO"].ToString() + "' ", " Sorting ASC ");
                    int qty = 0;
                    foreach(DataRow dr in drFIFO)
                    {
                        qty += Convert.ToInt32(dr["QTY"].ToString());
                    }

                    datafifo.LINE = drFIFO[0]["LINE"].ToString();
                    datafifo.FINISHED_GOODS_DATE = drFIFO[0]["FGDATE"].ToString();
                    datafifo.WAREHOUSE_DATE = drFIFO[0]["WHDatetime"].ToString();

                    datafifo.QTY_IN_PALLET = qty.ToString();

                    fifo.Add(datafifo);
                }
            }

            return fifo;
        }

        public List<FIFOInfo> GetFIFOForExcelList(bool MType, string model, string modelCode, string wc, string palletType)
        {

            string conditionPLType = " AND PLTYPE LIKE '' ";
            string conditionWC = " AND  NWC LIKE  '' ";
            string conditionModel = " AND  Model LIKE  '' ";


            if (palletType == "ALL")
            {
                conditionPLType = " AND PLTYPE LIKE '%' ";
            }
            else
            {
                conditionPLType = " AND PLTYPE LIKE '" + palletType + "' ";
            }

            if (wc == "ALL")
            {
                conditionWC = " AND NWC IN ('DCI','PDT','SKO','RPK') ";
            }
            else
            {
                conditionWC = " AND NWC LIKE '" + wc + "' ";
            }

            if (MType)
            {
                conditionModel = " AND CASE WHEN LENGTH(SERIAL) = 11 THEN SUBSTR(1,4) WHEN LENGTH(SERIAL) = 15 THEN SUBSTR(SERIAL, 4,4) END = '" + modelCode + "' ";
            }
            else
            {
                conditionModel = " AND MODEL = '" + model + "' ";
            }


            List<FIFOInfo> fifo = new List<FIFOInfo>();
            OracleCommand oracelfifo = new OracleCommand();
            oracelfifo.CommandText = @"SELECT  TO_CHAR(WDATE,'DD/MM/YYYY') || ' ' || WTIME AS  WHDatetime,  TO_CHAR(WDATE,'DD/MM/YYYY') AS  WHDate , TO_CHAR(CDATE,'DD/MM/YYYY') AS  FGDATE, TO_CHAR(CDATE,'YYYYMMDD') Sorting,  WTIME WHTime , 
                                        CASE WHEN LENGTH(SERIAL) = 11 THEN SUBSTR(SERIAL,1,4) WHEN LENGTH(SERIAL) = 15 THEN SUBSTR(SERIAL, 4,4) END MODEL_CODE , 
                                        FWC PrevWC, TO_CHAR(NDATE,'DD/MM/YYYY') AS  CURDATE,
                                        MODEL MODEL_NAME, PLNO, LOCACODE, PLTYPE, AREA, LINE,NWC,  COUNT(SERIAL) QTY
                                        FROM FH001 
                                        WHERE COMID='DCI'  " + conditionModel + " " + conditionWC + @" " + conditionPLType + @"     
                                        GROUP BY TO_CHAR(WDATE,'DD/MM/YYYY') || ' ' || WTIME, MODEL, TO_CHAR(WDATE,'DD/MM/YYYY') , TO_CHAR(CDATE,'DD/MM/YYYY'), TO_CHAR(CDATE,'YYYYMMDD'),  WTIME , 
                                        PLNO,LOCACODE, PLTYPE, AREA, LINE,NWC, CASE WHEN LENGTH(SERIAL) = 11 THEN SUBSTR(SERIAL,1,4) WHEN LENGTH(SERIAL) = 15 THEN SUBSTR(SERIAL, 4,4) END, FWC, TO_CHAR(NDATE,'DD/MM/YYYY')  
                                        ORDER BY TO_CHAR(CDATE,'YYYYMMDD') ASC ";
            DataTable dtfifo = oConOracle.Query(oracelfifo);

          
            //LINE, WHDatetime, QTY, FGDATE
            if (dtfifo.Rows.Count > 0)
            {
                DataView dvFIFO = new DataView(dtfifo);
                DataTable distrFIFO = dvFIFO.ToTable(true, "MODEL_NAME", "MODEL_CODE", "PLNO", "PLTYPE", "LOCACODE", "NWC", "CURDATE", "PrevWC");

                foreach (DataRow itemfifo in distrFIFO.Rows)
                {
                    FIFOInfo datafifo = new FIFOInfo();
                    datafifo.MODEL_NAME = itemfifo["MODEL_NAME"].ToString();
                    datafifo.MODEL_CODE = "'" + itemfifo["MODEL_CODE"].ToString();
                    datafifo.PALLET_NO = "'" + itemfifo["PLNO"].ToString();
                    datafifo.PALLET_TYPE = "'" + itemfifo["PLTYPE"].ToString();
                    datafifo.LOCATION_CODE = "'" + itemfifo["LOCACODE"].ToString();
                    datafifo.WAREHOUSE_CODE = "'" + itemfifo["NWC"].ToString();
                    datafifo.CurrnetWCDate = "'" + itemfifo["CURDATE"].ToString();
                    datafifo.PreviousWC = "'" + itemfifo["PrevWC"].ToString();



                    DataRow[] drFIFO = dtfifo.Select(" PLNO = '" + itemfifo["PLNO"].ToString() + "' ", " WHDatetime ASC ");
                    int qty = 0;
                    foreach (DataRow dr in drFIFO)
                    {
                        qty += Convert.ToInt32(dr["QTY"].ToString());
                    }

                    datafifo.LINE = drFIFO[0]["LINE"].ToString();
                    datafifo.FINISHED_GOODS_DATE = "'" + drFIFO[0]["FGDATE"].ToString();
                    datafifo.WAREHOUSE_DATE = "'" + drFIFO[0]["WHDatetime"].ToString();

                    datafifo.QTY_IN_PALLET = qty.ToString();

                    fifo.Add(datafifo);
                }
            }

            return fifo;
        }




        // GETMODEL 
        public List<FIFOInfo> Getmodel(string modelType)
        {

            List<FIFOInfo> modelInfoList = new List<FIFOInfo>();

            //FIFOInfo cbModelALL = new FIFOInfo();
            //cbModelALL.MODEL = "%";
            //cbModelALL.MODEL = "ALL";

            //modelInfoList.Add(cbModelALL);

            string condition = " and PRDTYPE = '' ";

            if (modelType == "1YC")
            {
                condition = " and PRDTYPE = 'COM' and M.MODEL LIKE '1Y%' ";
            }
            else if (modelType == "2YC")
            {
                condition = " and PRDTYPE = 'COM' and M.MODEL LIKE '2Y%' ";
            }
            else if (modelType == "SCROLL")
            {
                condition = " and PRDTYPE = 'COM' and M.MODEL LIKE 'J%' ";
            }
            else if (modelType == "ODM")
            {
                condition = " and PRDTYPE = 'ODM'  ";
            }

            OracleCommand sqlselectODM = new OracleCommand();
            sqlselectODM.CommandText = @"SELECT M.POSTCODE, M.MODEL MODEL_NAME
                                            FROM SE.MT003 M
                                            WHERE LREV='999' " + condition + @"
                                            ORDER BY MODEL ASC";
            DataTable dtModelODM = oConOracle.Query(sqlselectODM);
            if (dtModelODM.Rows.Count > 0)
            {
                foreach (DataRow drowODM in dtModelODM.Rows)
                {
                    FIFOInfo modelODM = new FIFOInfo();
                    modelODM.MODEL_NAME = drowODM["MODEL_NAME"].ToString();
                    modelInfoList.Add(modelODM);
                }
            }

            return modelInfoList;

        }
        // GETMODEL 


        // GETPALLETTYPE 
        public List<FIFOInfo> GetPalletType(string model)
        {

            List<FIFOInfo> palletTypeList = new List<FIFOInfo>();

            FIFOInfo cbPallettypeALL = new FIFOInfo();
            cbPallettypeALL.PALLET_TYPE = "%";
            cbPallettypeALL.PALLET_TYPE = "ALL";

            palletTypeList.Add(cbPallettypeALL);




            OracleCommand sqlPalletList = new OracleCommand();
            sqlPalletList.CommandText = @"SELECT W.MODEL, W.PLTYPE 
                                                FROM SE.WMS_MSTPKM W
                                                WHERE MODEL = '" + model + @"' AND LREV = '999'";
            DataTable dtPalletType = oConOracle.Query(sqlPalletList);
            if (dtPalletType.Rows.Count > 0)
            {
                foreach (DataRow drowsPL in dtPalletType.Rows)
                {
                    FIFOInfo palletType = new FIFOInfo();
                    palletType.PALLET_TYPE = drowsPL["PLTYPE"].ToString();
                    palletTypeList.Add(palletType);
                }
            }


            return palletTypeList;

        }
        // GETPALLETTYPE 
    }
}
