//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToolAutoGen.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class REPORTS_SW_FCC_MR
    {
        public decimal ID { get; set; }
        public string MESAGETYPE { get; set; }
        public Nullable<System.DateTime> DATEFROM { get; set; }
        public Nullable<System.DateTime> DATETO { get; set; }
        public Nullable<System.DateTime> DATEFCC { get; set; }
        public Nullable<decimal> TOTALMESSAGE { get; set; }
        public Nullable<decimal> ERRORMESSAGE { get; set; }
        public string CREATEUSER { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public string ELECTRICITY { get; set; }
    }
}
