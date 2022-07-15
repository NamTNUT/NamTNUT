using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolAutoGen.Models;

namespace ToolAutoGen.ConnectBase
{
    public class DBBase
    {
        public string CheckConnection(viewConnect _viewConnect)
        {
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + _viewConnect.Host + ")(PORT=" + _viewConnect.Port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME = " + _viewConnect.ServiceName + ")));User ID=" + _viewConnect.UserName + ";Password=" + _viewConnect.Password + ";"; //Get from configuraiton.
            using (var conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return connectionString;
                }
                catch (Exception ex)
                {
                    return "Connected to Oracle Fail..." + conn.ServerVersion; ;
                }
            }
        }
        protected OracleConnection ConnectDB(string connnect)
        {
            try
            {
                // = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.32.0.74)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME = citadv25)));User ID=dcs;Password=dcs;";
                string strIBCorpConnection = connnect;//ConfigurationManager.ConnectionStrings["DCSConnection"].ConnectionString;
                OracleConnection connection = new OracleConnection(strIBCorpConnection);
                if (connection != null && connection.State != ConnectionState.Open)
                    connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}