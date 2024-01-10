
namespace Web_Odev6.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class hasta_table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hasta_table()
        {
            this.hastalik = new HashSet<hastalik>();
            this.randevu_table = new HashSet<randevu_table>();
        }
        public int id { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string TC_No { get; set; }
        public string cinsiyet { get; set; }
        public string yas { get; set; }
        public string paroa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hastalik> hastalik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<randevu_table> randevu_table { get; set; }
    }
}
