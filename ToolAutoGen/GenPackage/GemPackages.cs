using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolAutoGen.Models;

namespace ToolAutoGen.GenPackage
{
    public class GemPackages
    {
        public string GenPackageToProcedure(List<FieldsTable> fieldsTableAll)
        {
            string data = string.Empty;
            string parameter = string.Empty, valueparameter = string.Empty, fields = string.Empty;
            string valueUpdate = string.Empty;
            string parWhereAll = string.Empty;
            if (fieldsTableAll == null)
            {
                return data;
            }
            fieldsTableAll= fieldsTableAll
                              .GroupBy(m => new { m.Column_Name, m.Data_Type })
                              .Select(group => group.First())
                              .ToList();
            for (int i = 0; i < fieldsTableAll.Count; i++)
            {

                if (i == fieldsTableAll.Count - 1)
                {
                    parameter += "ip_" + fieldsTableAll[i].Column_Name + "    " + fieldsTableAll[i].Data_Type + ", <br>";
                    valueparameter += "ip_" + fieldsTableAll[i].Column_Name;
                    fields += "t." + fieldsTableAll[i].Column_Name;
                    valueUpdate += "t." + fieldsTableAll[i].Column_Name + "= ip_" + fieldsTableAll[i].Column_Name;
                    parWhereAll += "(t." + fieldsTableAll[i].Column_Name + " like '%' || ip_" + fieldsTableAll[i].Column_Name + " || '%' or ip_" + fieldsTableAll[i].Column_Name + " = '' or ip_" + fieldsTableAll[i].Column_Name + " is null)";
                }
                else
                {
                    parameter += "ip_" + fieldsTableAll[i].Column_Name + "    " + fieldsTableAll[i].Data_Type + ", <br>";
                    valueparameter += "ip_" + fieldsTableAll[i].Column_Name + ",";
                    fields += "t." + fieldsTableAll[i].Column_Name + ",";
                    valueUpdate += "t." + fieldsTableAll[i].Column_Name + "= ip_" + fieldsTableAll[i].Column_Name + ",";
                    parWhereAll += "(t." + fieldsTableAll[i].Column_Name + " like '%' || ip_" + fieldsTableAll[i].Column_Name + " || '%' or ip_" + fieldsTableAll[i].Column_Name + " = '' or ip_" + fieldsTableAll[i].Column_Name + " is null) and ";

                }

            }
            //Insert
            data += "<br> procedure INSERT_" + fieldsTableAll.FirstOrDefault().Table_Name + " ( " + parameter + "";
            data += "                         op_err         out varchar2, <br>";
            data += "                         op_desc        out nvarchar2) is <br>";
            data += "BEGIN  <br>";
            data += "INSERT INTO " + fieldsTableAll.FirstOrDefault().Table_Name + " t <br>";
            data += " (" + fields + ") <br>";
            data += "values <br>";
            data += " (" + valueparameter + "); <br>";
            data += " op_err:= '00'; <br>";
            data += " op_desc:= 'OK'; <br>";
            data += "  EXCEPTION <br>";
            data += " WHEN OTHERS THEN <br>";
            data += " op_err:= SQLCODE; <br>";
            data += " op_desc:= SQLERRM; <br>";
            data += "  END; <br>";
            //Update
            data += " procedure UPDATE_" + fieldsTableAll.FirstOrDefault().Table_Name + " (" + parameter + " <br>";
            data += "                       op_err         out varchar2, <br>";
            data += "                       op_desc        out nvarchar2) is <br>";
            data += "BEGIN <br>";
            data += "UPDATE " + fieldsTableAll.FirstOrDefault().Table_Name + " t <br>";
            data += "SET <br>";
            data += valueUpdate;
            data += "<br> WHERE t." + fieldsTableAll.FirstOrDefault().FieldsKey + " = ip_" + fieldsTableAll.FirstOrDefault().FieldsKey + "; <br>";
            data += " op_err:= '00'; <br>";
            data += " op_desc:= 'OK'; <br>";
            data += " EXCEPTION <br>";
            data += "  WHEN OTHERS THEN <br>";
            data += "op_err:= SQLCODE; <br>";
            data += "op_desc:= SQLERRM; <br>";
            data += "END; <br>";
            //lấy 1 bản ghi
            data += "  procedure GET_" + fieldsTableAll.FirstOrDefault().Table_Name + " (" + parameter + " <br>";
            data += "            op_err    out varchar2, <br>";
            data += "           op_desc   out varchar2, <br>";
            data += "         op_result out t_cursor) is <br>";
            data += "  BEGIN <br>";
            data += " OPEN op_result FOR <br>";
            data += "  select " + fields + " <br>";
            data += "  from " + fieldsTableAll.FirstOrDefault().Table_Name + " t <br>";
            data += "  where(t." + fieldsTableAll.FirstOrDefault().FieldsKey + " = ip_" + fieldsTableAll.FirstOrDefault().FieldsKey + " or ip_" + fieldsTableAll.FirstOrDefault().FieldsKey + " = '' or ip_" + fieldsTableAll.FirstOrDefault().FieldsKey + " is null) <br>";
            data += "  order by t." + fieldsTableAll.FirstOrDefault().FieldsKey + " desc; <br>";
            data += "  op_err:= '00'; <br>";
            data += "  op_desc:= 'OK'; <br>";
            data += "      EXCEPTION <br>";
            data += "      WHEN OTHERS THEN <br>";
            data += " op_err:= SQLCODE; <br>";
            data += " op_desc:= SQLERRM; <br>";
            data += "      END; <br>";
            ///
            data += " procedure GETALL_" + fieldsTableAll.FirstOrDefault().Table_Name + " (" + parameter + "";
            data += "                 op_err    out varchar2, <br>";
            data += "                 op_desc   out varchar2, <br>";
            data += "                 op_result out t_cursor) is <br>";
            data += " BEGIN <br>";
            data += "  OPEN op_result FOR <br>";
            data += "  select " + fields + " <br>";
            data += "  from " + fieldsTableAll.FirstOrDefault().Table_Name + " t <br>";
            data += "  where " + parWhereAll;
            data += "<br> order by t." + fieldsTableAll.FirstOrDefault().FieldsKey + " desc; <br>";
            data += "  op_err:= '00'; <br>";
            data += "  op_desc:= 'OK'; <br>";
            data += "     EXCEPTION <br>";
            data += "      WHEN OTHERS THEN <br>";
            data += " op_err:= SQLCODE; <br>";
            data += " op_desc:= SQLERRM; <br>";
            data += "     END; <br>";
            return data;
        }

