//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EjemploDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserPermission
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PermissionId { get; set; }
    
        public virtual Permission Permission { get; set; }
        public virtual User User { get; set; }
    }
}
