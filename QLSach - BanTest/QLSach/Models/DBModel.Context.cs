﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLSach.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BookShopEntities : DbContext
    {
        public BookShopEntities()
            : base("name=BookShopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tb_CTPN> tb_CTPN { get; set; }
        public virtual DbSet<tb_CTPX> tb_CTPX { get; set; }
        public virtual DbSet<tb_GianHang> tb_GianHang { get; set; }
        public virtual DbSet<tb_NguoiDung> tb_NguoiDung { get; set; }
        public virtual DbSet<tb_NXB> tb_NXB { get; set; }
        public virtual DbSet<tb_PhieuNhap> tb_PhieuNhap { get; set; }
        public virtual DbSet<tb_PhieuXuat> tb_PhieuXuat { get; set; }
        public virtual DbSet<tb_Sach> tb_Sach { get; set; }
    }
}