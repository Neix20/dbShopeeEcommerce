//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dbShopeeEcommerce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TShopeeOrder
    {
        public int order_id { get; set; }
        public Nullable<System.DateTime> order_placed_date { get; set; }
        public Nullable<decimal> total_price { get; set; }
        public Nullable<int> order_status_id { get; set; }
    }
}
