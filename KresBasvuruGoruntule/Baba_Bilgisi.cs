//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KresBasvuruGoruntule
{
    using System;
    using System.Collections.Generic;
    
    public partial class Baba_Bilgisi
    {
        public int Baba_Id { get; set; }
        public Nullable<int> Cocuk_Id { get; set; }
        public string Baba_Adi_Soyadi { get; set; }
        public string Baba_TC_No { get; set; }
        public string Baba_Meslegi { get; set; }
        public string Baba_Meslek_Tipi { get; set; }
        public string Baba_Acik_Is_Adresi { get; set; }
        public string Baba_Calisma_Saatleri { get; set; }
        public string Baba_Cep_Telefonu { get; set; }
        public string Babaya_Ulasilamadiginda_Irtibat_No { get; set; }
        public string Baba_Durumu { get; set; }
    
        public virtual Cocuk_Bilgisi Cocuk_Bilgisi { get; set; }
    }
}
