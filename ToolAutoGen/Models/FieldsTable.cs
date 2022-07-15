using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolAutoGen.Models
{
    public class FieldsTable
    {
        public FieldsTable() { }
        public string Owner { set; get; }
        public string Table_Name { set; get; }
        public string Column_Name { set; get; }
        public string Data_Type { set; get; }
        public string Data_Length { set; get; }
        public string FieldsKey { set; get; }

    }
}