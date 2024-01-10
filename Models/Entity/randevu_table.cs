
namespace Web_Odev6.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class randevu_table
    {
        public int id { get; set; }
        public int hasta_id { get; set; }
        public System.DateTime saat { get; set; }
    
        public virtual hasta_table hasta_table { get; set; }
    }
}
