﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SecureDriving
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dd_databaseEntities : DbContext
    {
        public dd_databaseEntities()
            : base("name=dd_databaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<blogcoment> blogcoments { get; set; }
        public DbSet<blogpost> blogposts { get; set; }
        public DbSet<caso> casos { get; set; }
        public DbSet<casos1> casos1 { get; set; }
        public DbSet<client> clients { get; set; }
        public DbSet<client1> client1 { get; set; }
        public DbSet<court> courts { get; set; }
        public DbSet<court1> court1 { get; set; }
        public DbSet<email> emails { get; set; }
        public DbSet<usuario> usuarios { get; set; }
        public DbSet<video_usuarios_tipo> video_usuarios_tipo { get; set; }
        public DbSet<video_usuarios> video_usuarios { get; set; }
    }
}