        public string GenPackageType(List<FieldsTable> fieldsTableAll)
        {
            string data = string.Empty;
            string parameter = string.Empty, valueparameter = string.Empty, fields = string.Empty;
            string valueUpdate = string.Empty;
            string parWhereAll = string.Empty;
            if (fieldsTableAll == null)
            {
                return data;
            }

            for (int i = 0; i < fieldsTableAll.Count; i++)
            {

                if (i == fieldsTableAll.Count - 1)
                {
                    parameter += "" + fieldsTableAll[i].Column_Name + "    " + checkType(fieldsTableAll[i]) + " (), <br>";
                }
                else
                {
                    parameter += "" + fieldsTableAll[i].Column_Name + "    " + checkType(fieldsTableAll[i]) + ", <br>";
                }
            }
            data = parameter;
            return data;
        }
        public string GemPackParm(List<FieldsTable> fieldsTableAll)
        {
            string data = string.Empty;
            string parameter = string.Empty, valueparameter = string.Empty, fields = string.Empty;
            string valueUpdate = string.Empty;
            string parWhereAll = string.Empty;
            if (fieldsTableAll == null)
            {
                return data;
            }
            fieldsTableAll = fieldsTableAll
                             .GroupBy(m => new { m.Column_Name, m.Data_Type })
                             .Select(group => group.First())
                             .ToList();
            for (int i = 0; i < fieldsTableAll.Count; i++)
            {

                if (i == fieldsTableAll.Count - 1)
                {
                    parameter += "ip_" + fieldsTableAll[i].Column_Name + "    " + fieldsTableAll[i].Data_Type + ", <br>";
                    valueparameter += "ip_" + fieldsTableAll[i].Column_Name;
                    fields += "t." + fieldsTableAll[i].Column_Name;
                    valueUpdate += "t." + fieldsTableAll[i].Column_Name + "= ip_" + fieldsTableAll[i].Column_Name;
                    parWhereAll += "(t." + fieldsTableAll[i].Column_Name + " like '%' || ip_" + fieldsTableAll[i].Column_Name + " || '%' or ip_NAME = '' or ip_" + fieldsTableAll[i].Column_Name + " is null)";
                }
                else
                {
                    parameter += "ip_" + fieldsTableAll[i].Column_Name + "    " + fieldsTableAll[i].Data_Type + ", <br>";
                    valueparameter += "ip_" + fieldsTableAll[i].Column_Name + ",";
                    fields += "t." + fieldsTableAll[i].Column_Name + ",";
                    valueUpdate += "t." + fieldsTableAll[i].Column_Name + "= ip_" + fieldsTableAll[i].Column_Name + ",";
                    parWhereAll += "(t." + fieldsTableAll[i].Column_Name + " like '%' || ip_" + fieldsTableAll[i].Column_Name + " || '%' or ip_NAME = '' or ip_" + fieldsTableAll[i].Column_Name + " is null) and ";

                }

            }
            data += "<br> procedure INSERT_" + fieldsTableAll.FirstOrDefault().Table_Name + " ( " + parameter + "";
            data += "                         op_err         out varchar2, <br>";
            data += "                         op_desc        out nvarchar2); <br>";
            //Update
            data += " procedure UPDATE_" + fieldsTableAll.FirstOrDefault().Table_Name + " (" + parameter + " <br>";
            data += "                       op_err         out varchar2, <br>";
            data += "                       op_desc        out nvarchar2); <br>";
            //
            data += "  procedure GET_" + fieldsTableAll.FirstOrDefault().Table_Name + " (" + parameter + " <br>";
            data += "            op_err    out varchar2, <br>";
            data += "           op_desc   out varchar2, <br>";
            data += "         op_result out t_cursor) ; <br>";
            //
            data += " procedure GETALL_" + fieldsTableAll.FirstOrDefault().Table_Name + " (" + parameter + "";
            data += "                 op_err    out varchar2, <br>";
            data += "                 op_desc   out varchar2, <br>";
            data += "                 op_result out t_cursor) ; <br>";
            return data;
        }

        private string checkType(FieldsTable type)
        {
            string data = string.Empty;
            switch (type.Data_Type.ToUpper())
            {
                case "VARCHAR2":
                    data = "VARCHAR2("+ type.Data_Length+ ")";
                    break;
                case "CHAR":
                    data = "CHAR(" + type.Data_Length + ")";
                    break;
                case "NVARCHAR2":
                    data = "CHAR(" + type.Data_Length + ")";
                    break;
                default:
                    data = type.Data_Type;
                    break;
            }
            return data;
        }
    }
}