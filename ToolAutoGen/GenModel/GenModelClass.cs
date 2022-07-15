using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolAutoGen.Commom;
using ToolAutoGen.Models;

namespace ToolAutoGen.GenModel
{
    public class GenModelClass
    {
        public string GenModelcls(List<FieldsTable> fieldsTableAll)
        {
            try
            {
                string data = string.Empty;
                if (fieldsTableAll == null)
                {
                    return data;
                }
                fieldsTableAll = fieldsTableAll
                             .GroupBy(m => new { m.Column_Name, m.Data_Type })
                             .Select(group => group.First())
                             .ToList();
                data += "// class table " + fieldsTableAll.FirstOrDefault().Table_Name+ "<br>";
                data += " public class " + char.ToUpper(fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant()[0]) + fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant().Substring(1) + "  {  public  " + char.ToUpper(fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant()[0]) + fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant().Substring(1) + " () { } <br>";
                foreach (var item in fieldsTableAll)
                {
                    data += "public " + Commoms.ConvertString(item.Data_Type) + " " + char.ToUpper(item.Column_Name.ToLowerInvariant()[0]) + item.Column_Name.ToLowerInvariant().Substring(1) + " { set; get; } <br>";
                }
                data += " } <br>";
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}