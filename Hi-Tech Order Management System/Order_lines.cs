//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hi_Tech_Order_Management_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_lines
    {
        public int OrderId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int OrderQuantity { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
