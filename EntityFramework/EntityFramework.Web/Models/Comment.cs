//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public System.Guid Id { get; set; }
        public System.Guid PostId { get; set; }
        public string Content { get; set; }
        public System.DateTime Date { get; set; }
        public string Email { get; set; }
        public bool Approved { get; set; }
    
        public virtual Post Post { get; set; }
    }
}
