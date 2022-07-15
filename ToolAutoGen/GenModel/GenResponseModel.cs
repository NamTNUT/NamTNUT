using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolAutoGen.Models;

namespace ToolAutoGen.GenModel
{
    public class GenResponseModel
    {
        public string ResponseModel(List<FieldsTable> fieldsTableAll)
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
            data += "public class " + char.ToUpper(fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant()[0]) + fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant().Substring(1) + "Response : ResponseBases <br>";
            data += " { <br>";
            data += " public " + char.ToUpper(fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant()[0]) + fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant().Substring(1) + " " + fieldsTableAll.FirstOrDefault().Table_Name.ToLower() + " { set; get; } <br>";
            data += @" public List<" + char.ToUpper(fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant()[0]) + fieldsTableAll.FirstOrDefault().Table_Name.ToLowerInvariant().Substring(1) + @"> " + fieldsTableAll.FirstOrDefault().Table_Name.ToLower() + "All { set; get; } <br>";
            data += " } <br>";
            return data;
        }
    }
}