using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolAutoGen.Commom
{
    public class Commoms
    {
        public static string ConvertString(string data)
        {
            var value = data.Contains("VARCHAR2") ? "string" : data.Contains("Date") ? "DateTime?" : data.Contains("NUMBER") ? "int" : data.Contains("NVARCHAR2") ? "string" : "string";

            return value;
        }
        public static string Response()
        {
            string data = string.Empty;
            data += "public class ResponseBases";
            data += "{";
            data += "public string RequestId { get; set; }<br>";
            data += "public string RequestTypeId { get; set; }<br>";
            data += "public string PageNumber { get; set; }<br>";
            data += "public string PageSize { get; set; }<br>";
            data += "public string Total { get; set; }<br>";
            data += "public string RespCode { get; set; }<br>";
            data += "public string RespDescription { get; set; }<br>";
            data += "public string Token { get; set; }<br>";
            data += "public string Message { set; get; }<br>";
            data += "public string ErrCode { set; get; }<br>";
            data += "public string ErrDesc { set; get; }<br>";
            data += "public string OrderBy { set; get; }<br>";
            data += "}<br>";
            return data;
        }
    }
    public class JTableData
    {
        public int draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public object data { get; set; }
        public object dataPack { get; set; }
        public object dataCls { get; set; }
        public object dataBase { get; set; }
        public object dataConnect { get; set; }
        public object dataResponse { get; set; }
        public object dataDao { get; set; }
        public JTableData(int Draw, int RecordsFiltered, int RecordsTotal, object Data, object DataCls, object DataBase, object DataConnect, object DataResponse, object DataDao,object DataPack)
        {
            draw = Draw;dataPack = DataPack;
            recordsFiltered = RecordsFiltered; recordsTotal = RecordsTotal; data = Data;
            dataCls = DataCls; dataBase = DataBase; dataConnect = DataConnect; dataResponse = DataResponse;
            dataDao = DataDao;
        }
        public JTableData()
        {

        }
    }
}