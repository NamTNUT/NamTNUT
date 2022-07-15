using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolAutoGen.Models;

namespace ToolAutoGen.GenModel
{
    public class GenFuncDao
    {
        public string GenDao(List<FieldsTable> fieldsTableAll)
        {
            string data = string.Empty;
            if (fieldsTableAll == null)
            {
                return data;
            }
            string table = char.ToUpper(fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant()[0]) + fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant().Substring(1);
            data += " public class " + char.ToUpper(fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant()[0]) + fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant().Substring(1) + "Dao : DBBase";
            data += " {";
            data += " public " + table + "Response getFind(" + table + " model)";
            data += " {";
            data += "  " + table + "Response " + table + "Respon = new " + table + "Response();";
            data += " OracleConnection conn = ConnectDB();<br>";
            data += "  OracleCommand _command = new OracleCommand();<br>";
            data += " OracleDataReader dtReader;<br>";
            data += "  var tbl = new " + table + "();<br>";
            data += " try<br>";
            data += " {<br>";
            data += "    if (conn.State != ConnectionState.Open)<br>";
            data += "       conn.Open();<br>";
            data += " _command.CommandType = CommandType.StoredProcedure;<br>";
            data += @"  _command.CommandText = ""PK_NamePackage.GET_" + fieldsTableAll.FirstOrDefault().Table_Name + @""";<br>";
            foreach (var item in fieldsTableAll)
            {
                data += @" _command.Parameters.Add(new OracleParameter(""ip_" + item.Column_Name + @""", OracleDbType." + item.Data_Type + ")).Value = (object)model." + char.ToUpper(item.Column_Name.ToLowerInvariant()[0]) + item.Column_Name.ToLowerInvariant().Substring(1) + " ?? DBNull.Value;<br>";
            }
            data += @" _command.Parameters.Add(new OracleParameter(""op_err"", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;<br>";
            data += @" _command.Parameters.Add(new OracleParameter(""op_desc"", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;<br>";
            data += @" _command.Parameters.Add(new OracleParameter(""op_result"", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;<br>";
            data += " _command.Connection = conn;";
            data += " dtReader = _command.ExecuteReader();";
            data += " " + table + @"Respon.ErrCode = _command.Parameters[""op_err""].Value.ToString();<br>";
            data += " " + table + @"Respon.ErrDesc = _command.Parameters[""op_desc""].Value.ToString();<br>";
            data += " if (dtReader.HasRows)<br>";
            data += " {<br>";
            data += " while (dtReader.Read())<br>";
            data += " {<br>";
            foreach (var item in fieldsTableAll)
            {
                data += @"  tbl." + char.ToUpper(item.Column_Name.ToLowerInvariant()[0]) + item.Column_Name.ToLowerInvariant().Substring(1) + @" = (dtReader[""" + char.ToUpper(item.Column_Name.ToLowerInvariant()[0]) + item.Column_Name.ToLowerInvariant().Substring(1) + @"""].ToString()); <br>";
            }
            data += " }";
            data += " " + table + "Respon." + fieldsTableAll.FirstOrDefault().Table_Name.ToLower() + " = tbl;";
            data += " }<br>";
            data += " }<br>";
            data += " catch (Exception ex)<br>";
            data += " {<br>";
            data += " throw ex;<br>";
            data += " }<br>";
            data += " finally<br>";
            data += " {<br>";
            data += " _command.Dispose();<br>";
            data += "  conn.Close();<br>";
            data += "   conn.Dispose();<br>";
            data += " }<br>";
            data += "  return " + table + "Respon;<br>";
            data += " }<br>";
            data += " public " + table + "Response getAll(" + table + " model)<br>";
            data += " {";
            data += "  " + table + "Response Response = new " + table + "Response();<br>";
            data += "  OracleConnection conn = ConnectDB();<br>";
            data += "  OracleCommand _command = new OracleCommand();<br>";
            data += "  OracleDataReader dtReader;<br>";
            data += @"  List<" + table + "> listTbl = new List<" + table + ">();<br>";
            data += "   try";
            data += "  {";
            data += "     if (conn.State != ConnectionState.Open)<br>";
            data += "         conn.Open();<br>";
            data += "    _command.CommandType = CommandType.StoredProcedure;<br>";
            data += @"    _command.CommandText = ""PK_NamePackage.GETALL_" + fieldsTableAll.FirstOrDefault().Table_Name + @""";<br>";
            foreach (var item in fieldsTableAll)
            {
                data += @" _command.Parameters.Add(new OracleParameter(""ip_" + item.Column_Name + @""", OracleDbType." + item.Data_Type + ")).Value = (object)model." + char.ToUpper(item.Column_Name.ToLowerInvariant()[0]) + item.Column_Name.ToLowerInvariant().Substring(1) + " ?? DBNull.Value;<br>";
            }
            data += @"  _command.Parameters.Add(new OracleParameter(""op_err"", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output; <br>";
            data += @"  _command.Parameters.Add(new OracleParameter(""op_desc"", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output; <br>";
            data += @" _command.Parameters.Add(new OracleParameter(""op_result"", OracleDbType.RefCursor)).Direction = ParameterDirection.Output; <br>";
            data += "  _command.Connection = conn;<br>";
            data += "  dtReader = _command.ExecuteReader();<br>";
            data += @"   Response.ErrCode = _command.Parameters[""op_err""].Value.ToString();<br>";
            data += @"   Response.ErrDesc = _command.Parameters[""op_desc""].Value.ToString();<br>";
            data += "   if (dtReader.HasRows)<br>";
            data += "  {";
            data += "   while (dtReader.Read())<br>";
            data += "   {";
            data += "      var tbl = new " + table + "();<br>";
            foreach (var item in fieldsTableAll)
            {
                data += @"  tbl." + char.ToUpper(item.Column_Name.ToLowerInvariant()[0]) + item.Column_Name.ToLowerInvariant().Substring(1) + @" = (dtReader[""" + char.ToUpper(item.Column_Name.ToLowerInvariant()[0]) + item.Column_Name.ToLowerInvariant().Substring(1) + @"""].ToString()); <br>";
            }
            data += "      listTbl.Add(tbl);";
            data += "  }";
            data += "   Response." + fieldsTableAll.FirstOrDefault().Table_Name.ToLower() + "All = listTbl;<br>";
            data += "  }";
            data += "   }";
            data += "  catch (Exception ex)";
            data += "  {";
            data += "   throw ex;";
            data += "  }";
            data += "  finally";
            data += "  {";
            data += "     _command.Dispose();<br>";
            data += "     conn.Close();<br>";
            data += "     conn.Dispose();<br>";
            data += "  }";
            data += "  return Response;<br>";
            data += "  }";

            data += " public " + table + "Response Insert(" + table + " model) <br>";
            data += "{ <br>";
            data += " " + table + "Response Response = new " + table + "Response(); <br>";
            data += " OracleConnection conn = ConnectDB(); <br>";
            data += " OracleCommand _command = new OracleCommand(); <br>";
            data += " OracleDataReader dtReader; <br>";
            data += " try <br>";
            data += " { <br>";
            data += "    if (conn.State != ConnectionState.Open) <br>";
            data += "       conn.Open(); <br>";
            data += "   _command.CommandType = CommandType.StoredProcedure; <br>";
            data += @"  _command.CommandText = ""PK_NamePackage.INSERT_" + fieldsTableAll.FirstOrDefault().Table_Name + @"""; <br>";
            foreach (var item in fieldsTableAll)
            {
                data += @" _command.Parameters.Add(new OracleParameter(""ip_" + item.Column_Name + @""", OracleDbType." + item.Data_Type + ")).Value = (object)model." + char.ToUpper(item.Column_Name.ToLowerInvariant()[0]) + item.Column_Name.ToLowerInvariant().Substring(1) + " ?? DBNull.Value;<br>";
            }
            data += @"_command.Parameters.Add(new OracleParameter(""op_err"", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output; <br>";
            data += @" _command.Parameters.Add(new OracleParameter(""op_desc"", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output; <br>";
            data += " _command.Connection = conn; <br>";
            data += " dtReader = _command.ExecuteReader(); <br>";
            data += @" Response.ErrCode = _command.Parameters[""op_err""].Value.ToString(); <br>";
            data += @" Response.ErrDesc = _command.Parameters[""op_desc""].Value.ToString(); <br>";
            data += " } <br>";
            data += "catch (Exception ex) <br>";
            data += "{ <br>";
            data += "  throw ex; <br>";
            data += "} <br>";
            data += "finally <br>";
            data += " { <br>";
            data += "   _command.Dispose(); <br>";
            data += "  conn.Close(); <br>";
            data += "  conn.Dispose(); <br>";
            data += "} <br>";
            data += "return Response; <br>";
            data += " } <br>";

            data += " public " + table + "Response Update(" + table + " model)<br>";
            data += " {<br>";
            data += "   " + table + "Response Response = new " + table + "Response();<br>";
            data += "  OracleConnection conn = ConnectDB();<br>";
            data += "  OracleCommand _command = new OracleCommand();<br>";
            data += "  OracleDataReader dtReader;<br>";
            data += "  try<br>";
            data += "   {<br>";
            data += "    if (conn.State != ConnectionState.Open)<br>";
            data += "       conn.Open();<br>";
            data += "   _command.CommandType = CommandType.StoredProcedure;<br>";
            data += @"  _command.CommandText = ""PK_NamePackage.UPDATE_" + fieldsTableAll.FirstOrDefault().Table_Name + @"""; <br>";
            foreach (var item in fieldsTableAll)
            {
                data += @" _command.Parameters.Add(new OracleParameter(""ip_" + item.Column_Name + @""", OracleDbType." + item.Data_Type + ")).Value = (object)model." + char.ToUpper(item.Column_Name.ToLowerInvariant()[0]) + item.Column_Name.ToLowerInvariant().Substring(1) + " ?? DBNull.Value;<br>";
            }
            data += @" _command.Parameters.Add(new OracleParameter(""op_err"", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;<br>";
            data += @"  _command.Parameters.Add(new OracleParameter(""op_desc"", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;<br>";
            data += " _command.Connection = conn;<br>";
            data += " dtReader = _command.ExecuteReader();<br>";
            data += @" Response.ErrCode = _command.Parameters[""op_err""].Value.ToString();<br>";
            data += @" Response.ErrDesc = _command.Parameters[""op_desc""].Value.ToString();<br>";
            data += " }<br>";
            data += " catch (Exception ex)<br>";
            data += " {<br>";
            data += "    throw ex;<br>";
            data += " }<br>";
            data += " finally<br>";
            data += " {<br>";
            data += "   _command.Dispose();<br>";
            data += "   conn.Close();<br>";
            data += "  conn.Dispose();<br>";
            data += "  }<br>";
            data += " return Response;<br>";
            data += " } <br>";

            data += " }<br>";
            return data;
        }
    }
}