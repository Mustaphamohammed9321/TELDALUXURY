//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAPPER_WEBAPI_TELDA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_AddNewItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<int> ItemStatusId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string Photo { get; set; }
    }
}
