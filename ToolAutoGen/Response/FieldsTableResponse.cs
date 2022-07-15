using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolAutoGen.Models;

namespace ToolAutoGen.Response
{
    public class FieldsTableResponse
    {
        public FieldsTable  fieldsTable { set; get; }
        public List<FieldsTable> fieldsTablesAll  { set; get; }
    }
}