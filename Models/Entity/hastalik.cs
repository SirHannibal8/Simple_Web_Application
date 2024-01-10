
namespace Web_Odev6.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class hastalik
    {
        public int id { get; set; }
        public int hasta_id { get; set; }
        public string hastalık { get; set; }
        public string detay { get; set; }
        public string ilac_id { get; set; }
    
        public virtual hasta_table hasta_table { get; set; }
    }
}
