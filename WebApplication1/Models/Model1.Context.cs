﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Etecpf2023DanielPedroEntities : DbContext
    {
        public Etecpf2023DanielPedroEntities()
            : base("name=Etecpf2023DanielPedroEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_cachorro> tb_cachorro { get; set; }
        public virtual DbSet<tb_dono> tb_dono { get; set; }
    }
}