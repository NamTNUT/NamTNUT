using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace ToolAutoGen.GenModel
{
    public class GenDBBase
    {
        public string GenclsDBbase( string connnect)
        {
            string data = string.Empty;
            data += " protected OracleConnection ConnectDB() <br>";
            data += " {<br>";
            data += "    try<br>";
            data += "  {<br>";
            // = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.32.0.74)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME = citadv25)));User ID=dcs;Password=dcs;";
            data += "        string strIBCorpConnection = " + connnect + ";<br>";
            data += "      OracleConnection connection = new OracleConnection(strIBCorpConnection);<br>";
            data += "      if (connection != null && connection.State != ConnectionState.Open)<br>";
            data += "         connection.Open();<br>";
            data += "     return connection;<br>";
            data += " }<br>";
            data += " catch (Exception ex)<br>";
            data += "  {<br>";
            data += "     throw;<br>";
            data += " }<br>";
            data += " }<br>";
            return data;
        }
    }
}