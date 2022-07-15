using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using ToolAutoGen.ConnectBase;
using ToolAutoGen.Models;
using ToolAutoGen.Response;

namespace ToolAutoGen.Dao
{
    public class getTableDbDao : DBBase
    {
        public TableViewResponse getTableDB(string conncet)
        {
            TableViewResponse _tableViewResponse = new TableViewResponse();
            OracleConnection conn = ConnectDB(conncet);
            OracleCommand _command = new OracleCommand();
            OracleDataReader dtReader;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                _command.CommandType = CommandType.Text;
                _command.CommandText = @"SELECT * FROM USER_OBJECTS WHERE OBJECT_type = 'TABLE' order by Object_name";
                _command.Connection = conn;
                dtReader = _command.ExecuteReader();
                var tblList = new List<TableView>();
                if (dtReader.HasRows)
                {
                    while (dtReader.Read())
                    {
                        var tbl = new TableView();
                        tbl.Object_Id = (dtReader["Object_Id"].ToString());
                        tbl.Object_Name = (dtReader["Object_Name"].ToString());
                        tbl.Object_Type = (dtReader["Object_Type"].ToString());
                        tbl.Data_Object_Id = (dtReader["Data_Object_Id"].ToString());
                        //tbl.UdfId = (dtReader["UdfId"].ToString());
                        //tbl.UdfName = (dtReader["UdfName"].ToString());
                        //tbl.Amount = ConvertData.ConvertToDecimal(dtReader["Amount"].ToString());
                        //tbl.Currency = (dtReader["Currency"].ToString());
                        tbl.Status = (dtReader["Status"].ToString());
                        tblList.Add(tbl);
                    }
                    _tableViewResponse.tableViewAll = tblList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _command.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return _tableViewResponse;
        }
        public FieldsTableResponse getFieldsTable(string conncet,string table)
        {
            FieldsTableResponse response = new FieldsTableResponse();
            OracleConnection conn = ConnectDB(conncet);
            OracleCommand _command = new OracleCommand();
            OracleDataReader dtReader;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                _command.CommandType = CommandType.Text;
                _command.CommandText = @"Select t.Owner, t.table_name, t.column_name, t.data_type, t.data_length,cols.column_name AS FieldsKey  from sys.all_tab_columns t, all_constraints cons, all_cons_columns cols where t.TABLE_NAME ='"+ table + "' AND cols.TABLE_NAME = '" + table + "' AND cons.constraint_name = cols.constraint_name  AND cons.owner = cols.owner";
                _command.Connection = conn;
                dtReader = _command.ExecuteReader();
                var tblList = new List<FieldsTable>();
                if (dtReader.HasRows)
                {
                    while (dtReader.Read())
                    {
                        var tbl = new FieldsTable();
                        tbl.Owner = (dtReader["Owner"].ToString());
                        tbl.Table_Name = (dtReader["Table_Name"].ToString());
                        tbl.Column_Name = (dtReader["Column_Name"].ToString());
                        tbl.Data_Type = (dtReader["Data_Type"].ToString());
                        tbl.Data_Length = (dtReader["Data_Length"].ToString());
                        tbl.FieldsKey = (dtReader["FieldsKey"].ToString());
                        tblList.Add(tbl);
                    }
                    response.fieldsTablesAll = tblList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _command.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return response;
        }

        public FieldsTableResponse getFieldsTableType(string conncet, string table)
        {
            FieldsTableResponse response = new FieldsTableResponse();
            OracleConnection conn = ConnectDB(conncet);
            OracleCommand _command = new OracleCommand();
            OracleDataReader dtReader;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                _command.CommandType = CommandType.Text;
                _command.CommandText = @"Select t.Owner, t.table_name, t.column_name, t.data_type, t.data_length  from sys.all_tab_columns t where t.TABLE_NAME ='" + table + "' order by t.COLUMN_ID";
                _command.Connection = conn;
                dtReader = _command.ExecuteReader();
                var tblList = new List<FieldsTable>();
                if (dtReader.HasRows)
                {
                    while (dtReader.Read())
                    {
                        var tbl = new FieldsTable();
                        tbl.Owner = (dtReader["Owner"].ToString());
                        tbl.Table_Name = (dtReader["Table_Name"].ToString());
                        tbl.Column_Name = (dtReader["Column_Name"].ToString());
                        tbl.Data_Type = (dtReader["Data_Type"].ToString());
                        tbl.Data_Length = (dtReader["Data_Length"].ToString());
                        //tbl.FieldsKey = (dtReader["FieldsKey"].ToString());
                        tblList.Add(tbl);
                    }
                    response.fieldsTablesAll = tblList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _command.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return response;
        }
    }
}