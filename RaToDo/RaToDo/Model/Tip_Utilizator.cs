//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RaToDo.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tip_Utilizator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tip_Utilizator()
        {
            this.Utilizatoris = new HashSet<Utilizatori>();
        }
    
        public int IDTip_Utilzator { get; set; }
        public string Denumire { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utilizatori> Utilizatoris { get; set; }
    }
}
