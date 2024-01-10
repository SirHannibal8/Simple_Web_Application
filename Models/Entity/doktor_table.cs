namespace Web_Odev6.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class doktor_table
    {
        public int id { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string bolum { get; set; }
        public string seviye { get; set; }
        public double tecrube { get; set; }
        public string kullaniciadi { get; set; }
        public string parola { get; set; }
    }
}
