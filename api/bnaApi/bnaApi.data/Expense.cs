//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bnaApi.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Expense
    {
        public System.DateTime dateExpensed { get; set; }
        public System.DateTime dateCreated { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
        public System.Guid categoryId { get; set; }
        public System.Guid id { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
