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
    
    public partial class Anne_Bilgisi
    {
        public int Anne_Id { get; set; }
        public Nullable<int> Cocuk_Id { get; set; }
        public string Anne_Adi_Soyadi { get; set; }
        public string Anne_TC_No { get; set; }
        public string Anne_Meslegi { get; set; }
        public string Anne_Meslek_Tipi { get; set; }
        public string Anne_Acik_Is_Adresi { get; set; }
        public string Anne_Calisma_Saatleri { get; set; }
        public string Anne_Cep_Telefonu { get; set; }
        public string Anneye_Ulasilamadiginda_Irtibat_No { get; set; }
        public string Anne_Durumu { get; set; }
    
        public virtual Cocuk_Bilgisi Cocuk_Bilgisi { get; set; }
    }
}
