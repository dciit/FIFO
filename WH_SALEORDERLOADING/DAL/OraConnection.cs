using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH_SALEORDERLOADING
{
    class OraConnection
    {

        private string oradb = "";


        public OraConnection(string DBSource)
        {
            //
            // TODO: Add constructor logic here
            //

            if (DBSource == "ALPHA01")
            {
                oradb = @"Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.214.123)(PORT = 1531)) (CONNECT_DATA = (SID = DCIOS01)));User Id=master;Password=master";
            }
            else if (DBSource == "ALPHA02")
            {
                oradb = @"Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.214.124)(PORT = 1532)) (CONNECT_DATA = (SID = DCIOS02)));User Id=mc;Password=mc";
            }
            else if (DBSource == "DAPICSI")
            {
                oradb = @"Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.214.123)(PORT = 1531)) (CONNECT_DATA = (SID = DCIOS01)));User Id=master;Password=master";
            }
            else if (DBSource == "ALPHAPD")
            {
                oradb = @"Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.215.193)(PORT = 1521)) (CONNECT_DATA = (SID = DCIPD)));User Id=se;Password=isse";
            }
        }



        private bool useDB = true;
        public DataTable Query(string queryStr)
        {
            if (useDB)
            {
                //OracleConnection conn = new OracleConnection(connStr);
                OracleConnection oraConn = new OracleConnection();
                oraConn.ConnectionString = oradb;
                oraConn.Open();

                OracleDataAdapter adapter = new OracleDataAdapter(queryStr, oraConn);
                DataTable dTable = new DataTable();
                DataSet dSet = new DataSet();

                try
                {
                    adapter.Fill(dSet, "dataTable");
                    return dSet.Tables["dataTable"];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return dTable;
                }
                finally
                {
                    oraConn.Close();
                }

            }
            else
            {
                return new DataTable();
            }

        }

        /// <summary>
        /// Query table by string and return table 
        /// </summary>
        /// <param name="commandDb">CommandDB for query</param>
        /// <returns>DataTable</returns>
        /// <remarks></remarks>
        public DataTable Query(OracleCommand commandDb)
        {
            if (useDB)
            {
                OracleConnection oraConn = new OracleConnection();
                oraConn.ConnectionString = oradb;
                oraConn.Open();

                //OracleConnection conn = new OracleConnection(connStr);
                commandDb.Connection = oraConn;


                OracleDataAdapter adapter = new OracleDataAdapter(commandDb);
                DataTable dTable = new DataTable();
                DataSet dSet = new DataSet();

                try
                {
                    adapter.Fill(dSet, "dataTable");
                    return dSet.Tables["dataTable"];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return dTable;
                }
                finally
                {
                    oraConn.Close();
                }

            }
            else
            {
                return new DataTable();
            }

            //=================================================================================
        }

        /// <summary>
        /// Execute คำสั่ง sql
        /// </summary>
        /// <param name="exeStr">String of sql</param>
        /// <remarks></remarks>

        public void ExecuteCommand(string exeStr)
        {
            if (useDB)
            {
                //OracleConnection conn = new OracleConnection(connStr);
                OracleConnection oraConn = new OracleConnection();
                oraConn.ConnectionString = oradb;
                oraConn.Open();

                try
                {
                    OracleCommand commandDb = new OracleCommand(exeStr, oraConn);
                    ExecuteCommand(commandDb);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    oraConn.Close();
                }
            }

        }

        /// <summary>
        /// ExecuteCommand
        /// </summary>
        /// <param name="commandDb">commanddb for execute</param>
        /// <remarks></remarks>
        public void ExecuteCommand(OracleCommand commandDb)
        {
            if (useDB)
            {
                //OracleConnection conn = new OracleConnection(connStr);
                OracleConnection oraConn = new OracleConnection();
                oraConn.ConnectionString = oradb;
                oraConn.Open();
                try
                {
                    commandDb.Connection = oraConn;
                    //conn.Open();
                    commandDb.ExecuteNonQuery();
                    //conn.Close();
                    oraConn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    oraConn.Close();
                }

            }
        }


    }
}
