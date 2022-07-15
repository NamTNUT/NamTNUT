using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToolAutoGen.Models
{
    public class TableView
    {
        [Display(Name ="Tên bảng")]
        public string Object_Name { set; get; }
        public string SuObject_Name { set; get; }
        public string Object_Id { set; get; }
        public string Data_Object_Id { set; get; }
        [Display(Name = "Kiểu ")]
        public string Object_Type { set; get; }
        public string Created { set; get; }
        public string Last_Ddl_Time { set; get; }
        public string TimesStamp { set; get; }
        [Display(Name = "Trạng thái")]
        public string Status { set; get; }
        public string Temporary { set; get; }
        public string Generated { set; get; }
        public string Secondary { set; get; }
    }
}