//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tb_PhieuXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_PhieuXuat()
        {
            this.tb_CTPX = new HashSet<tb_CTPX>();
        }
    
        public string maPhieuXuat { get; set; }
        public string tenKH { get; set; }
        public System.DateTime ngayXuat { get; set; }
        public long thanhTien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_CTPX> tb_CTPX { get; set; }
    }
}
