using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolAutoGen.Models;

namespace ToolAutoGen.Response
{
    public class TableViewResponse
    {
        public TableView tableView { set; get; }
        public List<TableView> tableViewAll { set; get; }
    }
}