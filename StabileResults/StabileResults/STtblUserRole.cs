//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StabileResults
{
    using System;
    using System.Collections.Generic;
    
    public partial class STtblUserRole
    {
        public STtblUserRole()
        {
            this.STtblUsers = new HashSet<STtblUser>();
        }
    
        public int tblUserRoleId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<STtblUser> STtblUsers { get; set; }
    }
}