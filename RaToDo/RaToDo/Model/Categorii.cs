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

    public partial class Categorii
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categorii()
        {
            this.Tasks = new HashSet<Task>();
        }

        public Categorii(int _idUtilizator, string numeCategorie)
        {
            this.IDUtilizator = _idUtilizator;
            this.Nume = numeCategorie;
            this.Tasks = new HashSet<Task>();
        }

        public int IDCategorie { get; set; }
        public Nullable<int> IDUtilizator { get; set; }
        public string Nume { get; set; }

        public virtual Utilizatori Utilizatori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
